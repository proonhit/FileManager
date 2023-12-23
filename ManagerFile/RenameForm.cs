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
    public partial class RenameForm : Form
    {
        public RenameForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetData(string data)
        {
            // Xử lý dữ liệu tại đây (ví dụ: hiển thị dữ liệu trong một Label)
            MessageBox.Show(data) ;
        }
    }
}
