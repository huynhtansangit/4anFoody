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

        private void Btndangnhap_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }

        public void dangnhap()
        {
            // handle login process
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
            this.Close();
            new Register().Show();
        }
    }
}
