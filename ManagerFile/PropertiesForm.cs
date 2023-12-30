using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerFile
{
    public partial class PropertiesForm : Form
    {
        public string filePath { get; set; }

        public PropertiesForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Hàm nhận dữ liệu từ listview
        /// </summary>
        /// <param name="lstFileRename"></param>
        public void SetData(List<string> lstFileRename)
        {
            filePath = lstFileRename.FirstOrDefault();
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                txtName.Text = fileInfo.Name;
                txtSizeBytes.Text = fileInfo.Length.ToString();
                txtSizeMb.Text = ConvertBytesToMegabytes(fileInfo.Length).ToString();
                txtDate.Text = fileInfo.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

                long totalSizeBytes = 0;

                // Lấy danh sách tất cả các tệp trong thư mục
                string[] files = Directory.GetFiles(filePath);

                // Tính tổng kích thước của tất cả các tệp
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    totalSizeBytes += fileInfo.Length;
                }

                txtName.Text = directoryInfo.Name;
                txtSizeBytes.Text = totalSizeBytes.ToString();
                txtSizeMb.Text = ConvertBytesToMegabytes(totalSizeBytes).ToString();
                txtDate.Text = directoryInfo.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        /// <summary>
        /// convert bytes to MB
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private double ConvertBytesToMegabytes(long bytes)
        {
            return (long)Math.Round((double)bytes / (1024 * 1024));
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
