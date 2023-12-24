using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace ManagerFile
{
    public partial class Default : Form
    {
        private Stack<string> folderStack = new Stack<string>();
        private Stack<string> folderStackUsb = new Stack<string>();

        public string selectedPath { get; set; }
        public string selectedPathUsb { get; set; }
        //Lấy path khởi chạy của usb để phục vụ cho return
        public string FirstPathUsb { get; set; }
        //Biến để lưu dữ liệu đã chọn để rename
        public List<string> lv_mouseup_slt { get; set; }
        // Sự kiện refresh
        public event EventHandler RefreshListView;
        public Default()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Load my computer
            ddlDisk.Items.Add("Desktop");
            ddlDisk.Items.Add("My Documents");
            ddlDisk.SelectedItem = "Desktop";
            ListNonUsbDrives();

            lstDesktop.View = View.Details;
            lstUsb.View = View.Details;

            DriveInfo[] drives = DriveInfo.GetDrives();

            var objUsb = drives.Where(s => s.DriveType == DriveType.Fixed).LastOrDefault();

            txtUsb.Text = objUsb.RootDirectory.FullName;

            LoadFoldersUsb(objUsb.RootDirectory.FullName);
            selectedPathUsb = objUsb.RootDirectory.FullName;
            FirstPathUsb = selectedPathUsb;
            //Khởi tạo cho contextmenustrip
            InitContextMenuStrip();

        }

        /// <summary>
        /// Khởi tạo cho Context menu strip (Chuột phải)
        /// </summary>
        private void InitContextMenuStrip()
        {
            // Tạo ContextMenuStrip
            contextMenu = new ContextMenuStrip();

            // Thêm các menu item vào ContextMenuStrip
            ToolStripMenuItem renameMenuItem = new ToolStripMenuItem("Rename");
            renameMenuItem.Click += RenameMenuItem_Click;
            contextMenu.Items.Add(renameMenuItem);

            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteMenuItem);

            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copy");
            copyMenuItem.Click += CopyMenuItem_Click;
            contextMenu.Items.Add(copyMenuItem);

            ToolStripMenuItem viewMenuItem = new ToolStripMenuItem("View");
            viewMenuItem.Click += ViewMenuItem_Click;
            contextMenu.Items.Add(viewMenuItem);

            ToolStripMenuItem propertyMenuItem = new ToolStripMenuItem("Property");
            propertyMenuItem.Click += PropertyMenuItem_Click;
            contextMenu.Items.Add(propertyMenuItem);

        }

        /// <summary>
        /// Load option máy tính không chứa USB
        /// </summary>
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

        /// <summary>
        /// CHeck xem hệ thống có connect với mạng internet 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Onchange select của máy tính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            lstDesktop.View = View.Details;
        }

        private void Default_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Load listview của máy tính
        /// </summary>
        /// <param name="folderPath"></param>
        private void LoadFolders(string folderPath)
        {
            // Xóa tất cả các mục cũ trong ListView
            lstDesktop.Items.Clear();

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
                        lstDesktop.Items.Add(backItem);
                        lstDesktop.SmallImageList = imageList;
                        lstDesktop.LargeImageList = imageList;
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
                        lstDesktop.Items.Add(listViewItem);
                        lstDesktop.SmallImageList = imageList;
                        lstDesktop.LargeImageList = imageList;
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
                        lstDesktop.Items.Add(listViewItem);
                        lstDesktop.SmallImageList = imageList;
                        lstDesktop.LargeImageList = imageList;
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

        /// <summary>
        /// Load listview USB khi có filepath
        /// </summary>
        /// <param name="folderPath"></param>
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

                //Để check sự hiển thị của return file trước đó
                if (folderStackUsb.Count > 0)
                {
                    if (folderPath == FirstPathUsb) { }
                    else
                    {
                        ListViewItem backItem = new ListViewItem();
                        backItem.ImageKey = "return";
                        backItem.SubItems.Add("...");
                        backItem.SubItems.Add("");
                        backItem.SubItems.Add("");
                        backItem.SubItems.Add("");
                        lstUsb.Items.Add(backItem);
                        lstUsb.SmallImageList = imageList;
                        lstUsb.LargeImageList = imageList;
                    }
                }


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
                        lstUsb.LargeImageList = imageList;
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
                        lstUsb.LargeImageList = imageList;
                    }
                }

                folderStackUsb.Push(folderPath);

            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ nếu có
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Double click mở folder và file máy tính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDesktop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem có item nào được chọn không
            if (lstDesktop.SelectedItems.Count > 0)
            {
                // Lấy item được chọn
                ListViewItem selectedFolder = lstDesktop.SelectedItems[0];

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

        /// <summary>
        /// Double click mở folder và file usb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Lấy path theo option của máy tính
        /// </summary>
        /// <param name="OptionSelected"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Load logo theo từng loại fie
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Fomat size file thành KB
        /// </summary>
        /// <param name="sizeInBytes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sự kiện kéo file từ desktop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDesktop_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Bắt đầu quá trình kéo mục từ ListView1
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// Sự kiện khi kéo file vào usb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUsb_DragEnter(object sender, DragEventArgs e)
        {
            // Kiểm tra xem dữ liệu có thể được thả vào ListView hay không
            e.Effect = e.Data.GetDataPresent(typeof(ListViewItem)) ? DragDropEffects.Move : DragDropEffects.None;
        }

        /// <summary>
        /// Sự kiện thả file vào usb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUsb_DragDrop(object sender, DragEventArgs e)
        {
            // Nhận dữ liệu từ thả
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            // Lấy vị trí của con trỏ chuột khi thả
            Point clientPoint = lstUsb.PointToClient(new Point(e.X, e.Y));

            // Chuyển đổi vị trí chuột thành vị trí của mục trong ListView2
            ListViewItem targetItem = lstUsb.GetItemAt(clientPoint.X, clientPoint.Y);

            // Nếu không có mục nào được thả lên, thêm mục vào cuối ListView2
            if (targetItem == null)
            {
                lstUsb.Items.Add((ListViewItem)draggedItem.Clone());
            }
            else
            {
                // Ngược lại, chèn mục vào vị trí của mục đích
                int index = targetItem.Index;
                lstUsb.Items.Insert(index, (ListViewItem)draggedItem.Clone());
            }

            // Xóa mục được kéo từ ListView1
            lstDesktop.Items.Remove(draggedItem);

            // Thực hiện di chuyển file vật lý trong máy
            string sourceFilePath = Path.Combine(selectedPath, draggedItem.Text);
            string destinationFolderPath = selectedPathUsb;

            // Kết hợp đường dẫn đích với tên file
            string destinationFilePath = Path.Combine(destinationFolderPath, draggedItem.Text);

            // Di chuyển file
            File.Move(sourceFilePath, destinationFilePath);
        }

        /// <summary>
        /// Sự kiện cho rename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            List<string> lstFileRename = new List<string>();
            foreach (var item in lv_mouseup_slt)
            {
                lstFileRename.Add(txtFilepath.Text + "/" + item);
            }

            // Thực hiện chức năng Rename ở đây
            RenameForm RenameForm = new RenameForm();

            RenameForm.SetData(lstFileRename, lv_mouseup_slt);

            // Hiển thị form popup
            RenameForm.ShowDialog();
            LoadFolders(txtFilepath.Text);
        }


        /// <summary>
        /// Sự kiện cho xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            // Thực hiện chức năng Delete ở đây
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                List<string> lstFileRename = new List<string>();
                foreach (var item in lv_mouseup_slt)
                {
                    lstFileRename.Add(txtFilepath.Text + "/" + item);
                }

                foreach (var item in lstFileRename)
                {
                    if (File.Exists(item))
                    {
                        // Xóa tập tin nếu tồn tại
                        try
                        {
                            File.Delete(item);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting file: {ex.Message}", "Error");
                        }
                    }
                    else if (Directory.Exists(item))
                    {
                        // Xóa thư mục nếu tồn tại
                        try
                        {
                            Directory.Delete(item, true); // true để xóa cả các tệp con và thư mục con
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting folder: {ex.Message}", "Error");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("File or folder does not exist.", "Not Found");
                    }
                }

                MessageBox.Show("Xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFolders(txtFilepath.Text);
            }
            else { }
        }

        /// <summary>
        /// Sự kiện cho copy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            List<string> lstFileRename = new List<string>();
            foreach (var item in lv_mouseup_slt)
            {
                lstFileRename.Add(txtFilepath.Text + "/" + item);
            }

            VirusScanner scanner = new VirusScanner();

            List<string> lstFile = new List<string>();
            List<string> lstFolder = new List<string>();

            foreach (var item in lstFileRename)
            {
                if (File.Exists(item)) lstFile.Add(item); else lstFolder.Add(item);
            }

           

        }

        /// <summary>
        /// Sự kiện cho view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không cho phép xem và sửa nội dung file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        /// <summary>
        /// Sự kiện cho property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm PPForm = new PropertiesForm();

            List<string> lstFileRename = new List<string>();
            foreach (var item in lv_mouseup_slt)
            {
                lstFileRename.Add(txtFilepath.Text + "/" + item);
            }


            if (lstFileRename != null && lstFileRename.Count > 1)
            {
                MessageBox.Show("Yêu cầu chọn 1 đối tượng để xem chi tiết", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PPForm.SetData(lstFileRename);

            // Hiển thị form popup
            PPForm.ShowDialog();

        }

        /// <summary>
        /// Sự kiện chuột phải để hiển thị menustrip khi click item và click ra ngoài
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                List<string> selectedData = new List<string>();
                // Lấy mục được chọn
                foreach (ListViewItem item in lstDesktop.Items)
                {
                    if (item.Selected)
                    {
                        // Nếu item đã được chọn, thêm dữ liệu của nó vào danh sách
                        string data = $"{item.SubItems[0].Text}";
                        selectedData.Add(data);
                    }
                }

                //ListViewItem selectedItem = lstDesktop.GetItemAt(e.X, e.Y);

                // Kiểm tra xem mục có tồn tại không
                if (selectedData != null && selectedData.Count > 0)
                {
                    lv_mouseup_slt = new List<string>();
                    // Hiển thị ContextMenuStrip 1 nếu click chuột phải vào mục
                    contextMenu.Show(lstDesktop, e.Location);
                    lv_mouseup_slt.AddRange(selectedData);
                }
                else
                {
                    // Hiển thị ContextMenuStrip 2 nếu không click chuột phải vào mục
                    contextMenuOutside.Show(lstDesktop, e.Location);
                }
            }
        }

        /// <summary>
        /// Sự kiện tạo mới folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFolder_Click(object sender, EventArgs e)
        {
            using (var newFolderForm = new NewFolderForm())
            {
                if (newFolderForm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn tuyệt đối cho thư mục mới
                    string folderPath = Path.Combine(selectedPath, newFolderForm.FolderName);
                    try
                    {
                        // Tạo thư mục vật lý
                        Directory.CreateDirectory(folderPath);
                        // Thêm một mục mới có loại là thư mục và tên từ form nhập liệu
                        ListViewItem newFolderItem = new ListViewItem(newFolderForm.FolderName);

                        // Thêm image key cho folder mới tạo
                        string dateModified = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        newFolderItem.ImageKey = "folder";
                        newFolderItem.SubItems.Add("");
                        newFolderItem.SubItems.Add("");
                        newFolderItem.SubItems.Add(dateModified);
                        lstDesktop.Items.Add(newFolderItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tạo folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }

        #region Cụm event view
        /// <summary>
        /// Sự kiện refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFolders(selectedPath);
        }

        /// <summary>
        /// Sự kiện small icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstDesktop.View = View.SmallIcon;
        }

        /// <summary>
        /// Sự kiện large icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstDesktop.View = View.LargeIcon;
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(64, 64);
            imageList.Images.Add("folder", Properties.Resources.folder);
            imageList.Images.Add("excel", Properties.Resources.excel);
            imageList.Images.Add("pdf", Properties.Resources.pdf);
            imageList.Images.Add("powerpoint", Properties.Resources.powerpoint);
            imageList.Images.Add("txt", Properties.Resources.txt);
            imageList.Images.Add("unknown", Properties.Resources.unknown);
            imageList.Images.Add("word", Properties.Resources.word);
            imageList.Images.Add("return", Properties.Resources._return);
            lstDesktop.LargeImageList = imageList;

        }

        /// <summary>
        /// Sự kiện list icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstDesktop.View = View.List;

        }

        /// <summary>
        /// Sự kiện detail icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstDesktop.View = View.Details;
        }
        #endregion
    }
}
