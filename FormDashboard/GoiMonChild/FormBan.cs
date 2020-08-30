using FontAwesome.Sharp;
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
using XanderUI;

namespace Viva_vegan.FormDashboard.GoiMonChild
{
    public partial class FormBan : Form
    {
        private List<KhuVuc> khuvucs = new List<KhuVuc>();
        private GoiMon myParent;
        public FormBan(GoiMon goiMon)
        {
            InitializeComponent();
            myParent = goiMon;
            loadBan("");
            loadKhuVuc();
        }
        #region Events
        private void Cbbkhuvuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            String makv = "";
            foreach (KhuVuc item in khuvucs)
            {
                if (item.Tenkhuvuc == cbbkhuvuc.Text)
                {
                    makv = item.Makhuvuc;
                }
            }
            loadBan(makv);
        }
        private void eventClickBan(object sender, EventArgs e)
        {
            Ban ban = (Ban)(sender as IconButton).Tag;
            DialogResult result = new DialogResult();
            if(ban.Trangthai.Contains("empty")) // bàn trống gọi món
            {
                result = MessageBox.Show(String.Format("Bạn muốn gọi món cho {0} ?",ban.Tenban), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    myParent.btnChonban.PerformClick();
                    myParent.btnthongtinban.Text = "Thông tin bàn " + ban.Tenban + "-" + ban.Makhuvuc;
                    myParent.btntrangthai.Text = "Đang thực hiện gọi món";
                    myParent.btnthongtinban.Tag = ban;
                }
            }
            else // bàn bận chỉ chỉnh sửa hoặc thanh toán.
            {
                result = MessageBox.Show(String.Format("Bạn muốn thanh toán hoặc chỉnh sửa {0} ?", ban.Tenban), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    myParent.btnChonban.PerformClick();
                    myParent.ClearThanhToanInfo();
                    myParent.btnthongtinban.Text = "Thông tin bàn " + ban.Tenban + "-" + ban.Makhuvuc;
                    myParent.btntrangthai.Text = "Đang thực hiện thanh toán / cập nhật";
                    myParent.btnthongtinban.Tag = ban;
                    long tongtien = 0;
                    // lấy chi tiết hóa đơn đổ lên dgvhoadon.
                    String mahoadondanghoatdong = new BanDangHoatDong().getMaHoaDonFromMaBan(ban.Soban);
                    myParent.dgvhoadon.Rows.Clear();
                    List <ChiTietHoaDon> cthds =new ChiTietHoaDon().chiTietHoaDons(mahoadondanghoatdong);
                    foreach (ChiTietHoaDon item in cthds)
                    {
                        DataGridViewRow row = (DataGridViewRow)myParent.dgvhoadon.Rows[0].Clone();
                        row.Cells[0].Value = item.Mamon;
                        row.Cells[1].Value = item.Tenmon;
                        row.Cells[2].Value = item.Dvt;
                        row.Cells[3].Value = item.Dongia;
                        row.Cells[4].Value = item.Soluong;
                        row.Cells[5].Value = item.Dongia* item.Soluong;
                        tongtien += Convert.ToInt64(row.Cells[5].Value);
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Blue;
                        row.Tag = cthds.Count;
                        myParent.dgvhoadon.Rows.Add(row);
                    }
                    //thông số hóa đơn
                    myParent.btnthanhtien.ButtonText = tongtien.ToString("C0");
                    myParent.btnthanhtien.Tag = tongtien;
                    myParent.btnvat.ButtonText = ((double)tongtien*0.1).ToString("C0");
                    myParent.btnvat.Tag = ((double)tongtien * 0.1);
                    myParent.txbtienkhachdua.Enabled = true;
                }
            }
           
            
        }
        #endregion

        #region Mothods
        private XUICustomGroupbox createCustomBtn(Ban ban)
        {
            XUICustomGroupbox grbBan = new XUICustomGroupbox();
            IconButton ibutton = new IconButton();
            Label lbltenban = new Label();

            lbltenban.AutoSize = true;
            lbltenban.Font = new System.Drawing.Font("Adobe Heiti Std R", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lbltenban.Size = new System.Drawing.Size(48, 16);
            lbltenban.TabIndex = 2;
            lbltenban.Text = ban.Tenban + " - " + ban.Makhuvuc;
            lbltenban.Location = new System.Drawing.Point(12, 99);

            ibutton.BackgroundImageLayout = ImageLayout.Zoom;
            ibutton.FlatAppearance.BorderSize = 0;
            ibutton.FlatStyle = FlatStyle.Flat;
            ibutton.Flip = FlipOrientation.Normal;
            ibutton.IconChar = IconChar.None;
            ibutton.Rotation = 0D;
            ibutton.Size = new System.Drawing.Size(80, 80);
            ibutton.UseVisualStyleBackColor = true;
            ibutton.Dock = System.Windows.Forms.DockStyle.Top;
            ibutton.Tag = ban;
            ibutton.Click += eventClickBan;
            // group box
            grbBan.BorderWidth = 1;
            grbBan.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grbBan.ShowText = true;
            grbBan.Size = new System.Drawing.Size(115, 120);
            grbBan.TabIndex = 0;
            grbBan.TabStop = false;
            grbBan.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);

            if (ban.Trangthai.Contains("empty"))
            {
                grbBan.Text = "Free";
                grbBan.TextColor = System.Drawing.Color.MidnightBlue;
                grbBan.BorderColor = System.Drawing.Color.MidnightBlue;
                ibutton.BackgroundImage = global::Viva_vegan.Properties.Resources.ban_trong;
                lbltenban.ForeColor = System.Drawing.Color.MidnightBlue;
            }
            else
            {
                grbBan.Text = "Busy";
                grbBan.TextColor = System.Drawing.Color.Maroon;
                grbBan.BorderColor = System.Drawing.Color.Red;
                ibutton.BackgroundImage = global::Viva_vegan.Properties.Resources.ban_dang_dung;
                lbltenban.ForeColor = System.Drawing.Color.Maroon;
            }
            // thêm nội dung bên trong groupbox.
            grbBan.Controls.Add(ibutton);
            grbBan.Controls.Add(lbltenban);
            return grbBan;
        }

         

        public void loadBan(String khuvuc)
        {
            flpBan.Controls.Clear();
            List<Ban> bans = new Ban().loadList("");
            if (!String.IsNullOrWhiteSpace(khuvuc))
            {
                bans = new Ban().loadList(khuvuc);
            }
            foreach (Ban item in bans)
            {
                XUICustomGroupbox grbBtn = createCustomBtn(item);
                flpBan.Controls.Add(grbBtn);

            }
        }
        private void loadKhuVuc()
        {
            khuvucs = new KhuVuc().loadListKhuVuc();
            foreach (KhuVuc item in khuvucs)
            {
                cbbkhuvuc.Items.Add(item.Tenkhuvuc);
            }
            cbbkhuvuc.Items.Add("Tất cả");
        }
        #endregion
    }
}
