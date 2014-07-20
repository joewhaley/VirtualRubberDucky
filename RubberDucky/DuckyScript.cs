using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace RubberDucky
{
    class DuckyScript
    {
        List<Command> commands;
        public InputSimulator sim = new InputSimulator();
        public int DefaultDelay = 0;
        public bool UseDirectKeyMode;
        public int DefaultKeystrokeDelay = 5;

        public static VirtualKeyCode StringToVirtualKeyCode(string value)
        {
            try
            {
                return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), value);
            }
            catch (Exception)
            {
                try
                {
                    return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), "VK_" + value.ToUpper());
                }
                catch (Exception)
                {
                }
                if (String.Equals(value, ";", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_1;
                if (String.Equals(value, "+", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_PLUS;
                if (String.Equals(value, ",", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_COMMA;
                if (String.Equals(value, "-", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_MINUS;
                if (String.Equals(value, ".", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_PERIOD;
                if (String.Equals(value, "/", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_2;
                if (String.Equals(value, "`", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_3;
                if (String.Equals(value, "[", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_4;
                if (String.Equals(value, "\\", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_5;
                if (String.Equals(value, "]", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_6;
                if (String.Equals(value, "'", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_7;
                if (String.Equals(value, "ENTER", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.RETURN;
                if (String.Equals(value, "BREAK", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.PAUSE;
                if (String.Equals(value, "CAPS", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, "CAPSLOCK", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.CAPITAL;
                if (String.Equals(value, "ESC", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.ESCAPE;
                if (String.Equals(value, "PAGEUP", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.PRIOR;
                if (String.Equals(value, "PAGEDOWN", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.NEXT;
                if (String.Equals(value, "PRINTSCREEN", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.SNAPSHOT;
                if (String.Equals(value, "SCROLLLOCK", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.SCROLL;
                if (String.Equals(value, "WINDOWS", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, "GUI", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.LWIN;
                if (String.Equals(value, "LEFTARROW", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.LEFT;
                if (String.Equals(value, "UPARROW", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.UP;
                if (String.Equals(value, "RIGHTARROW", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.RIGHT;
                if (String.Equals(value, "DOWNARROW", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.DOWN;
                if (String.Equals(value, "MENU", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, "APP", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.APPS;
                if (String.Equals(value, "SYSTEMPOWER", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.OEM_8;
                if (String.Equals(value, "SYSTEMSLEEP", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.SLEEP;
                if (String.Equals(value, "STOP", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.MEDIA_STOP;
                if (String.Equals(value, "PLAY", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.MEDIA_PLAY_PAUSE;
                if (String.Equals(value, "MUTE", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.VOLUME_MUTE;
                if (String.Equals(value, "VOLUMEUP", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.VOLUME_UP;
                if (String.Equals(value, "VOLUMEDOWN", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.VOLUME_DOWN;
                if (String.Equals(value, "DEL", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.DELETE;
                if (String.Equals(value, " ", StringComparison.OrdinalIgnoreCase))
                    return VirtualKeyCode.SPACE;
                if (String.Equals(value, "COMMAND", StringComparison.OrdinalIgnoreCase)) // TODO: OSX "Command" key
                    return VirtualKeyCode.LWIN;
                throw;
            }
        }

        public static DirectInputKeyCode StringToDirectInputKeyCode(string value)
        {
            try
            {
                return (DirectInputKeyCode)Enum.Parse(typeof(DirectInputKeyCode), value);
            }
            catch (Exception)
            {
                try
                {
                    return (DirectInputKeyCode)Enum.Parse(typeof(DirectInputKeyCode), "DIK_" + value.ToUpper());
                }
                catch (Exception)
                {
                }
                if (String.Equals(value, ";", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_SEMICOLON;
                if (String.Equals(value, "+", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_EQUALS;
                if (String.Equals(value, ",", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_COMMA;
                if (String.Equals(value, "-", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_MINUS;
                if (String.Equals(value, ".", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_PERIOD;
                if (String.Equals(value, "/", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_SLASH;
                if (String.Equals(value, "`", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_GRAVE;
                if (String.Equals(value, "[", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_LBRACKET;
                if (String.Equals(value, "\\", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_BACKSLASH;
                if (String.Equals(value, "]", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_RBRACKET;
                if (String.Equals(value, "'", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_APOSTROPHE;
                if (String.Equals(value, "ENTER", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_RETURN;
                if (String.Equals(value, "BREAK", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_PAUSE;
                if (String.Equals(value, "CAPS", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, "CAPSLOCK", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_CAPITAL;
                if (String.Equals(value, "ESC", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_ESCAPE;
                if (String.Equals(value, "PAGEUP", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_PRIOR;
                if (String.Equals(value, "PAGEDOWN", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_NEXT;
                if (String.Equals(value, "SCROLLLOCK", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_SCROLL;
                if (String.Equals(value, "WINDOWS", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, "GUI", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_LWIN;
                if (String.Equals(value, "LEFTARROW", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_LEFT;
                if (String.Equals(value, "UPARROW", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_UP;
                if (String.Equals(value, "RIGHTARROW", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_RIGHT;
                if (String.Equals(value, "DOWNARROW", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_DOWN;
                if (String.Equals(value, "MENU", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, "APP", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_APPS;
                if (String.Equals(value, "SYSTEMPOWER", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_POWER;
                if (String.Equals(value, "SYSTEMSLEEP", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_SLEEP;
                if (String.Equals(value, "DEL", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_DELETE;
                if (String.Equals(value, " ", StringComparison.OrdinalIgnoreCase))
                    return DirectInputKeyCode.DIK_SPACE;
                if (String.Equals(value, "COMMAND", StringComparison.OrdinalIgnoreCase)) // TODO: OSX "Command" key
                    return DirectInputKeyCode.DIK_LWIN;
                throw;
            }
        }

        internal abstract class Command
        {
            public abstract void Run(DuckyScript d);
        }

        internal class DelayCommand : Command
        {
            int ms;

            public DelayCommand(int ms)
            {
                this.ms = ms;
            }

            public override void Run(DuckyScript d)
            {
                d.sim.Keyboard.Sleep(ms);
            }

            public override string ToString()
            {
                return String.Format("DELAY {0}", ms);
            }
        }

        internal class StringCommand : Command
        {
            string s;

            public StringCommand(string s)
            {
                this.s = s;
            }

            public override void Run(DuckyScript d)
            {
                d.sim.Keyboard.TextEntry(s);
            }

            public override string ToString()
            {
                return String.Format("STRING {0}", s);
            }
        }

        internal class DirectStringCommand : Command
        {
            string s;
            int KeystrokeDelay;

            public DirectStringCommand(string s, int KeystrokeDelay)
            {
                this.s = s;
                this.KeystrokeDelay = KeystrokeDelay;
            }

            public override void Run(DuckyScript d)
            {
                foreach (char c in s)
                {
                    short result = NativeMethods.VkKeyScan(c);
                    uint keyCode = (uint)result & 0xFF;
                    var modifiers = new List<DirectInputKeyCode>();
                    if ((result & 0x0100) != 0)
                        modifiers.Add(DirectInputKeyCode.DIK_LSHIFT);
                    if ((result & 0x0200) != 0)
                        modifiers.Add(DirectInputKeyCode.DIK_LCONTROL);
                    if ((result & 0x0400) != 0)
                        modifiers.Add(DirectInputKeyCode.DIK_LALT);
                    if ((result & 0x0800) != 0)
                        // TODO: What is the key code for the hankaku key? Possibilities DIK_CONVERT, DIK_NOCONVERT, DIK_KANA, DIK_KANJI
                        ;
                    DirectInputKeyCode kc = (DirectInputKeyCode)NativeMethods.MapVirtualKey(keyCode, NativeMethods.MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC);
                    d.sim.Keyboard.ModifiedKeyStroke(modifiers, kc);
                    System.Threading.Thread.Sleep(KeystrokeDelay);
                }
            }

            public override string ToString()
            {
                return String.Format("STRING {0}", s);
            }
        }

        internal class KeyPressCommand : Command
        {
            IEnumerable<VirtualKeyCode> modifiers;
            VirtualKeyCode key;

            public KeyPressCommand(IEnumerable<VirtualKeyCode> modifiers, VirtualKeyCode key)
            {
                this.modifiers = modifiers;
                this.key = key;
            }

            public KeyPressCommand(IEnumerable<VirtualKeyCode> modifiers, string arg)
                : this(modifiers, StringToVirtualKeyCode(arg))
            {
            }

            public KeyPressCommand(VirtualKeyCode modifierKeyCode, string arg)
                : this(new VirtualKeyCode[] { modifierKeyCode }, StringToVirtualKeyCode(arg))
            {
            }

            public KeyPressCommand(VirtualKeyCode keyCode)
                : this(null, keyCode)
            {
            }

            public override void Run(DuckyScript d)
            {
                if ((modifiers == null) || (modifiers.Count() == 0))
                    d.sim.Keyboard.KeyPress(key);
                else
                    d.sim.Keyboard.ModifiedKeyStroke(modifiers, key);
            }

            public override string ToString()
            {
                if ((modifiers == null) || (modifiers.Count() == 0))
                {
                    return String.Format("{0}", key.ToString());
                }
                else
                {
                    return String.Format("{0} {1}", String.Join("-", modifiers), key.ToString());
                }
            }
        }

        internal class DirectKeyPressCommand : Command
        {
            IEnumerable<DirectInputKeyCode> modifiers;
            DirectInputKeyCode key;

            public DirectKeyPressCommand(IEnumerable<DirectInputKeyCode> modifiers, DirectInputKeyCode key)
            {
                this.modifiers = modifiers;
                this.key = key;
            }

            public DirectKeyPressCommand(IEnumerable<DirectInputKeyCode> modifiers, string arg)
                : this(modifiers, StringToDirectInputKeyCode(arg))
            {
            }

            public DirectKeyPressCommand(DirectInputKeyCode modifierKeyCode, string arg)
                : this(new DirectInputKeyCode[] { modifierKeyCode }, StringToDirectInputKeyCode(arg))
            {
            }

            public DirectKeyPressCommand(DirectInputKeyCode keyCode)
                : this(null, keyCode)
            {
            }

            public override void Run(DuckyScript d)
            {
                if ((modifiers == null) || (modifiers.Count() == 0))
                    d.sim.Keyboard.KeyPress(key);
                else
                    d.sim.Keyboard.ModifiedKeyStroke(modifiers, key);
            }

            public override string ToString()
            {
                if ((modifiers == null) || (modifiers.Count() == 0))
                {
                    return String.Format("{0}", key.ToString());
                }
                else
                {
                    return String.Format("{0} {1}", String.Join("-", modifiers), key.ToString());
                }
            }
        }

        internal class DefaultDelayCommand : Command
        {
            int ms;

            public DefaultDelayCommand(int ms)
            {
                this.ms = ms;
            }

            public override void Run(DuckyScript d)
            {
                d.DefaultDelay = ms;
            }

            public override string ToString()
            {
                return String.Format("DEFAULTDELAY {0}", ms);
            }
        }

        internal class RepeatCommand : Command
        {
            Command command;
            int count;
            public RepeatCommand(Command command, int count)
            {
                this.command = command;
                this.count = count;
            }

            public override void Run(DuckyScript d)
            {
                for (int i = 0; i < count; ++i)
                    command.Run(d);
            }

            public override string ToString()
            {
                return String.Format("REPEAT {0}", count);
            }
        }

        public Command ParseCommand(string line)
        {
            string[] a = line.Split(null);
            if ((a == null) || (a.Length == 0) || (a[0].Length == 0))
                return null;
            if (String.Equals(a[0], "REM", StringComparison.OrdinalIgnoreCase))
                return null;
            if (String.Equals(a[0], "DEFAULTDELAY", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(a[0], "DEFAULT_DELAY", StringComparison.OrdinalIgnoreCase))
            {
                if (a.Length < 2)
                {
                    Console.WriteLine("Error: {0} needs an argument", a[0]);
                    return null;
                }
                return new DefaultDelayCommand(int.Parse(a[1]));
            }
            if (String.Equals(a[0], "DELAY", StringComparison.OrdinalIgnoreCase))
            {
                if (a.Length < 2)
                {
                    Console.WriteLine("Error: {0} needs an argument", a[0]);
                    return null;
                }
                return new DelayCommand(int.Parse(a[1]));
            }
            if (String.Equals(a[0], "STRING", StringComparison.OrdinalIgnoreCase))
            {
                string arg = line.Substring(7);
                if (UseDirectKeyMode)
                    return new DirectStringCommand(arg, DefaultKeystrokeDelay);
                else
                    return new StringCommand(arg);
            }
            if (String.Equals(a[0], "GUI", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(a[0], "WINDOWS", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LWIN);
                    else
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LWIN, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(VirtualKeyCode.LWIN);
                    else
                        return new KeyPressCommand(VirtualKeyCode.LWIN, a[1]);
                }
            }
            if (String.Equals(a[0], "APP", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(a[0], "MENU", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_APPS);
                    else
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_APPS, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(VirtualKeyCode.APPS);
                    else
                        return new KeyPressCommand(VirtualKeyCode.APPS, a[1]);
                }
            }
            if (String.Equals(a[0], "SHIFT", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LSHIFT);
                    else
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LSHIFT, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(VirtualKeyCode.LSHIFT);
                    else
                        return new KeyPressCommand(VirtualKeyCode.LSHIFT, a[1]);
                }
            }
            if (String.Equals(a[0], "ALT", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LMENU);
                    else
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LMENU, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(VirtualKeyCode.LMENU);
                    else
                        return new KeyPressCommand(VirtualKeyCode.LMENU, a[1]);
                }
            }
            if (String.Equals(a[0], "CONTROL", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(a[0], "CTRL", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LCONTROL);
                    else
                        return new DirectKeyPressCommand(DirectInputKeyCode.DIK_LCONTROL, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(VirtualKeyCode.LCONTROL);
                    else
                        return new KeyPressCommand(VirtualKeyCode.LCONTROL, a[1]);
                }
            }
            if (String.Equals(a[0], "ALT-SHIFT", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(new DirectInputKeyCode[] { DirectInputKeyCode.DIK_LMENU }, DirectInputKeyCode.DIK_LSHIFT);
                    else
                        return new DirectKeyPressCommand(new DirectInputKeyCode[] { DirectInputKeyCode.DIK_LMENU, DirectInputKeyCode.DIK_LSHIFT }, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(new VirtualKeyCode[] { VirtualKeyCode.LMENU }, VirtualKeyCode.LSHIFT);
                    else
                        return new KeyPressCommand(new VirtualKeyCode[] { VirtualKeyCode.LMENU, VirtualKeyCode.LSHIFT }, a[1]);
                }
            }
            if (String.Equals(a[0], "CTRL-ALT", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(a[0], "CONTROL-ALT", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(new DirectInputKeyCode[] { DirectInputKeyCode.DIK_LCONTROL }, DirectInputKeyCode.DIK_LALT);
                    else
                        return new DirectKeyPressCommand(new DirectInputKeyCode[] { DirectInputKeyCode.DIK_LCONTROL, DirectInputKeyCode.DIK_LALT }, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(new VirtualKeyCode[] { VirtualKeyCode.LCONTROL }, VirtualKeyCode.LMENU);
                    else
                        return new KeyPressCommand(new VirtualKeyCode[] { VirtualKeyCode.LCONTROL, VirtualKeyCode.LMENU }, a[1]);
                }
            }
            if (String.Equals(a[0], "CTRL-SHIFT", StringComparison.OrdinalIgnoreCase) ||
                String.Equals(a[0], "CONTROL-SHIFT", StringComparison.OrdinalIgnoreCase))
            {
                if (UseDirectKeyMode)
                {
                    if (a.Length == 1)
                        return new DirectKeyPressCommand(new DirectInputKeyCode[] { DirectInputKeyCode.DIK_LCONTROL }, DirectInputKeyCode.DIK_LSHIFT);
                    else
                        return new DirectKeyPressCommand(new DirectInputKeyCode[] { DirectInputKeyCode.DIK_LCONTROL, DirectInputKeyCode.DIK_LSHIFT }, a[1]);
                }
                else
                {
                    if (a.Length == 1)
                        return new KeyPressCommand(new VirtualKeyCode[] { VirtualKeyCode.LCONTROL }, VirtualKeyCode.LSHIFT);
                    else
                        return new KeyPressCommand(new VirtualKeyCode[] { VirtualKeyCode.LCONTROL, VirtualKeyCode.LSHIFT }, a[1]);
                }
            }
            if (String.Equals(a[0], "REPEAT", StringComparison.OrdinalIgnoreCase))
            {
                if (a.Length < 2)
                {
                    Console.WriteLine("Error: {0} needs an argument", a[0]);
                    return null;
                }
                if (commands.Count == 0)
                {
                    Console.WriteLine("Error: {0} needs a previous command", a[0]);
                    return null;
                }
                return new RepeatCommand(commands[commands.Count - 1], int.Parse(a[1]));
            }
            // TODO: SYSTEMPOWER
            // TODO: SYSTEMSLEEP
            // TODO: SYSTEMWAKE
            if (String.Equals(a[0], "PAUSE", StringComparison.OrdinalIgnoreCase))
            {
                return new KeyPressCommand(VirtualKeyCode.MEDIA_PLAY_PAUSE);
            }
            if (String.Equals(a[0], "DIRECTINPUT", StringComparison.OrdinalIgnoreCase))
            {
                if (a.Length < 2)
                {
                    Console.WriteLine("Error: {0} needs an argument", a[0]);
                    return null;
                }
                UseDirectKeyMode =
                    String.Equals(a[1], "on", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(a[1], "true", StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(a[1], "1", StringComparison.OrdinalIgnoreCase);
                return null;
            }
            try
            {
                VirtualKeyCode k = StringToVirtualKeyCode(a[0]);
                return new KeyPressCommand(k);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown command {0}", line);
                return null;
            }
        }

        public DuckyScript()
        {
        }

        public DuckyScript(string filename, bool UseDirectKeyMode)
        {
            this.UseDirectKeyMode = UseDirectKeyMode;
            using (var r = new System.IO.StreamReader(filename))
            {
                Parse(r);
            }
        }

        public DuckyScript(System.IO.Stream stream, bool UseDirectKeyMode)
        {
            this.UseDirectKeyMode = UseDirectKeyMode;
            using (var r = new System.IO.StreamReader(stream))
            {
                Parse(r);
            }
        }

        public void Parse(System.IO.StreamReader file)
        {
            commands = new List<Command>();
            DefaultDelay = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                Command c = ParseCommand(line);
                if (c != null)
                {
                    commands.Add(c);
                }
            }
        }

        public delegate void ProgressDelegate(string message);

        public void Run(ProgressDelegate d)
        {
            DateTime start = DateTime.Now;
            foreach (Command c in commands)
            {
                if (d != null)
                {
                    d(String.Format("{0:0.000}: {1}\r\n", (DateTime.Now - start).TotalSeconds, c.ToString()));
                }
                c.Run(this);
                if (DefaultDelay != 0)
                    System.Threading.Thread.Sleep(DefaultDelay);
            }
        }

    }
}
