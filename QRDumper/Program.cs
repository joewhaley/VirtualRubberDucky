using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRDumper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string filename;
            if (args.Length < 1)
                filename = @"C:\Windows\notepad.exe";
            else
                filename = args[0];
            int bytesPerFrame = 256;
            if (args.Length == 2)
                bytesPerFrame = int.Parse(args[1]);
            Application.Run(new QRDumper(filename, bytesPerFrame));
        }
    }
}
