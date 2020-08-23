using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viva_vegan
{
    public partial class Login : Form
    {
        private ClassCSharp.ConnectDataBase conDB;
        public Login()
        {
            InitializeComponent();
            txtusername.Focus();
            this.AcceptButton = btndangnhap;
            conDB = new ClassCSharp.ConnectDataBase("");
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
                String querylogin = "dangkydangnhap @MANV @TENDANGNHAP @MATKHAU @Request";
                DataTable dataTable = ClassCSharp.ConnectDataBase.SessionConnect.executeQuery(querylogin,
                    new object[] { " ", name.Trim() , pass.Trim(), "login" });
                if (dataTable.Rows.Count != 0)
                {
                    ClassCSharp.User.Manv= dataTable.Rows[0].Field<String>(0);
                    ClassCSharp.User.Macv = dataTable.Rows[0].Field<String>(1);
                    ClassCSharp.User.Mabp = dataTable.Rows[0].Field<String>(2);
                    ClassCSharp.User.Tennv = dataTable.Rows[0].Field<String>(3);
                    ClassCSharp.User.Dienthoai = dataTable.Rows[0].Field<String>(4);
                    ClassCSharp.User.Email = dataTable.Rows[0].Field<String>(5);
                    ClassCSharp.User.Diachi = dataTable.Rows[0].Field<String>(6);
                    ClassCSharp.User.Sotk = dataTable.Rows[0].Field<String>(7);
                    ClassCSharp.User.Tendangnhap = dataTable.Rows[0].Field<String>(8);
                    ClassCSharp.User.Matkhau = dataTable.Rows[0].Field<String>("matkhau");
                    ClassCSharp.User.Ngayvaolam = Convert.ToDateTime( dataTable.Rows[0]["ngayvaolam"]);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
