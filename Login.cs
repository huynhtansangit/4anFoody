using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viva_vegan
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btndangnhap;
        }

        private void IBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btndangnhap.PerformClick();
            }
        }

        private Boolean kiemTraDangNhap()
        {
            String name = txtusername.Text;
            String pass = txtpassword.Text;

            if (String.IsNullOrWhiteSpace(name) | String.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng không bỏ trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                // kiểm tra db rồi cấp phép login.
                return true;
            }
        }

        private void Btndangnhap_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
            if (kiemTraDangNhap())
            {
                this.Hide();
                new Dashboard().Show();
            }
        }

        private void LblChuyensangdky_MouseHover(object sender, EventArgs e)
        {
            lblChuyensangdky.ForeColor = Color.DodgerBlue;
        }

        private void LblChuyensangdky_MouseLeave(object sender, EventArgs e)
        {
            lblChuyensangdky.ForeColor = Color.Black;
        }

        private void XuiCheckBox1_CheckedStateChanged(object sender, EventArgs e)
        {
            if (cbshowpass.Checked)
                txtpassword.PasswordChar = '\0';
            else
                txtpassword.PasswordChar = '*';
        }

        private void LblChuyensangdky_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register().Show();
        }
    }
}
