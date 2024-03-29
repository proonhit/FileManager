﻿using System;
using System.Configuration;
using System.Windows.Forms;

namespace ManagerFile
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var defaultPassword = ConfigurationManager.AppSettings["DefaultPassword"];

            string pass = txtPassword.Text;

            if (!string.IsNullOrEmpty(pass) && pass == defaultPassword)
            {
                Default formDefault = new Default();
                formDefault.Show();
                this.Hide();
            }
            else
            {
                txtPassword.ResetText();
                MessageBox.Show("Mật khẩu không chính xác!");
            }
        }
    }
}
