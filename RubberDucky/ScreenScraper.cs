using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace RubberDucky
{
    public class ScreenScraper
    {
        public static void GrabScreenshot(IntPtr windowHandle, string fileName)
        {
            NativeMethods.RectStruct rect;
            NativeMethods.GetWindowRect(windowHandle, out rect);
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(rect.Left, rect.Top), Point.Empty, new Size(width, height));
                }
                bitmap.Save(fileName, ImageFormat.Bmp);
            }
        }

        public static Result ReadQRCode(IntPtr windowHandle)
        {
            NativeMethods.RectStruct rect;
            NativeMethods.GetWindowRect(windowHandle, out rect);
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    int x = rect.Left;
                    int y = rect.Top;
                    g.CopyFromScreen(new Point(x, y), Point.Empty, new Size(width, height));
                }
                LuminanceSource source = new BitmapLuminanceSource(bitmap);
                var reader = new BarcodeReader();
                reader.AutoRotate = true;
                reader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE };
                reader.Options.Hints.Add(DecodeHintType.TRY_HARDER, true);
                return reader.Decode(source);
            }
        }
    }
}
