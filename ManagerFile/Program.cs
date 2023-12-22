using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace ManagerFile
{
    internal static class Program
    {   

        const uint DDD_REMOVE_DEFINITION = 0x2;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteVolumeMountPoint(string lpszVolumeMountPoint);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetVolumeMountPoint(string lpszVolumeMountPoint, string lpszVolumeName);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());

            #region Ẩn ổ USB
            // Xác định ổ đĩa USB
            //DriveInfo[] drives = DriveInfo.GetDrives();

            //foreach (DriveInfo drive in drives)
            //{
            //    if (drive.DriveType == DriveType.Removable)
            //    {
            //        // Ẩn ổ đĩa USB
            //        string usbDriveLetter = drive.Name;
            //        bool success = DeleteVolumeMountPoint(usbDriveLetter);
            //        if (success)
            //        {
            //            // Hiển thị Form1 hoặc thực hiện các bước tiếp theo...
            //            Application.EnableVisualStyles();
            //            Application.SetCompatibleTextRenderingDefault(false);
            //            Application.Run(new Form1());


            //            usbDriveLetter = "D:\\"; // Thay thế bằng ổ đĩa USB thực tế
            //            string shortcutPath = Path.Combine(usbDriveLetter, "MyApp.lnk");

            //            var shell = new WshShell();
            //            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            //            shortcut.TargetPath = Application.ExecutablePath;
            //            shortcut.Save();
            //        }
            //    }
            //}
            #endregion



        }
    }
}
