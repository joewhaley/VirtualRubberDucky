using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace QRDumper
{
    public partial class QRDumper : Form
    {
        Stream fs;
        byte[] buffer;
        uint frameNumber;
        Random random;

        public QRDumper(string path, int bytesPerFrame)
        {
            InitializeComponent();
            random = new Random();
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            buffer = new byte[bytesPerFrame];
            frameNumber = 0;
            WriteQRCode();
        }

        public bool WriteQRCode()
        {
            buffer[0] = (byte)(frameNumber & 0xFF);
            buffer[1] = (byte)((frameNumber >> 8) & 0xFF);
            buffer[2] = (byte)((frameNumber >> 16) & 0xFF);
            fs.Seek(frameNumber * (buffer.Length - 4), SeekOrigin.Begin);
            int bytes = fs.Read(buffer, 4, buffer.Length - 4);
            if (bytes == 0)
                return false;
            bool hasMore = (fs.Position < fs.Length);
            buffer[3] = (byte)random.Next();
            if (hasMore)
                buffer[3] |= 1;
            else
                buffer[3] &= 0xfe;
            string b64 = Convert.ToBase64String(buffer, 0, bytes+4);
            DisplayQRCode(b64);
            frameLabel.Text = String.Format("Frame #{0}: {1}", frameNumber, bytes);
            return true;
        }

        private void DisplayQRCode(string data)
        {
            if (data.Length == 0)
                return;
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = pictureBox.Height,
                    Width = pictureBox.Width
                }
            };
            pictureBox.Image = writer.Write(data);
        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'n')
            {
                ++frameNumber;
                if (!WriteQRCode())
                    --frameNumber;
            }
            else if (e.KeyChar == 'p')
            {
                if (frameNumber > 0)
                {
                    --frameNumber;
                    WriteQRCode();
                }
            }
            else if (e.KeyChar == 'r')
            {
                WriteQRCode();
            }
            else if (e.KeyChar == 'q')
            {
                Application.Exit();
            }
        }

        private void onResize(object sender, EventArgs e)
        {
            WriteQRCode();
        }
    }
}
