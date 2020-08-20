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
        private ClassCSharp.ConnectDataBase conn;
        public Register()
        {
            InitializeComponent();
            conn = new ClassCSharp.ConnectDataBase("");
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

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
                if (conn.getConnection() != null && conn.getConnection().State == ConnectionState.Closed)
                {
                    conn.getConnection().Open();
                }
                String queryTim = "Select manv,tennv,sotaikhoannv,diachinv from nhanvien where manv='" +
                    input + "' or tennv= N'" +
                    input + "'";
                Console.WriteLine(queryTim);
                SqlCommand cmd = new SqlCommand(queryTim, conn.getConnection());
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.HasRows)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.getConnection().Close();
                }
                else
                {
                    String tempManv="";
                    while (rd.Read())
                    {
                        cbbketquatim.Items.Add(rd.GetString(0));
                        tempManv = rd.GetString(0);
                        cardThongtin.Text1 = rd.GetString(1);
                        cardThongtin.Text2 = rd.GetString(2);
                        cardThongtin.Text3 = rd.GetString(3);
                    }
                    
                    conn.getConnection().Close();
                    cbbketquatim.Text = tempManv;
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
            if (conn.getConnection() != null && conn.getConnection().State == ConnectionState.Closed)
            {
                conn.getConnection().Open();
            }
            String queryTim = "Select manv,tennv,sotaikhoannv,diachinv from nhanvien where manv='" +
                itemSelected + "'";
            Console.WriteLine(queryTim);
            SqlCommand cmd = new SqlCommand(queryTim, conn.getConnection());
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read()) {
                cardThongtin.Text1 = rd.GetString(1);
                cardThongtin.Text2 = rd.GetString(2);
                cardThongtin.Text3 = rd.GetString(3);
            }
            conn.getConnection().Close();
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
                    if (conn.getConnection() != null && conn.getConnection().State == ConnectionState.Closed)
                    {
                        conn.getConnection().Open();
                    }
                    SqlCommand cmd = new SqlCommand("dangkydangnhap", conn.getConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MANV", manv);
                    cmd.Parameters.AddWithValue("@TENDANGNHAP", tendangnhap.Trim());
                    cmd.Parameters.AddWithValue("@MATKHAU", pass.Trim());
                    cmd.Parameters.AddWithValue("@Request", "register");
                    var returnValue=cmd.Parameters.Add("@result", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnValue.Value;
                    if (Convert.ToInt16(result)==1)
                    {
                        MessageBox.Show("Đăng ký thành công !", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại !");
                    }
                    conn.getConnection().Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }
    }
}
