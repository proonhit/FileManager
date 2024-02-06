using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Windows.Forms;

namespace ManagerFile
{
    public static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public static string driveLetter { get; set; } 

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
            // Bắt lỗi toàn cục
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;

            // Ghi log vào file văn bản
            LogExceptionToFile(exception, "error_log.txt");

            // Hiển thị thông báo cho người dùng (nếu cần)
            MessageBox.Show("An unexpected error occurred. Please check the log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void LogExceptionToFile(Exception exception, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {exception.GetType().FullName}: {exception.Message}");
                    writer.WriteLine(exception.StackTrace);
                    writer.WriteLine();
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi khi ghi log (nếu cần)
            }
        }

        /// <summary>
        /// Xóa tên của ổ
        /// </summary>
        private static void RemoveLetter()
        {
            try
            {
                //Publish USB
                //driveLetter = GetDiskForData();

                driveLetter = "F:"; // Thay thế "D:" bằng chữ cái của ổ đĩa bạn muốn xóa.

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
                // Xử lý các ngoại lệ nếu có
                LogExceptionToFile(ex, "error_log.txt");
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

        public static string GetDiskForData()
        {
            var DiskCurrent = AppDomain.CurrentDomain.BaseDirectory;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Volume WHERE DriveType=2");
            List<string> lstMountInfo = new List<string>();
            foreach (ManagementObject disk in searcher.Get())
            {
                string volumeName = disk["Name"] as string;

                lstMountInfo.Add(volumeName);
            }

            var DiskData = lstMountInfo.Where(s => s != DiskCurrent).FirstOrDefault();

            return DiskData;
        }
    }
}
