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

namespace Viva_vegan.FormDashboard.GoiMonChild
{
    public partial class FormPrint : Form
    {
        public GoiMon GetGoiMon;
        private long tientamtinh ;
        private long chietkhau;
        private int vat;
        private int km;
        private long tienkhachdua;
        private long tienthua;
        private List<ChiTietHoaDonBill> list = new List<ChiTietHoaDonBill>();
        private string Mahoadon="";
        private Ban ban;
        private String nhanvien;
        private String ngaylap;
        public FormPrint(GoiMon goimon,String mahoadon,Boolean tuFormBaoCao =false)
        {
            InitializeComponent();
            GetGoiMon = goimon;
            if(tuFormBaoCao==false)
            {
                initData(mahoadon);
            }
            else
            {
                initDataForBaoCao(mahoadon);
            }
            // hàm getchitiethoadon.... là để lấy chi tiết từ db truyền vào mã hóa đơn
            list = new ChiTietHoaDonBill().GetChiTietHoaDonBillsFromMaHoaDon(Mahoadon);
        }
        public void initData (String mahoadon)
        {
            tientamtinh = Convert.ToInt64(GetGoiMon.btnthanhtien.Tag);
            vat = Convert.ToInt32(GetGoiMon.btnvat.Tag);

            if (String.IsNullOrWhiteSpace(GetGoiMon.txbchietkhau.Text))
            {
                chietkhau = 0;
            }
            else
            {
                chietkhau = Convert.ToInt64(GetGoiMon.txbchietkhau.Text);
                if (chietkhau < 100)
                {
                    chietkhau = Convert.ToInt64(((float)(chietkhau)/100) *(tientamtinh + vat));
                }
            } 
            km= Convert.ToInt32(GetGoiMon.btnkhuyenmai.Tag);
            if(String.IsNullOrWhiteSpace(GetGoiMon.txbtienkhachdua.Text))
            {
                tienkhachdua = 0;
            }
            else tienkhachdua = Convert.ToInt64(GetGoiMon.txbtienkhachdua.Text);
            tienthua=Convert.ToInt64(GetGoiMon.btntienthua.Tag);
            Mahoadon = mahoadon;
            // ngày và nhân viên
            String query = "select ngaylap,manv from hoadon where mahd ='" +mahoadon+
                "'";
            DataTable dataTable = ConnectDataBase.SessionConnect.executeQuery(query);
            if (dataTable.Rows.Count>0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    nhanvien = row["manv"].ToString();
                    ngaylap = row["ngaylap"].ToString();
                }
            }
        }
        public void initDataForBaoCao(String mahoadon)
        {
            HoaDon hd = new HoaDon().getHoaDonWithId(mahoadon);
            tientamtinh = Convert.ToInt64(hd.Tiensauthue-hd.Vat);
            vat = Convert.ToInt32(GetGoiMon.btnvat.Tag);

            chietkhau = 0;
            km = 0;
            tienkhachdua = hd.Tiennhankh;
            tienthua = hd.Tientralaikh;
            Mahoadon = mahoadon;
            // ngày và nhân viên
            ngaylap = hd.Ngaylap.ToLongDateString();
            nhanvien = hd.Manv;
        }
        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            hoaDonReport1.SetDataSource ( list); // này là cái list món ăn thức uống trong hóa đơn
            hoaDonReport1.SetParameterValue("pKhachhang","Vãng lai");
            hoaDonReport1.SetParameterValue("pMahoadon", Mahoadon);
            if (!String.IsNullOrWhiteSpace(ngaylap)&!String.IsNullOrWhiteSpace(nhanvien))
            {
                hoaDonReport1.SetParameterValue("pNgaylap", ngaylap);
                hoaDonReport1.SetParameterValue("pNhanvien", nhanvien);
            }
            else
            {
                hoaDonReport1.SetParameterValue("pNgaylap", "Chưa xác nhận");
                hoaDonReport1.SetParameterValue("pNhanvien", "Chưa xác nhận");
            }
            hoaDonReport1.SetParameterValue("pVat", vat);
            hoaDonReport1.SetParameterValue("pChietkhau", chietkhau);
            hoaDonReport1.SetParameterValue("pTongtienphaitra", tientamtinh+vat-chietkhau);
            hoaDonReport1.SetParameterValue("pTienkhachdua", tienkhachdua);
            hoaDonReport1.SetParameterValue("pKhuyenmai", 0);
            hoaDonReport1.SetParameterValue("pTienthua", tienthua);
            crystalReportViewer1.ReportSource = hoaDonReport1;
        }
    }
}
