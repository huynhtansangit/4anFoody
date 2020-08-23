using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viva_vegan
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void Btntrolai_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Btntim_Click(object sender, EventArgs e)
        {
            cbbketquatim.Items.Clear();
            cbbketquatim.Text = "";
            String input = txtnhap.Text;
            if (String.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui nhập mã số hoặc tên nhân viên cần đăng ký tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                
                String queryTim = "Select manv,tennv,sotaikhoannv,diachinv from nhanvien where manv='" +
                    input + "' or tennv like N'%" +
                    input + "%'";
                DataTable dataTable = ClassCSharp.ConnectDataBase.SessionConnect.executeQuery(queryTim);
                if (dataTable.Rows.Count<1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        cbbketquatim.Items.Add(row["manv"].ToString());
                        cardThongtin.Text1 = row["tennv"].ToString();
                        cardThongtin.Text2 = row["sotaikhoannv"].ToString();
                        cardThongtin.Text3 = row["diachinv"].ToString();
                    }
                }
            }
        }

        private void Txtnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btntim.PerformClick();
            }
        }

        private void Cbbketquatim_SelectedIndexChanged(object sender, EventArgs e)
        {
            String itemSelected = cbbketquatim.Text;
            String queryTim = "Select * from nhanvien where manv='" +
                itemSelected + "'";
            DataTable dataTable = ClassCSharp.ConnectDataBase.SessionConnect.executeQuery(queryTim);
            foreach (DataRow row in dataTable.Rows)
            {
                cardThongtin.Text1 = row["tennv"].ToString();
                cardThongtin.Text2 = row["sotaikhoannv"].ToString();
                cardThongtin.Text3 = row["diachinv"].ToString();
                txttendangnhap.Text= row["tendangnhap"].ToString();
                txtpassword.Text = row["matkhau"].ToString();
            }
        }

        private void Btndangky_Click(object sender, EventArgs e)
        {
            String manv = cbbketquatim.Text;
            String tendangnhap = txttendangnhap.Text;
            String pass = txtpassword.Text;
            if (!String.IsNullOrWhiteSpace(tendangnhap) & !String.IsNullOrWhiteSpace(pass))
            {
                if (String.IsNullOrWhiteSpace(manv))
                {
                    MessageBox.Show("Vui lòng chọn mã nhân viên để đăng ký");
                }
                else
                {
                    String query = "dangkydangnhap @MANV , @TENDANGNHAP , @MATKHAU , @Request";
                    int result = ClassCSharp.ConnectDataBase.SessionConnect.executeNonQuery(query, 
                        new object[] { manv.Trim(),
                        tendangnhap.Trim(),
                        pass.Trim(), "register" });
                    if (result==1)
                    {
                        MessageBox.Show("Đăng ký thành công !", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại !");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }
    }
}
