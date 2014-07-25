using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using ZXing;

namespace RubberDucky
{
    public partial class RubberDuckyForm : Form
    {
        public RubberDuckyForm()
        {
            InitializeComponent();
            IntPtr window = FindVMwareViewWindow();
            if (window == IntPtr.Zero)
                window = FindRDPWindow();
            selectedWindowHandle = window;
            scriptPath = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            NativeMethods.RegisterHotKey(Handle, GetHashCode(), NativeMethods.MOD_CONTROL | NativeMethods.MOD_ALT, VirtualKeyCode.VK_P);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == NativeMethods.WM_HOTKEY)
            {
                NativeMethods.RectStruct r;
                if (selectedWindowHandle == IntPtr.Zero || !NativeMethods.GetWindowRect(selectedWindowHandle, out r))
                {
                    selectedWindowHandle = FindVMwareViewWindow();
                    if (selectedWindowHandle == IntPtr.Zero)
                        selectedWindowHandle = FindRDPWindow();
                }
                inputSimulator_Click(this, null);
            }
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.UnregisterHotKey(Handle, GetHashCode());
        }

        IntPtr FindVMwareViewWindow()
        {
            Process[] processes = Process.GetProcessesByName("VMWARE-VIEW");
            foreach (var p in processes)
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    var sb = new StringBuilder(256);
                    if (NativeMethods.GetClassName(p.MainWindowHandle, sb, sb.Capacity) != 0)
                    {
                        if (String.Equals(sb.ToString(), "#32770"))
                        {
                            return p.MainWindowHandle;
                        }
                    }
                }
            }
            return IntPtr.Zero;
        }

        IntPtr FindRDPWindow()
        {
            IntPtr window = NativeMethods.FindWindow("TscShellContainerClass", null);
            return window;
        }

        private string _scriptPath;
        private string scriptPath
        {
            get { return _scriptPath; }
            set
            {
                _scriptPath = value;
                scriptFileNameLabel.Text = System.IO.Path.GetFileName(value);
            }
        }

        private const int WM_SETREDRAW = 0x000B;

        private IntPtr _selectedWindowHandle;
        private IntPtr selectedWindowHandle
        {
            get { return _selectedWindowHandle; }
            set
            {
                _selectedWindowHandle = value;
                if (_selectedWindowHandle != IntPtr.Zero)
                {
                    int length = (int)NativeMethods.SendMessage(value, NativeMethods.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
                    StringBuilder sb = new StringBuilder(length + 1);
                    NativeMethods.SendMessage(value, NativeMethods.WM_GETTEXT, (IntPtr)sb.Capacity, sb);
                    titleValueLabel.Text = sb.ToString();

                    bool found = false;
                    classValueLabel.Text = "???";
                    sb = new StringBuilder(256);
                    if (NativeMethods.GetClassName(value, sb, sb.Capacity) != 0)
                    {
                        classValueLabel.Text = sb.ToString();
                        if (classValueLabel.Text == "TscShellContainerClass")
                        {
                            classValueLabel.Text = "Microsoft RDP";
                            useDirectInputCheckBox.Checked = true;
                            typingDelayTextBox.Text = "0";
                            if (titleValueLabel.Text.EndsWith(" - Remote Desktop Connection"))
                            {
                                titleValueLabel.Text = titleValueLabel.Text.Substring(0, titleValueLabel.Text.Length - 28);
                            }
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        uint pid;
                        if (NativeMethods.GetWindowThreadProcessId(_selectedWindowHandle, out pid) != 0)
                        {
                            Process p = Process.GetProcessById((int)pid);
                            if (String.Equals(p.ProcessName, "vmware-view", StringComparison.OrdinalIgnoreCase))
                            {
                                classValueLabel.Text = "VMware View";
                                useDirectInputCheckBox.Checked = true;
                                typingDelayTextBox.Text = "5";
                                found = true;
                            }
                        }
                    }

                    NativeMethods.RectStruct rect;
                    if (NativeMethods.GetWindowRect(selectedWindowHandle, out rect))
                    {
                        Trace.TraceInformation("Position: ({0},{1})  Size: {2}x{3}", rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                    }
                    else
                    {
                        Trace.TraceInformation("Could not get window position/size");
                    }
                }
                else
                {
                    classValueLabel.Text = "";
                    titleValueLabel.Text = "";
                }
            }
        }

        private void inputSimulator_Click(object sender, EventArgs e)
        {
            if (selectedWindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Cannot find window.");
                return;
            }
            if (scriptPath == null)
            {
                MessageBox.Show("No script specified.");
                return;
            }

            var script = new DuckyScript();
            script.UseDirectKeyMode = useDirectInputCheckBox.Checked;
            script.DefaultDelay = int.Parse(delayTextBox.Text);
            script.DefaultKeystrokeDelay = int.Parse(typingDelayTextBox.Text);
            using (var r = new System.IO.StreamReader(scriptPath))
            {
                script.Parse(r);
            }

            NativeMethods.RectStruct rect;
            if (!NativeMethods.GetWindowRect(selectedWindowHandle, out rect))
            {
                MessageBox.Show("Cannot find window bounds.");
                return;
            }
            int x = (rect.Left + rect.Right) / 2;
            int y = (rect.Top + rect.Bottom) / 2;

            int maxX = SystemInformation.VirtualScreen.Width;
            int maxY = SystemInformation.VirtualScreen.Height;

            script.sim.Mouse.MoveMouseToPositionOnVirtualDesktop(x * 65535.0 / maxX, y * 65535.0 / maxY);
            NativeMethods.SetForegroundWindow(selectedWindowHandle);
            script.sim.Mouse.LeftButtonClick();

            bool stealthMode = this.stealthCheckBox.Checked;
            outputTextBox.Clear();
            inputSimulatorButton.Enabled = false;
            Task.Run(() =>
            {
                if (stealthMode)
                {
                    NativeMethods.SendMessage(selectedWindowHandle, WM_SETREDRAW, false, 0);
                }

                try
                {
                    script.Run(ProgressDelegate);
                }
                catch (Exception exception)
                {
                    ProgressDelegate(exception.ToString());
                }
                Invoke((MethodInvoker)delegate
                {
                    inputSimulatorButton.Enabled = true;
                });
                if (stealthMode)
                {
                    System.Threading.Thread.Sleep(500);
                    NativeMethods.InvalidateRect(selectedWindowHandle, IntPtr.Zero, true);
                    NativeMethods.SendMessage(selectedWindowHandle, WM_SETREDRAW, true, 0);
                    NativeMethods.InvalidateRect(selectedWindowHandle, IntPtr.Zero, true);
                }
            });
        }

        public void ProgressDelegate(string output)
        {
            Invoke((MethodInvoker)delegate
            {
                outputTextBox.AppendText(output);
            });
        }

        Cursor oldCursor;
        bool _searchingForWindow;
        private void crossPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _searchingForWindow = true;

            // Remove cross icon so we can "drag" it.
            crossPictureBox.Image = null;

            // Change cursor to cross icon.
            oldCursor = Cursor;
            Cursor = Cursors.Cross;

            // Move cursor position to center of cross.
            Rectangle r = crossPictureBox.RectangleToScreen(crossPictureBox.ClientRectangle);
            NativeMethods.SetCursorPos(r.X + Cursor.HotSpot.X, r.Y + Cursor.HotSpot.Y);

            // Capture all mouse activity, so we get all mouse messages.
            Capture = true;

            Application.AddMessageFilter(new MouseMessageFilter(this));
        }

        internal class MouseMessageFilter : IMessageFilter
        {
            private const int WM_MOUSEMOVE = 0x0200;
            private const int WM_LBUTTONUP = 0x0202;

            RubberDuckyForm parent;

            public MouseMessageFilter(RubberDuckyForm parent)
            {
                this.parent = parent;
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)
                {
                    if (!parent._searchingForWindow)
                        return false;
                    parent.OnMouseMove();
                    return true;
                }
                if (m.Msg == WM_LBUTTONUP)
                {
                    if (!parent._searchingForWindow)
                        return false;
                    parent.OnMouseUp();
                    Application.RemoveMessageFilter(this);
                    return true;
                }
                return false;
            }
        }

        void OnMouseMove()
        {
            Point screenPoint = System.Windows.Forms.Cursor.Position;
            IntPtr window = NativeMethods.ChildWindowFromPointEx(NativeMethods.GetDesktopWindow(), screenPoint, 7);
            if (IsValidWindow(window))
            {
                if (selectedWindowHandle != IntPtr.Zero)
                {
                    RefreshWindow(selectedWindowHandle);
                }

                selectedWindowHandle = window;
                HighlightWindow(selectedWindowHandle);
            }
        }

        void OnMouseUp()
        {
            Cursor = oldCursor;

            if (selectedWindowHandle != IntPtr.Zero)
            {
                RefreshWindow(selectedWindowHandle);
            }

            crossPictureBox.Image = global::RubberDucky.Properties.Resources.cross;

            Capture = false;

            _searchingForWindow = false;
        }

        private void RefreshWindow(IntPtr window)
        {
            NativeMethods.InvalidateRect(window, IntPtr.Zero, true);
            NativeMethods.UpdateWindow(window);
            NativeMethods.RedrawWindow(window, IntPtr.Zero, IntPtr.Zero,
                NativeMethods.RedrawWindowFlags.Frame | NativeMethods.RedrawWindowFlags.Invalidate | NativeMethods.RedrawWindowFlags.UpdateNow | NativeMethods.RedrawWindowFlags.AllChildren);
        }

        private void HighlightWindow(IntPtr window)
        {
            NativeMethods.RectStruct rect;
            NativeMethods.GetWindowRect(window, out rect);

            using (Graphics g = Graphics.FromHwnd(window))
            {
                Pen pen = new Pen(Color.Red);
                g.DrawRectangle(pen, 0, 0, rect.Right - rect.Left - 1, rect.Bottom - rect.Top - 1);
            }
        }

        private bool IsValidWindow(IntPtr window)
        {
            if (window == IntPtr.Zero ||
                !NativeMethods.IsWindow(window) ||
                window == selectedWindowHandle ||
                window == this.Handle)
            {
                return false;
            }
            IntPtr windowParent = NativeMethods.GetParent(window);
            if (windowParent == this.Handle)
            {
                return false;
            }
            return true;
        }

        private void openScriptButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                scriptPath = openFileDialog.FileName;
            }
        }

        int SnarfPollingTime = 10;

        private void snarfButtonClicked(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            snarfDataButton.Enabled = false;
            // Start data snarfer thread.
            Task.Run(() =>
            {
                try
                {
                    using (System.IO.Stream outStream = saveFileDialog.OpenFile())
                    {
                        var sim = new InputSimulator();
                        UInt64 bytes = 0;
                        uint expectedFrameNumber = 0;
                        int retries = 0;
                        for (uint loopIterations = 0; ; ++loopIterations)
                        {
                            NativeMethods.SetForegroundWindow(selectedWindowHandle);
                            Result result = ScreenScraper.ReadQRCode(selectedWindowHandle);
                            if (result == null)
                            {
                                // No QR code (yet), keep waiting.
                                if ((++retries % 10) == 0)
                                {
                                    // Regenerate QR code.
                                    sim.Keyboard.KeyPress(DirectInputKeyCode.DIK_R);
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(SnarfPollingTime);
                                }
                                continue;
                            }
                            byte[] b = Convert.FromBase64String(result.Text);
                            if (b.Length < 4)
                            {
                                ProgressDelegate(String.Format("Message too short: {0}", b.Length));
                                sim.Keyboard.KeyPress(DirectInputKeyCode.DIK_Q);
                                break;
                            }
                            uint actualFrameNumber =
                                (uint)(b[0] & 0xFF) |
                                (uint)(b[1] & 0xFF) << 8 |
                                (uint)(b[2] & 0xFF) << 16;
                            if (actualFrameNumber + 1 == expectedFrameNumber)
                            {
                                if ((++retries % 64) != 0)
                                {
                                    // Previous QR code, keep waiting.
                                    System.Threading.Thread.Sleep(SnarfPollingTime);
                                    continue;
                                }
                            }
                            if (actualFrameNumber < expectedFrameNumber)
                            {
                                // Dropped a keypress?
                                sim.Keyboard.KeyPress(DirectInputKeyCode.DIK_N);
                                continue;
                            }
                            if (actualFrameNumber > expectedFrameNumber)
                            {
                                // Skipped a code?
                                sim.Keyboard.KeyPress(DirectInputKeyCode.DIK_P);
                                continue;
                            }
                            if (expectedFrameNumber != actualFrameNumber)
                            {
                                ProgressDelegate(String.Format("Wrong frame number (expected: {0} actual: {1})", expectedFrameNumber, actualFrameNumber));
                                sim.Keyboard.KeyPress(DirectInputKeyCode.DIK_Q);
                                break;
                            }
                            outStream.Write(b, 4, b.Length - 4);
                            bytes += (UInt64)b.Length - 4;
                            if ((b[3] & 1) == 0)
                            {
                                ProgressDelegate(String.Format("Saved {0} bytes", bytes));
                                outStream.Close();
                                break;
                            }
                            sim.Keyboard.KeyPress(DirectInputKeyCode.DIK_N);
                            ++expectedFrameNumber;
                            retries = 0;
                        }
                    }
                }
                catch (Exception exception)
                {
                    ProgressDelegate(exception.ToString());
                }
                Invoke((MethodInvoker)delegate
                {
                    snarfDataButton.Enabled = true;
                });
            });
        }

    }
}
