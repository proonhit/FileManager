using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerFile
{
    public partial class NewFolderForm : Form
    {
        public string FolderName { get; private set; }
        public NewFolderForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện nút tạo folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            // Lấy tên thư mục từ TextBox
            FolderName = txtFolderName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
