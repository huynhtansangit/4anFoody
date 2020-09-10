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
using Viva_vegan.ClassCSharp;
using XanderUI;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Viva_vegan.FormDashboard
{
    public partial class DoanhThu : Form
    {
        private ThongBaoDBChange notificationDoanhThu;
        private ThongBaoDBChange notificationSoBan;
        private ThongBaoDBChange notification;
        private List<DoanhThuClass> listChartInfo = new List<DoanhThuClass>();
        private string queryDoanhthu = "select SUM(TIENSAUTHUE-vat) from HOADON";
        private string queryBanDangHoatDong = "select count(soban) from ban where tinhtrangban like '%busy%'";
        private string queryTongSoBan = "select count(soban) from ban";
        private string querySoDonHang = "select count(mahd) from hoadon";
        private string queryVat = "select sum(vat) from hoadon";
        public DoanhThu()
        {
            InitializeComponent();
            LoadFoodRate();
            LoadDrinkRate();
            LoadStaffRate();
        }
        #region Mothods
        private void LoadChiTiet ()
        {
            var doanhThuTruocThue = ConnectDataBase.SessionConnect.executeScalar(queryDoanhthu);
            var soBanDangHoatDong = ConnectDataBase.SessionConnect.executeScalar(queryBanDangHoatDong);
            var soHoaDon = ConnectDataBase.SessionConnect.executeScalar(querySoDonHang);
            var tongSoBan = ConnectDataBase.SessionConnect.executeScalar(queryTongSoBan);
            var tongVat = ConnectDataBase.SessionConnect.executeScalar(queryVat);
            // Doanh thu
            //
            InvokeIfRequired(lblsodoanhthu, (MethodInvoker)delegate ()
            {
                lblsodoanhthu.Text = Convert.ToInt64(doanhThuTruocThue).ToString("C0");
                lblsodangsudung.Text = soBanDangHoatDong.ToString() + "/" + tongSoBan.ToString();
                lblsodonhang.Text = soHoaDon.ToString();
                lblvat.Text = Convert.ToInt64(tongVat).ToString("C0");
            });
        }
        private void On_Quit()
        {
            notificationDoanhThu.Dispose();
        }
        public static void InvokeIfRequired(Control control, MethodInvoker action)
        {
            if (control.IsDisposed)
            {
                return;
            }

            if (control.InvokeRequired)
            {
                try
                {
                    control.Invoke(action);
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException e)
                {
                    // Intercept only invokation errors (a bit tricky)
                    if (!e.Message.Contains("Invoke"))
                    {
                        throw e;
                    }
                }
            }
            else
            {
                action();
            }
        }
        private void LoadListChart ()
        {
            InvokeIfRequired(cbbchartheo, (MethodInvoker)delegate ()
            {
                List<DoanhThuClass> doanhthu = new List<DoanhThuClass>();
                if (String.IsNullOrWhiteSpace(cbbchartheo.Text))
                {

                }
                else
                {
                    if (cbbchartheo.Text.Contains("7 NGÀY"))
                    {
                        doanhthu = new DoanhThuClass().getDoanhThuTuan();
                    }
                    else if (cbbchartheo.Text.Contains("1 THÁNG"))
                    {
                        doanhthu = new DoanhThuClass().getDoanhThuThang();
                    }
                    else if (cbbchartheo.Text.Contains("1 NĂM"))
                    {
                        doanhthu = new DoanhThuClass().getDoanhThuNam();
                    }
                    else doanhthu = new DoanhThuClass().getDoanhThuAll();
                }
                listChartInfo = doanhthu;
            });
        }
        private void LoadChart ()
        {
            List<DoanhThuClass> doanhthu = listChartInfo;
            String[] thoigian = new string[doanhthu.Count];
            long[] values = new long[doanhthu.Count];
            for (int i = 0; i < doanhthu.Count; i++)
            {
                thoigian[i] = doanhthu[i].Thoigian;
                values[i] = doanhthu[i].Doanhthu;
            }
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Values = new ChartValues<long>(values),
                DataLabels = true,
                LabelPoint = point => point.Y.ToString("C0")
            });
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Tháng",
                Labels = thoigian
            });
            cartesianChart1.AxisY.Add(new Axis()
            {
                LabelFormatter = value => value.ToString("C0"),
                Separator = new Separator()
            });
        }
        private void LoadStaffRate()
        {
            flpnhanvien.Controls.Clear();
            String query = "loadbxhnhanvien @mocthoigian";
            DataTable table = new DataTable();
            if (String.IsNullOrWhiteSpace(cbblocbxh.Text))
            {
                table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "day" });
            }
            else
            {
                if (cbblocbxh.Text.Contains("NGÀY"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "day" });
                }
                else if (cbblocbxh.Text.Contains("TUẦN"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "week" });
                }
                else if (cbblocbxh.Text.Contains("THÁNG"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "month" });
                }
                else if (cbblocbxh.Text.Contains("NĂM"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "year" });
                }
                else
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "all" });
                }
            }
            if (table.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow row in table.Rows)
                {
                    flpnhanvien.Controls.Add(customizeGb(Convert.ToInt64(row["DOANHTHUNV"]), row["MANV"].ToString()+"-"+ row["TENNV"].ToString(), i,"nhanvien"));
                    i++;
                }
            }
        }
        private void LoadFoodRate ()
        {
            flpBxhThucAn.Controls.Clear();
            String query = "loadbxhmonan @mocthoigian";
            DataTable table = new DataTable();
            if (String.IsNullOrWhiteSpace(cbblocbxh.Text))
            {
                table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "day" });
            }
            else
            {
                if (cbblocbxh.Text.Contains("NGÀY"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "day" });
                }
                else if (cbblocbxh.Text.Contains("TUẦN"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "week" });
                }
                else if(cbblocbxh.Text.Contains("THÁNG"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "month" });
                }
                else if (cbblocbxh.Text.Contains("NĂM"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "year" });
                }
                else 
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "all" });
                }
            }
            if (table.Rows.Count >0)
            {
                int i = 0;
                foreach (DataRow row in table.Rows)
                {
                   flpBxhThucAn.Controls.Add( customizeGb(Convert.ToInt64(row["SLBANRA"]), row["TENMON"].ToString(),i));
                    i++;
                }
            }
        }
        private void LoadDrinkRate()
        {
            flpbxhthucuong.Controls.Clear();
            String query = "loadbxhthucuong @mocthoigian";
            DataTable table = new DataTable();
            if (String.IsNullOrWhiteSpace(cbblocbxh.Text))
            {
                table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "day" });
            }
            else
            {
                if (cbblocbxh.Text.Contains("NGÀY"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "day" });
                }
                else if (cbblocbxh.Text.Contains("TUẦN"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "week" });
                }
                else if (cbblocbxh.Text.Contains("THÁNG"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "month" });
                }
                else if (cbblocbxh.Text.Contains("NĂM"))
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "year" });
                }
                else
                {
                    table = ConnectDataBase.SessionConnect.executeQuery(query, new object[] { "all" });
                }
            }
            if (table.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow row in table.Rows)
                {
                    flpbxhthucuong.Controls.Add(customizeGb(Convert.ToInt64(row["SLBANRA"]), row["TENTHUCUONG"].ToString(), i,"thucuong"));
                    i++;
                }
            }
        }
        public XUICustomGroupbox customizeGb(long soluong,String tenmmon, int index, String loaiNao =null)
        {
            XUICustomGroupbox xuiCustomGroupbox1 =new XUICustomGroupbox();
            Label label = new Label();
            xuiCustomGroupbox1.BorderColor = System.Drawing.Color.SteelBlue;
            xuiCustomGroupbox1.BorderWidth = 1;
            xuiCustomGroupbox1.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xuiCustomGroupbox1.ShowText = true;
            xuiCustomGroupbox1.Size = new System.Drawing.Size(322, 55);
            xuiCustomGroupbox1.TabStop = false;
            xuiCustomGroupbox1.TextColor = System.Drawing.Color.DodgerBlue;
           
            switch (index)
            {
                case 0:
                    {
                        xuiCustomGroupbox1.BackColor = System.Drawing.Color.MistyRose;
                        break;
                    }
                case 1:
                    {
                        xuiCustomGroupbox1.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    }
                case 2:
                    {
                        xuiCustomGroupbox1.BackColor = System.Drawing.Color.AliceBlue;
                        break;
                    }
            }

            label.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.DimGray;
            label.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            label.Size = new System.Drawing.Size(251, 24);
            label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label.Location = new System.Drawing.Point(65, 22);


            label.Text = tenmmon;
            xuiCustomGroupbox1.Text = soluong.ToString();
            if (!String.IsNullOrWhiteSpace(loaiNao))
            {
                if (loaiNao.Contains("thucuong"))
                {
                    xuiCustomGroupbox1.BorderColor = System.Drawing.Color.Maroon;
                    xuiCustomGroupbox1.TextColor = System.Drawing.Color.Maroon;
                }
                else if (loaiNao.Contains("nhanvien"))
                {
                    xuiCustomGroupbox1.Text = soluong.ToString("C0");
                }
            }
            xuiCustomGroupbox1.Controls.Add(label);
            return xuiCustomGroupbox1;
        }
        #endregion Methods
        //------------------------------------------
        #region Events
        private void DoanhThu_Load(object sender, EventArgs e)
        {
            notificationDoanhThu = new ThongBaoDBChange(LoadChiTiet, queryDoanhthu);
            notificationDoanhThu.loadData();
            notificationSoBan = new ThongBaoDBChange(LoadChiTiet, queryBanDangHoatDong);
            notificationSoBan.loadData();
            notification = new ThongBaoDBChange(LoadListChart, "select * from hoadon");
            notification.loadData();
        }
        private void DoanhThu_FormClosing(object sender, FormClosingEventArgs e)
        {
            On_Quit();
        }

        private void Cbbchartheo_SelectedValueChanged(object sender, EventArgs e)
        {
            String cbbContent = cbbchartheo.Text;
            if (!cbbContent.Contains("TỪ TRƯỚC ĐẾN NAY"))
            {
                lblDoanhthuchart.Text = "DOANH THU TRONG " + cbbchartheo.Text +" GẦN ĐÂY";
                LoadChart();
            }
            else
            {
                lblDoanhthuchart.Text = "DOANH THU " + cbbchartheo.Text;
                LoadChart();
            }

        }


        #endregion Events

        private void Cbblocbxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoodRate();
            LoadDrinkRate();
            LoadStaffRate();
        }
    }
}
