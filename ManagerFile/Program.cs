using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
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

        static string driveLetter = "M:"; // Thay thế "D:" bằng chữ cái của ổ đĩa bạn muốn xóa.

        [STAThread]
        static void Main()
        {
            if (!IsRunAsAdmin())
            {
                // Nếu không, khởi động lại với quyền quản trị
                RestartAsAdmin();
                return;
            }
            RemoveLetter();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }

        /// <summary>
        /// Xóa tên của ổ
        /// </summary>
        private static void RemoveLetter()
        {
            try
            {
                // Tạo một quy trình mới để thực hiện lệnh diskpart
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "diskpart";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    // Sử dụng lệnh diskpart để xóa chữ cái của ổ đĩa
                    process.StandardInput.WriteLine($"select volume {driveLetter.Substring(0, 1)}");
                    process.StandardInput.WriteLine("remove letter=" + driveLetter);
                    process.StandardInput.WriteLine("exit");

                    string output = process.StandardOutput.ReadToEnd();

                    Console.WriteLine(output);

                    process.WaitForExit();
                }

                Console.WriteLine($"Chữ cái {driveLetter} đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa chữ cái {driveLetter}: {ex.Message}");
            }
        }

        private static bool IsRunAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void RestartAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas"; // Chạy với quyền quản trị

            try
            {
                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // Người dùng từ chối cấp quyền quản trị
                // Có thể thực hiện xử lý phù hợp tại đây
            }

            Application.Exit();
        }
    }
}
