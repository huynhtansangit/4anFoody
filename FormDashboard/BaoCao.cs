using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viva_vegan.ClassCSharp;
using Viva_vegan.FormDashboard.BaoCaoChild;
using Viva_vegan.FormDashboard.GoiMonChild;

namespace Viva_vegan.FormDashboard
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        #region events
        private void Btnxembaocao_Click(object sender, EventArgs e)
        {
            DateTime from = dtpTungay.Value;
            DateTime to = dtpDenngay.Value;
            String stringFrom = from.ToString("yyyy-MM-dd");
            String stringTo = to.ToString("yyyy-MM-dd");
            if (to <=from) // ngày không hợp lệ => in ra báo cáo ngày from
            {
                String query = "Select MAHD,MANV,VAT,TIENSAUTHUE,NGAYLAP from HOADON where Convert(date,NGAYLAP) = @tungay";
                DataTable table = ConnectDataBase.SessionConnect.executeQueryNoProc(query,new object[] { stringFrom});
                dgvHoadon.DataSource = table;
            }
            else
            {
                String query = "Select MAHD,MANV,VAT,TIENSAUTHUE,NGAYLAP from HOADON where Convert(date,NGAYLAP) between @tungay and @denngay";
                DataTable table = ConnectDataBase.SessionConnect.executeQueryNoProc(query, new object[] { stringFrom,stringTo });
                dgvHoadon.DataSource = table;
            }
        }
        private void DgvHoadon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String mahoadon = "";
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvHoadon.Rows[e.RowIndex];
                mahoadon = row.Cells["mahd"].Value.ToString();
            }

            using (FormPrint f = new FormPrint(new GoiMon(), mahoadon, true))
            {
                f.ShowDialog();
            }
        }
        private void Btnxuatbaocao_Click(object sender, EventArgs e)
        {
            
            using (PrintReport f = new PrintReport(this))
            {
                f.ShowDialog();
            }
        }

       
        #endregion events


    }
}
