using ManagerFile.Helper;
using System.Diagnostics;
using System.IO;

namespace ManagerFile
{
    public class VirusScanner
    {
        private readonly string mpcmdrunLocation;
        public VirusScanner(string mpcmdrunLocation)
        {
            if (!File.Exists(mpcmdrunLocation))
            {
                throw new FileNotFoundException();
            }

            this.mpcmdrunLocation = new FileInfo(mpcmdrunLocation).FullName;
        }
        /// <summary>
        /// Scan a single file
        /// </summary>
        /// <param name="file">The file to scan</param>
        /// <param name="timeoutInMs">The maximum time in milliseconds to take for this scan</param>
        /// <returns>The scan result</returns>
        public ScanResult Scan(string path, int timeoutInMs = 30000)
        {
            if (File.Exists(path))
            {
                // Nếu là một tệp, quét tệp đó
                return ScanFile(path, timeoutInMs);
            }
            else if (Directory.Exists(path))
            {
                // Nếu là một thư mục, duyệt qua từng tệp trong thư mục và quét
                var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    var result = ScanFile(file, timeoutInMs);

                    // Nếu phát hiện mối đe dọa, ngừng và trả về kết quả
                    if (result == ScanResult.ThreatFound)
                    {
                        return ScanResult.ThreatFound;
                    }
                }

                // Nếu không có mối đe dọa nào được phát hiện
                return ScanResult.NoThreatFound;
            }
            else
            {
                // Nếu không phải là tệp hoặc thư mục tồn tại, trả về lỗi
                return ScanResult.FileNotFound;
            }
        }

        private ScanResult ScanFile(string file, int timeoutInMs = 30000)
        {
            var fileInfo = new FileInfo(file);

            var process = new Process();

            var startInfo = new ProcessStartInfo(this.mpcmdrunLocation)
            {
                Arguments = $"-Scan -ScanType 3 -File \"{fileInfo.FullName}\" -DisableRemediation",
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false
            };

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit(timeoutInMs);

            if (!process.HasExited)
            {
                process.Kill();
                return ScanResult.Timeout;
            }

            switch (process.ExitCode)
            {
                case 0:
                    return ScanResult.NoThreatFound;
                case 2:
                    return ScanResult.ThreatFound;
                default:
                    return ScanResult.Error;
            }
        }

    }
}
