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
using FontAwesome.Sharp;
using Viva_vegan.FormDashboard.GoiMonChild;
using System.IO;

namespace Viva_vegan.FormDashboard
{
    public partial class GoiMon : Form
    {
        private List<ThucUong> GetThucUongs = new List<ThucUong>();
        private List<MonAn> GetMonAns = new List<MonAn>();
        public List<BanDangHoatDong> banDangHoatDongs = new List<BanDangHoatDong>();
        private Boolean chonBan = false;
        private Form currentChildForm;
        public bool ChonBan { get => chonBan; set => chonBan = value; }
        
        public GoiMon()
        {
            InitializeComponent();
            resizeDgvHoadon();
            txbtienkhachdua.Enabled = false;
        }
        public string btnText
        {
            get
            {
                return this.btnChonban.Text;
            }
            set
            {
                this.btnChonban.Text = value;
            }
        }

        #region Methods
        public void ClearThanhToanInfo ()
        {
            txbchietkhau.Text = "";
            txbtienkhachdua.Text = "";
            btnthanhtien.ButtonText = "";
            btnvat.ButtonText = "";
            btnkhuyenmai.ButtonText = "";
            btntienthua.ButtonText = "";
            //-- tag
            txbchietkhau.Tag = 0;
            txbtienkhachdua.Tag = 0;
            btnthanhtien.Tag = 0;
            btnvat.Tag = 0;
            btnkhuyenmai.Tag = 0;
            btntienthua.Tag = 0;
        }
        private void activeButton ()
        {
            if(chonBan==false)
            {
                chonBan = true;
                btnChonban.IconChar = IconChar.ChevronUp;
                btnChonban.ImageAlign = ContentAlignment.MiddleRight;
                btnChonban.Text = "Thu gọn";
                
            }
            else
            {
                chonBan = false;
                btnChonban.IconChar = IconChar.ChevronDown;
                btnChonban.ImageAlign = ContentAlignment.MiddleLeft;
                btnChonban.Text = "Chọn bàn";
            }
            openChildForm(new FormBan(this));
        }
        private void openChildForm(Form childForm)
        {
            if (chonBan == false)
            {
                // chỉ mở một form
                currentChildForm.Close();
            }
            else
            {
                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnBan.Controls.Add(childForm);
                pnBan.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }
        private void loadMonAnThucUong(string ThucanNuocuong,String order =null)
        {
            flpthucdon.Controls.Clear();
            if (ThucanNuocuong.Contains("thucuong"))
            {
                GetThucUongs=new ThucUong().GetThucUongs();
                if (String.IsNullOrWhiteSpace(order))
                {
                    GetThucUongs = new ThucUong().GetThucUongs();
                    foreach (ThucUong item in GetThucUongs)
                    {
                        flpthucdon.Controls.Add(groupMonAnThucUong("thucuong", null , item));
                    }
                }
                else
                {
                    GetThucUongs = new ThucUong().GetThucUongs(order);
                    foreach (ThucUong item in GetThucUongs)
                    {
                        flpthucdon.Controls.Add(groupMonAnThucUong("thucuong", null ,item));
                    }
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(order))
                {
                    GetMonAns = new MonAn().GetMonAns();
                    foreach (MonAn item in GetMonAns)
                    {
                        flpthucdon.Controls.Add(groupMonAnThucUong("monan", item));
                    }
                }
                else
                {
                    GetMonAns = new MonAn().GetMonAns(order);
                    foreach (MonAn item in GetMonAns)
                    {
                        flpthucdon.Controls.Add(groupMonAnThucUong("monan", item));
                    }
                }
            }
        }

        private XUICustomGroupbox groupMonAnThucUong (String loai ,MonAn monan=null, ThucUong thucuong= null  )
        {
            XUICustomGroupbox groupbox = new XUICustomGroupbox();
            PictureBox pictureBox = new PictureBox();
            Label lbltenmon = new Label();
            groupbox.BorderWidth = 2;
            groupbox.FlatStyle = FlatStyle.Flat;
            groupbox.Font = new Font("Cooper Black", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupbox.ShowText = true;
            groupbox.Size = new System.Drawing.Size(159, 207);
            groupbox.Margin = new Padding(30,0,0,0);
            
            //picture
            pictureBox.MouseEnter += Picture_MouseHover;
            pictureBox.MouseLeave += Picture_MouseLeave;
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(3, 18);
            pictureBox.Size = new Size(153, 136);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Click += clickThucDon;
            //label
            lbltenmon.Dock = DockStyle.Bottom;
            lbltenmon.Location = new Point(3, 154);
            lbltenmon.Size = new Size(153, 50);
            
            lbltenmon.Font = new Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            if (loai.Contains("monan"))
            {
                lbltenmon.Text = monan.Tenmon;
                pictureBox.Tag = monan.Mamon;
                groupbox.Text = monan.Giaban.ToString("C0");
                MemoryStream mem = new MemoryStream(monan.Hinh);
                pictureBox.Image = Image.FromStream(mem);
                groupbox.TextColor = System.Drawing.Color.Maroon;
                groupbox.BorderColor = System.Drawing.Color.Maroon;
                groupbox.Name = "gb" + monan.Mamon;
            }
            else
            {
                lbltenmon.Text = thucuong.Tenthucuong;
                pictureBox.Tag = thucuong.Mathucuong;
                groupbox.Text = thucuong.Giaban.ToString("C0");
                MemoryStream mem = new MemoryStream(thucuong.Hinh);
                pictureBox.Image = Image.FromStream(mem);
                groupbox.BorderColor = Color.MidnightBlue;
                groupbox.TextColor = Color.MidnightBlue;
            }
            groupbox.Controls.Add(pictureBox);
            groupbox.Controls.Add(lbltenmon);
            return groupbox;
        }
        private void resizeDgvHoadon ()
        {
            dgvhoadon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvhoadon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvhoadon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvhoadon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvhoadon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvhoadon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvhoadon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public Boolean daTonTaiTrongDgv (String mamon)
        {
            
            if (dgvhoadon.Rows[0].Cells["mamon"].Value != null)
            {
                foreach (DataGridViewRow row in dgvhoadon.Rows)
                {
                    if(row.Cells["MAMON"].Value!=null)
                    {
                        if (row.Cells["MAMON"].Value.ToString().Contains(mamon))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion Methods

        #region Events
        private void Picture_MouseHover(object sender, EventArgs e)
        {
            PictureBox temp = sender as PictureBox;
            XUICustomGroupbox gb = temp.Parent as XUICustomGroupbox;
            gb.BorderColor = Color.Aqua;
            gb.TextColor = Color.Aqua;
            gb.Size = new System.Drawing.Size(159+10, 207+10);
        }
        private void Picture_MouseLeave(object sender, EventArgs e)
        {
            PictureBox temp = sender as PictureBox;
            XUICustomGroupbox gb = temp.Parent as XUICustomGroupbox;
            if (temp.Tag.ToString().Contains("MA"))
            {
                gb.BorderColor = Color.Maroon;
                gb.TextColor = Color.Maroon;
                gb.Size = new System.Drawing.Size(159, 207);
            }
            else
            {
                gb.BorderColor = Color.MidnightBlue;
                gb.TextColor = Color.MidnightBlue;
                gb.Size = new System.Drawing.Size(159, 207);
            }
        }
        private void clickThucDon(object sender, EventArgs e)
        {
            String ma = (sender as PictureBox).Tag.ToString();
            DataGridViewRow row = (DataGridViewRow)dgvhoadon.Rows[0].Clone();
            if (ma.Contains("MA")&!daTonTaiTrongDgv(ma))
            {
                MonAn monAn = new MonAn(ma);
                row.Cells[0].Value = monAn.Mamon;
                row.Cells[1].Value = monAn.Tenmon;
                row.Cells[2].Value = monAn.Dvt;
                row.Cells[3].Value = monAn.Giaban;
                row.Cells[4].Value = 1;
                row.Cells[5].Value = monAn.Giaban;
                dgvhoadon.Rows.Add(row);
            }
            else if (ma.Contains("TU") & !daTonTaiTrongDgv(ma))
            {
                ThucUong thucUong = new ThucUong(ma);
                row.Cells[0].Value = thucUong.Mathucuong;
                row.Cells[1].Value = thucUong.Tenthucuong;
                row.Cells[2].Value = thucUong.Dvt;
                row.Cells[3].Value = thucUong.Giaban;
                row.Cells[4].Value = 1;
                row.Cells[5].Value = thucUong.Giaban;
                dgvhoadon.Rows.Add(row);
            }
            else if (daTonTaiTrongDgv(ma))
            {
                MessageBox.Show("Món đã tồn tại trong thực đơn", "Thông báo");
            }
        }
        // xóa row dgv thực đơn.
        private void dgvhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 &&  dgvhoadon.Rows[e.RowIndex].Cells[0].Value !=null)
            {
                if (senderGrid.Rows[e.RowIndex].Tag==null)
                {
                    dgvhoadon.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    // Cấm hủy những món đã lưu trong hóa đơn.
                    if (e.RowIndex<Convert.ToInt16(senderGrid.Rows[e.RowIndex].Tag))
                    MessageBox.Show("Không cho phép hủy món đã gọi " + e.RowIndex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        dgvhoadon.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
        private void GoiMon_ResizeEnd(object sender, EventArgs e)
        {
            if(this.Width<1000)
            {
                pnThucDon.Width = this.Width / 2 - 40;
            }
            else
            {
                pnThucDon.Width = this.Width / 2 - 200 ;
            }
        }
        private void IconButton1_Click(object sender, EventArgs e)
        {
                activeButton();
        }
        private void Btnthucuong_Click(object sender, EventArgs e)
        {
            loadMonAnThucUong("thucuong");
        }
        private void Btnmonan_Click(object sender, EventArgs e)
        {
            loadMonAnThucUong("monan");
        }
        // check chỉ cho phép nhập số
        private void Dgvhoadon_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int rowindex = dgvhoadon.CurrentCell.RowIndex;
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvhoadon.CurrentCell.ColumnIndex == 4 ) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Dgvhoadon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if(Convert.ToInt16(dgvhoadon.Rows[e.RowIndex].Cells[4].Value)!=0)
                {
                    int soluong = Convert.ToInt16(dgvhoadon.Rows[e.RowIndex].Cells[4].Value);
                    int dongia = Convert.ToInt32(dgvhoadon.Rows[e.RowIndex].Cells["dongia"].Value);
                    int thanhtien = soluong * dongia;
                    dgvhoadon.Rows[e.RowIndex].Cells[5].Value = thanhtien;
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvhoadon.Rows[e.RowIndex].Cells[4].Value = 1;
                    int soluong = Convert.ToInt16(dgvhoadon.Rows[e.RowIndex].Cells[4].Value);
                    int dongia = Convert.ToInt32(dgvhoadon.Rows[e.RowIndex].Cells["dongia"].Value);
                    int thanhtien = soluong * dongia;
                    dgvhoadon.Rows[e.RowIndex].Cells[5].Value = thanhtien;
                }
            }
        }

        private void Btntim_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace( cbbtimtheo.Text))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm");
            }
            else
            {
                if (cbbtimtheo.Text.Contains("thấp"))
                {
                    if(rbtndoan.Checked)
                    {
                        loadMonAnThucUong("monan","giam");
                    }
                    else loadMonAnThucUong("thucuong", "giam");
                }
                else if(cbbtimtheo.Text.Contains("cao"))
                {
                    if (rbtndoan.Checked)
                    {
                        loadMonAnThucUong("monan", "cao");
                    }
                    else loadMonAnThucUong("thucuong", "cao");
                }
                else if(cbbtimtheo.Text.Contains("Mã") && !String.IsNullOrWhiteSpace(txttimkiem.Text))
                {

                }
                else if (cbbtimtheo.Text.Contains("Tên") && !String.IsNullOrWhiteSpace(txttimkiem.Text))
                {

                }
            }
        }
        private void Btngoimonthanhtoan_Click(object sender, EventArgs e)
        {
            Ban ban = btnthongtinban.Tag as Ban;
            if (ban != null)
            {
                if (ban.Trangthai.Contains("empty")) // đang gọi món
                {
                    goiMon(ban);
                }
                else if (ban.Trangthai.Contains("busy")) // đang gọi món
                {

                    thanhToan(ban);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn cần thao tác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void thanhToan(Ban ban)
        {
            if (String.IsNullOrWhiteSpace(txbtienkhachdua.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền khách đưa !");
            }
            else
            {
                // set lại bàn trống.
                String mahoadon = new BanDangHoatDong().getMaHoaDonFromMaBan(ban.Soban);
                HoaDon hd=new HoaDon(
                    mahoadon,
                    "KH000",
                    User.Manv,
                    DateTime.Now,
                    null,
                    "Tien mat",
                    ban.Soban,
                    "Đã thanh toán",
                    (float)(Convert.ToInt32(btnvat.Tag)),
                    Convert.ToInt32(btnthanhtien.Tag) + Convert.ToInt32(btnvat.Tag),
                    Convert.ToInt32(txbtienkhachdua.Text),
                    Convert.ToInt32(btntienthua.Tag));
                int res=hd.capNhatHoaDon();
                if (res < 1)
                {
                    MessageBox.Show("Lỗi");
                }
                else
                {
                    DialogResult result=MessageBox.Show("Thanh toán thành công. Bắt đầu in hóa đơn");
                    if(result==DialogResult.OK)
                    {
                        using (FormPrint f = new FormPrint(this, mahoadon))
                        {
                            f.ShowDialog();
                        }
                    }
                } 
                btnclear.PerformClick();
                new Ban().setEmpty(ban.Soban);
            }
        }

        private void goiMon(Ban ban)
        {
            if (dgvhoadon.Rows[0].Cells["mamon"].Value==null)
            {
                MessageBox.Show("Vui lòng chọn thực đơn !");
            }
            else
            {
                String mahoadon = new HoaDon().taoMaHoaDon();
                // chuyển trạng thái bàn
                int result = new Ban().setBusy(ban.Soban);
                if (result == 0)
                {
                    MessageBox.Show("Lỗi chuyển trạng thái bàn");
                }
                // Không được bỏ trống mahd, manv, ngaylap, soban, request -- TẠO HÓA ĐƠN
                HoaDon hoaDon = new HoaDon(mahoadon, "KH000", User.Manv, DateTime.Now, "", "", ban.Soban, "Chưa thanh toán", (float)0.1, 0, 0, 0);
                int resultTaoHoaDon = hoaDon.taoHoaDon(hoaDon);
                if (resultTaoHoaDon == 0)
                {
                    MessageBox.Show("Lỗi chuyển Tạo hóa đơn");
                }
                // tạo chi tiết hóa đơn.
                int countError = 0;
                foreach (DataGridViewRow row in dgvhoadon.Rows)
                {
                    int res = 0;
                    if (row.Cells["mamon"].Value!=null)
                    {
                        ChiTietHoaDon cthd = new ChiTietHoaDon();
                        if (row.Cells["mamon"].Value.ToString().Contains("MA")) // is food
                        {
                            cthd = new ChiTietHoaDon(mahoadon,
                            row.Cells["mamon"].Value.ToString(),
                            "KM000",
                            Convert.ToInt16(row.Cells["soluong"].Value),
                            "",
                            Convert.ToInt32(row.Cells["dongia"].Value),"");
                            res = cthd.insertChiTietHoaDon("monan");
                        }
                        else if (row.Cells["mamon"].Value.ToString().Contains("TU")) // is drink
                        {
                            cthd = new ChiTietHoaDon(mahoadon,
                           row.Cells["mamon"].Value.ToString(),
                            "KM000",
                            Convert.ToInt16(row.Cells["soluong"].Value),
                            "",
                            Convert.ToInt32(row.Cells["dongia"].Value),"");
                            res = cthd.insertChiTietHoaDon("thucuong");
                        }
                         
                        if (res == 0)
                        {
                            countError++;
                        }
                    }
                }
                MessageBox.Show("Thành công ! Số lỗi = "+countError);
                dgvhoadon.Rows.Clear();
            }
        }
        private void Btnclear_Click(object sender, EventArgs e)
        {
            dgvhoadon.Rows.Clear();
            btnthongtinban.Text = "Thông tin bàn";
            btnthongtinban.Tag = null;
            btntrangthai.Text = "Đang thực hiện";
            ClearThanhToanInfo();
        }
        private int count = 0;
        private void Txttimkiem_MouseClick(object sender, MouseEventArgs e)
        {
            count++;
            if(count ==1)
            {
                txttimkiem.Clear();
            }
        }
        private void BtnCapnhathoadon_Click(object sender, EventArgs e)
        {
            Ban ban = btnthongtinban.Tag as Ban;
            if (ban == null) return;
            if (ban.Trangthai.Contains("busy"))
            {
                String mahoadon = new BanDangHoatDong().getMaHoaDonFromMaBan(ban.Soban);
                int countError = 0;
                foreach (DataGridViewRow row in dgvhoadon.Rows)
                {
                    int res = 0;
                    if (row.Cells["mamon"].Value != null)
                    {
                        ChiTietHoaDon cthd = new ChiTietHoaDon();
                        if (row.Cells["mamon"].Value.ToString().Contains("MA")) // is food
                        {
                            cthd = new ChiTietHoaDon(mahoadon,
                            row.Cells["mamon"].Value.ToString(),
                            "KM000",
                            Convert.ToInt16(row.Cells["soluong"].Value),
                            "",
                            Convert.ToInt32(row.Cells["dongia"].Value), "");
                            res = cthd.insertChiTietHoaDon("monan");
                        }
                        else if (row.Cells["mamon"].Value.ToString().Contains("TU")) // is drink
                        {
                            cthd = new ChiTietHoaDon(mahoadon,
                           row.Cells["mamon"].Value.ToString(),
                            "KM000",
                            Convert.ToInt16(row.Cells["soluong"].Value),
                            "",
                            Convert.ToInt32(row.Cells["dongia"].Value), "");
                            res = cthd.insertChiTietHoaDon("thucuong");
                        }

                        if (res == 0)
                        {
                            countError++;
                        }
                    }
                }
                MessageBox.Show("Cập nhật thành công ! Số lỗi = " + countError);
                dgvhoadon.Rows.Clear();

            }
        }
        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            
        }
        private void Txbtienkhachdua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter&& !String.IsNullOrWhiteSpace(txbtienkhachdua.Text))
            {
                float tienSauChietKhau = 0;
                // số tiền nhập vào phải lớn hơn tổng tiền + vat
                if (Convert.ToInt64(txbchietkhau.Tag)<100) // chiết khấu theo %
                {
                    tienSauChietKhau =(float)(100- Convert.ToInt64(txbchietkhau.Tag))/100* (float)(Convert.ToInt64(btnthanhtien.Tag) + Convert.ToInt64(btnvat.Tag));
                }
                else
                {
                    tienSauChietKhau = Convert.ToInt64(btnthanhtien.Tag) + Convert.ToInt64(btnvat.Tag) - Convert.ToInt64(txbchietkhau.Tag);
                }
                if (Convert.ToInt64(txbtienkhachdua.Text) < tienSauChietKhau)
                {
                    MessageBox.Show("Số tiền không hợp lệ !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbtienkhachdua.Text = "";
                }
                else
                {
                    float tienthua = Convert.ToInt64(txbtienkhachdua.Text) - tienSauChietKhau;
                    btntienthua.ButtonText = tienthua.ToString("C0");
                    btntienthua.Tag = tienthua;
                }
            }
        }
        private void Txbchietkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter&& !String.IsNullOrWhiteSpace(txbchietkhau.Text))
            {
                long value = Convert.ToInt64(txbchietkhau.Text);
                if (value <100)
                {
                    txbchietkhau.Text = value.ToString();
                }
                else
                {
                    txbchietkhau.Text = value.ToString();
                }
                txbchietkhau.Tag = value;
                Txbtienkhachdua_KeyDown(sender,e);
            }
        }
        private void Btnbaochebien_Click(object sender, EventArgs e)
        {
            Ban bandangchon = (btnthongtinban.Tag as Ban);
            if (bandangchon==null)
            {
                MessageBox.Show("Chọn bàn !");
            }
            else
            {
                using (FormPrint f = new FormPrint(this, new BanDangHoatDong().getMaHoaDonFromMaBan((btnthongtinban.Tag as Ban).Soban)))
                {
                    f.ShowDialog();
                }
            }
        }
        #endregion events
    }
}
