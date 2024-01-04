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

namespace ManagerFile
{
    public partial class RenameForm : Form
    {
        public List<string> lstFileChange { get; set; }

        public RenameForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// truyền dẽ liệu file rename từ listview sang popup
        /// </summary>
        /// <param name="file_rename"></param>
        public void SetData(List<string> lstFileRename, List<string> lstName)
        {
            txtRename.Text = lstName.FirstOrDefault();
            lstFileChange = lstFileRename;
        }

        /// <summary>
        /// Thực hiện thao tác confirm đổi tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, EventArgs e)
        {
            var NameChange = txtRename.Text;

            if (string.IsNullOrEmpty(NameChange))
            {
                MessageBox.Show("Bạn chưa nhập tiêu đề cần thay đổi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int stt = -1;
                    foreach (var item in lstFileChange)
                    {
                        stt++;
                        string FileName = "";
                        FileName = (stt == 0) ? FileName = NameChange : FileName = NameChange + "(" + stt + ")";
                        // Đường dẫn mới sau khi đổi tên
                        if (File.Exists(item))
                        {
                            string fileExtension = Path.GetExtension(item);

                            // Đường dẫn mới sau khi đổi tên file
                            string newPath = Path.Combine(Path.GetDirectoryName(item), FileName + fileExtension);

                            // Kiểm tra xem tên mới đã tồn tại chưa
                            if (File.Exists(newPath))
                            {
                                MessageBox.Show("Tên mới đã tồn tại. Vui lòng chọn một tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Đổi tên file
                            File.Move(item, newPath);
                        }
                        else if (Directory.Exists(item))
                        {
                            // Đường dẫn mới sau khi đổi tên thư mục
                            string newPath = Path.Combine(Path.GetDirectoryName(item), FileName);

                            // Kiểm tra xem tên mới đã tồn tại chưa
                            if (Directory.Exists(newPath))
                            {
                                MessageBox.Show("Tên mới đã tồn tại. Vui lòng chọn một tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Đổi tên thư mục
                            Directory.Move(item, newPath);
                        }
                        else
                        {
                            MessageBox.Show("Đường dẫn không tồn tại hoặc không phải là file hoặc thư mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    MessageBox.Show("Đã đổi tên thư mục thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }


    }
}
