using ManagerFile.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ManagerFile
{
    public partial class Default : Form
    {
        private Stack<string> folderStack = new Stack<string>();
        public int test { get; set; }
        public string selectedPath { get; set; }
        public string selectedPathUsb { get; set; }
        public Default()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Load my computer
            ddlDisk.Items.Add("Desktop");
            ddlDisk.Items.Add("My Documents");
            ddlDisk.SelectedItem = "Desktop";
            ListNonUsbDrives();

            listDesktop.View = View.Details;
            lstUsb.View = View.Details;

            DriveInfo[] drives = DriveInfo.GetDrives();

            var objUsb = drives.Where(s => s.DriveType != DriveType.Fixed).FirstOrDefault();

            txtUsb.Text = objUsb.RootDirectory.FullName;

            LoadFoldersUsb(objUsb.RootDirectory.FullName);
            selectedPathUsb = objUsb.RootDirectory.FullName;

        }

        private void ListNonUsbDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                // Kiểm tra xem ổ đĩa có phải là USB hay không
                if (drive.DriveType == DriveType.Fixed)
                {
                    // Sử dụng VolumeLabel nếu có, nếu không sử dụng tên ổ đĩa
                    string driveName = string.IsNullOrEmpty(drive.VolumeLabel) ? drive.Name : drive.VolumeLabel;
                    ddlDisk.Items.Add(driveName);
                }

            }
        }

        static bool IsInternetConnected()
        {
            try
            {
                Ping myPing = new Ping();
                // Kiểm tra kết nối đến một địa chỉ IP có thể truy cập được (Ví dụ: Google DNS)
                PingReply reply = myPing.Send("8.8.8.8", 1000);

                if (reply != null && reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (PingException)
            {
                // Xử lý ngoại lệ nếu có lỗi khi thực hiện kiểm tra
            }

            return false;
        }

        private void ddlDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPath = ddlDisk.SelectedItem.ToString();

            switch (selectedPath)
            {
                case "Desktop":
                    selectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    break;
                case "My Documents":
                    selectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
                default:
                    break;
            }

            txtFilepath.Text = selectedPath;
            LoadFolders(selectedPath);
        }


        private void Default_Load(object sender, EventArgs e)
        {


        }

        private void LoadFolders(string folderPath)
        {
            // Xóa tất cả các mục cũ trong ListView
            listDesktop.Items.Clear();

            try
            {
                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(15, 15);
                imageList.Images.Add("folder", Properties.Resources.folder);
                imageList.Images.Add("excel", Properties.Resources.excel);
                imageList.Images.Add("pdf", Properties.Resources.pdf);
                imageList.Images.Add("powerpoint", Properties.Resources.powerpoint);
                imageList.Images.Add("txt", Properties.Resources.txt);
                imageList.Images.Add("unknown", Properties.Resources.unknown);
                imageList.Images.Add("word", Properties.Resources.word);
                imageList.Images.Add("return", Properties.Resources._return);

                if (folderStack.Count > 0)
                {
                    var currentpath = CheckPathTheoOption(ddlDisk.Text);

                    if (folderPath == currentpath)
                    {

                    }
                    else
                    {
                        ListViewItem backItem = new ListViewItem();
                        backItem.ImageKey = "return";
                        backItem.SubItems.Add("...");
                        backItem.SubItems.Add("");
                        backItem.SubItems.Add("");
                        backItem.SubItems.Add("");
                        listDesktop.Items.Add(backItem);
                        listDesktop.SmallImageList = imageList;
                    }
                }

                // Lấy danh sách folder và file từ đường dẫn
                string[] items = Directory.GetFileSystemEntries(folderPath);
                txtFilepath.Text = folderPath;
                foreach (string item in items)
                {
                    if (Directory.Exists(item))
                    {
                        // Tạo ListViewItem mới với tên folder hoặc file là Text của item
                        ListViewItem listViewItem = new ListViewItem(Path.GetFileName(item));
                        string dateModified = File.GetLastWriteTime(item).ToString("dd/MM/yyyy HH:mm:ss");
                        // Gán biểu tượng của folder cho ListViewItem
                        listViewItem.ImageKey = "folder";
                        listViewItem.SubItems.Add("");
                        listViewItem.SubItems.Add("");
                        listViewItem.SubItems.Add(dateModified);
                        // Thêm item vào ListView
                        listDesktop.Items.Add(listViewItem);
                        listDesktop.SmallImageList = imageList;
                    }
                }

                // Thêm mỗi folder và file vào ListView
                foreach (string item in items)
                {
                    // Kiểm tra nếu là file
                    if (File.Exists(item))
                    {
                        ListViewItem listViewItem = new ListViewItem(Path.GetFileName(item));
                        // Lấy thông tin về loại, kích thước và ngày sửa đổi
                        string type = Path.GetExtension(item);
                        long sizeInBytes = new FileInfo(item).Length;
                        string size = FormatSize(sizeInBytes);
                        string dateModified = File.GetLastWriteTime(item).ToString("dd/MM/yyyy HH:mm:ss");

                        // Thêm các sub-items cho các cột Type, Size và Date Modified
                        listViewItem.ImageKey = GetKeyImageFile(type);
                        listViewItem.SubItems.Add(type);
                        listViewItem.SubItems.Add(size);
                        listViewItem.SubItems.Add(dateModified);
                        // Thêm item vào ListView
                        listDesktop.Items.Add(listViewItem);
                        listDesktop.SmallImageList = imageList;
                    }
                }

                folderStack.Push(folderPath);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu có
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadFoldersUsb(string folderPath)
        {
            lstUsb.Items.Clear();

            try
            {
                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(15, 15);
                imageList.Images.Add("folder", Properties.Resources.folder);
                imageList.Images.Add("excel", Properties.Resources.excel);
                imageList.Images.Add("pdf", Properties.Resources.pdf);
                imageList.Images.Add("powerpoint", Properties.Resources.powerpoint);
                imageList.Images.Add("txt", Properties.Resources.txt);
                imageList.Images.Add("unknown", Properties.Resources.unknown);
                imageList.Images.Add("word", Properties.Resources.word);
                imageList.Images.Add("return", Properties.Resources._return);


                // Lấy danh sách folder và file từ đường dẫn
                string[] items = Directory.GetFileSystemEntries(folderPath);
                txtUsb.Text = folderPath;
                foreach (string item in items)
                {
                    if (Directory.Exists(item))
                    {
                        // Tạo ListViewItem mới với tên folder hoặc file là Text của item
                        ListViewItem listViewItem = new ListViewItem(Path.GetFileName(item));
                        string dateModified = File.GetLastWriteTime(item).ToString("dd/MM/yyyy HH:mm:ss");
                        // Gán biểu tượng của folder cho ListViewItem
                        listViewItem.ImageKey = "folder";
                        listViewItem.SubItems.Add("");
                        listViewItem.SubItems.Add("");
                        listViewItem.SubItems.Add(dateModified);
                        // Thêm item vào ListView
                        lstUsb.Items.Add(listViewItem);
                        lstUsb.SmallImageList = imageList;
                    }
                }

                // Thêm mỗi folder và file vào ListView
                foreach (string item in items)
                {
                    // Kiểm tra nếu là file
                    if (File.Exists(item))
                    {
                        ListViewItem listViewItem = new ListViewItem(Path.GetFileName(item));
                        // Lấy thông tin về loại, kích thước và ngày sửa đổi
                        string type = Path.GetExtension(item);
                        long sizeInBytes = new FileInfo(item).Length;
                        string size = FormatSize(sizeInBytes);
                        string dateModified = File.GetLastWriteTime(item).ToString("dd/MM/yyyy HH:mm:ss");

                        // Thêm các sub-items cho các cột Type, Size và Date Modified
                        listViewItem.ImageKey = GetKeyImageFile(type);
                        listViewItem.SubItems.Add(type);
                        listViewItem.SubItems.Add(size);
                        listViewItem.SubItems.Add(dateModified);
                        // Thêm item vào ListView
                        lstUsb.Items.Add(listViewItem);
                        lstUsb.SmallImageList = imageList;
                    }
                }

            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu có
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listDesktop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem có item nào được chọn không
            if (listDesktop.SelectedItems.Count > 0)
            {
                // Lấy item được chọn
                ListViewItem selectedFolder = listDesktop.SelectedItems[0];

                // Lấy tên folder từ Text của item
                string folderName = selectedFolder.Text;

                if (string.IsNullOrEmpty(folderName))
                {
                    string fullPath = Directory.GetParent(Path.Combine(selectedPath + "/" + folderName)).Parent.FullName;
                    // Kiểm tra xem đây có phải là một folder không
                    if (Directory.Exists(fullPath))
                    {
                        // Sau khi mở folder, load danh sách các folder trong đó lên ListView
                        LoadFolders(fullPath);
                    }
                    selectedPath = fullPath;
                }
                else
                {

                    // Lấy đường dẫn đầy đủ của folder
                    string fullPath = Path.Combine(selectedPath + "/" + folderName);

                    // Kiểm tra xem đây có phải là một folder không
                    if (Directory.Exists(fullPath))
                    {
                        // Sau khi mở folder, load danh sách các folder trong đó lên ListView
                        LoadFolders(fullPath);
                    }
                    else
                    {
                        if (File.Exists(fullPath))
                        {
                            // Thực hiện các hành động khi double click vào file
                            try
                            {
                                System.Diagnostics.Process.Start(fullPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error opening file: " + ex.Message);
                            }
                        }
                    }

                    selectedPath = selectedPath + "/" + folderName;
                }

            }
        }

        private void lstUsb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstUsb.SelectedItems.Count > 0)
            {
                // Lấy item được chọn
                ListViewItem selectedFolder = lstUsb.SelectedItems[0];

                // Lấy tên folder từ Text của item
                string folderName = selectedFolder.Text;

                if (string.IsNullOrEmpty(folderName))
                {
                    string fullPath = Directory.GetParent(Path.Combine(selectedPathUsb + "/" + folderName)).Parent.FullName;
                    // Kiểm tra xem đây có phải là một folder không
                    if (Directory.Exists(fullPath))
                    {
                        // Sau khi mở folder, load danh sách các folder trong đó lên ListView
                        LoadFoldersUsb(fullPath);
                    }
                    selectedPathUsb = fullPath;
                }
                else
                {

                    // Lấy đường dẫn đầy đủ của folder
                    string fullPath = Path.Combine(selectedPathUsb + "/" + folderName);

                    // Kiểm tra xem đây có phải là một folder không
                    if (Directory.Exists(fullPath))
                    {
                        // Sau khi mở folder, load danh sách các folder trong đó lên ListView
                        LoadFoldersUsb(fullPath);
                    }
                    else
                    {
                        if (File.Exists(fullPath))
                        {
                            // Thực hiện các hành động khi double click vào file
                            try
                            {
                                System.Diagnostics.Process.Start(fullPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error opening file: " + ex.Message);
                            }
                        }
                    }

                    selectedPathUsb = selectedPathUsb + "/" + folderName;
                }
            }
        }

        private string CheckPathTheoOption(string OptionSelected)
        {
            string selected = "";
            selected = ddlDisk.SelectedItem.ToString();

            switch (OptionSelected)
            {
                case "Desktop":
                    selected = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    break;
                case "My Documents":
                    selected = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
                default:
                    break;
            }

            return selected;
        }

        private string GetKeyImageFile(string file)
        {
            string result = "";

            switch (file)
            {
                case ".txt":
                    result = "txt";
                    break;

                case ".doc":
                    result = "word";
                    break;

                case ".xlsx":
                    result = "excel";
                    break;

                case ".xls":
                    result = "excel";
                    break;

                case ".pptx":
                    result = "powerpoint";
                    break;

                case ".pdf":
                    result = "pdf";
                    break;

                default:
                    result = "unknown";
                    break;
            }

            return result;
        }

        private string FormatSize(long sizeInBytes)
        {
            const long KB = 1024;
            const long MB = 1024 * KB;

            if (sizeInBytes >= MB)
            {
                return $"{(double)sizeInBytes / MB:N2} MB";
            }
            else if (sizeInBytes >= KB)
            {
                return $"{(double)sizeInBytes / KB:N2} KB";
            }
            else
            {
                return $"{sizeInBytes} B";
            }
        }


    }
}
