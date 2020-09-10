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

namespace Viva_vegan.FormDashboard.BaoCaoChild
{
    public partial class PrintReport : Form
    {
        public BaoCao parent = new BaoCao();
        private String tungay,denngay;
        private long thucthu, sohd;
        private String nguoitao = User.Tennv;
        private String ngaytao = DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToShortTimeString();
        private DateTime from ;
        private DateTime to;
        public PrintReport(BaoCao bc)
        {
            InitializeComponent();
            parent = bc;
            initData();
        }
        public void initData ()
        {
            from = parent.dtpTungay.Value;
            to = parent.dtpDenngay.Value;
            tungay = from.ToString("yyyy-MM-dd");
            denngay = to.ToString("yyyy-MM-dd");
            
            String queryThucThu = "select sum(TIENSAUTHUE-VAT) as THUCTHU from hoadon where CONVERT(date,NGAYLAP)> '" + tungay +
                "' and CONVERT(date,NGAYLAP)<'" + denngay +
                "'";
            String querySoHd = "select count(MAHD) as SL from hoadon where CONVERT(date,NGAYLAP)> '" + tungay +
                "' and CONVERT(date,NGAYLAP)<'" + denngay +
                "'";
            var _thucthu = ConnectDataBase.SessionConnect.executeScalar(queryThucThu);
            var _sohd = ConnectDataBase.SessionConnect.executeScalar(querySoHd);
            if (_thucthu == null )
            {
                thucthu = 0;
            }
            else
            {
                //thucthu = (long)(_thucthu);
                Console.Write(_thucthu.ToString());
            }
            if (_sohd == null )
            {
                sohd = 0;
            }
            else
            {
                //sohd = (long)(_sohd);
                Console.Write(_sohd.ToString());
            }
        }
        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            List<HoaDon> hds = new HoaDon().getListHoaDon();
            List<MonAn> mas = new MonAn().GetMonAns();
            List<ThucUong> tus = new ThucUong().GetThucUongs();
            List<NhanVien> nvs = new NhanVien().getListNhanVien();
            List<BestSellerFood> bestSellerFoods = new BestSellerFood().GetBestSellerFoods(tungay, denngay);
            List<BestSellerItem> bestSellerItems = new BestSellerItem().GetBestSellerDrinks(tungay, denngay);
            hDreport1.Database.Tables[0].SetDataSource(hds);// này là cái list món ăn thức uống trong hóa đơn
            hDreport1.Database.Tables[1].SetDataSource(tus);
            hDreport1.Database.Tables[2].SetDataSource(nvs);
            hDreport1.Database.Tables[3].SetDataSource(mas);
            hDreport1.Database.Tables[4].SetDataSource(bestSellerFoods);
            hDreport1.Database.Tables[5].SetDataSource(bestSellerItems);
            hDreport1.SetParameterValue("ptungay",from) ;
            hDreport1.SetParameterValue("pdenngay", to);
            hDreport1.SetParameterValue("pnguoitao", nguoitao);
            hDreport1.SetParameterValue("pngaytaobaocao", ngaytao);
            hDreport1.SetParameterValue("pthucthu", thucthu);
            hDreport1.SetParameterValue("psohoadon", sohd);
            crystalReportViewer1.ReportSource = hDreport1;
        }
    }
}
