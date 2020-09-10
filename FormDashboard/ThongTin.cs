using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viva_vegan.ClassCSharp;

namespace Viva_vegan.FormDashboard
{
    public partial class ThongTin : Form
    {
        public ThongTin()
        {
            InitializeComponent();
            loadThongTinNhanVien();
        }
        private void loadThongTinNhanVien ()
        {
            txbtencv.Text = new ChucVu().getTencvFromMacv(User.Macv);
            txbtenbp.Text = new BoPhan().getTenBpFromMaBp(User.Mabp);
            txbtencv.Tag = User.Macv;
            txbtenbp.Tag = User.Mabp;
            txbmanv.Text = User.Manv;
            txbtennv.Text = User.Tennv;
            txbsodt.Text = User.Dienthoai;
            txbemail.Text = User.Email;
            txbdiachi.Text = User.Diachi;
            txbsotk.Text = User.Sotk;
            txbtendangnhap.Text = User.Tendangnhap;
            txbmatkhau.Text = User.Matkhau;
            lblsodoanhthu.Text = new HoaDon().getSoTienBanDuocFromNhanvien(User.Manv).ToString("C0");
            lblsodonhang.Text = new HoaDon().getSoHDBanDuocFromNhanvien(User.Manv).ToString();
        }

        private void Btnsuanhanvien_Click(object sender, EventArgs e)
        {
            String manv = txbmanv.Text;
            String macv = txbtencv.Tag.ToString();
            String mabp = txbtenbp.Tag.ToString();
            String tennv = txbtennv.Text;
            String dienthoai    = txbsodt.Text;
            String email        = txbemail.Text;
            String diachi       = txbdiachi.Text;
            String sotk         = txbsotk.Text;
            String tendangnhap  = txbtendangnhap.Text;
            String matkhau      = txbmatkhau.Text;
            if (String.IsNullOrWhiteSpace(manv)|String.IsNullOrWhiteSpace(macv) | String.IsNullOrWhiteSpace(mabp) | String.IsNullOrWhiteSpace(tennv)
                | String.IsNullOrWhiteSpace(dienthoai) | String.IsNullOrWhiteSpace(email) | String.IsNullOrWhiteSpace(diachi)
                | String.IsNullOrWhiteSpace(sotk))
            {
                MessageBox.Show("Invalid input !");
            }
            else
            {
                String query = "themnhanvien @MANV @MACV @MABP @TENNV @DIENTHOAINV @EMAILNV @DIACHINV @SOTAIKHOANNV @TENDANGNHAP @MATKHAU @REQUEST";
                int res = ConnectDataBase.SessionConnect.executeNonQuery(query, new object[]
                {
                    manv,macv,mabp,tennv,dienthoai,email,diachi,sotk, tendangnhap,matkhau,"update"
                });
                if (res > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    User.Manv = manv;
                    User.Macv = macv;
                    User.Mabp = mabp;
                    User.Tennv = tennv;
                    User.Dienthoai = dienthoai;
                    User.Email = email;
                    User.Diachi = diachi;
                    User.Sotk = sotk;
                    User.Tendangnhap = tendangnhap;
                    User.Matkhau = matkhau;
                }
            }
        }

        private void txtGiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            new BangDieuKhien().txtGiaban_KeyPress(sender, e);
        }

        private void ThongTin_Load(object sender, EventArgs e)
        {

        }
    }
}
