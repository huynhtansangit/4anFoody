using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MetroFramework.Forms;
namespace Viva_vegan

{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        //Fields
        private IconButton currentButton;
        // line active button
        private Panel leftBorderBtn;
        FormDashboard.BangDieuKhien dashBoard;
        //form con 
        private Form currentChildForm;
        public Dashboard()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToLongDateString();
            StartTimer();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(4, 46);
            pnNavi.Controls.Add(leftBorderBtn);
            setTenNhanVien();

        }
        //ClassCSharp.User.Ngayvaolam.ToString("dd/MM/yyyy")
        private void setTenNhanVien ()
        {
            lblchao.Text = "Hello, " +
                ClassCSharp.User.Tennv;
        }
        private void minimizeDashboard(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(252, 68, 68);
            public static Color color2 = Color.FromArgb(252, 68, 68);
            public static Color color3 = Color.FromArgb(252, 68, 68);
            public static Color color4 = Color.FromArgb(252, 68, 68);
            public static Color color5 = Color.FromArgb(252, 68, 68);
            public static Color color6 = Color.FromArgb(252, 68, 68);
        }
        //Methods
        private void openChildForm (Form childForm)
        {
            if (currentChildForm !=null)
            {
                // chỉ mở một form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pndesktop.Controls.Add(childForm);
            pndesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void activeButton (object sender, Color color)
        {
            disableButton();
            if (sender!=null)
            {
                currentButton = (IconButton)sender;
                currentButton.BackColor = Color.WhiteSmoke;
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                //left border panel
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //icon and label form hiện tại
                iconFormhientai.IconChar = currentButton.IconChar;
                iconFormhientai.IconColor = Color.White;
                lbltenformhientai.Text = currentButton.Text;
                lbltenformhientai.ForeColor = Color.FromArgb(6, 56, 108); ;
            }
        }
        private void disableButton ()
        {
            if(currentButton!=null)
            {
                currentButton.BackColor = Color.White;
                currentButton.ForeColor = Color.FromArgb(5, 56, 107);
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.FromArgb(5, 56, 107);
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void Btnbangdieukhien_Click(object sender, EventArgs e)
        {
            if (ClassCSharp.User.Macv !="CVQL")
            {
                MessageBox.Show("Xin lỗi! Bạn không có quyền truy cập mục này","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                activeButton(sender, RGBColors.color1);
                dashBoard = new FormDashboard.BangDieuKhien();
                dashBoard.ReclickRequest += minimizeDashboard;
                openChildForm(dashBoard);
                // kiểm tra nếu tài khoản là admin mới được truy cập bảng điều khiển
                // không thì disabled
                //dashBoard.Enabled = false;
            }
        }

        private void Btnbieudo_Click(object sender, EventArgs e)
        {
            activeButton(sender, RGBColors.color2);
            openChildForm(new FormDashboard.DoanhThu());
        }

        private void Btngoimon_Click(object sender, EventArgs e)
        {
            activeButton(sender, RGBColors.color3);
            openChildForm(new FormDashboard.GoiMon());
        }

        private void Btnhoatdong_Click(object sender, EventArgs e)
        {
            activeButton(sender, RGBColors.color4);
            openChildForm(new FormDashboard.HoatDongGanDay());
        }

        private void Btnthanhtoan_Click(object sender, EventArgs e)
        {
            activeButton(sender, RGBColors.color5);
            openChildForm(new FormDashboard.ThanhToan());
        }

        private void Btnthongtin_Click(object sender, EventArgs e)
        {
            activeButton(sender, RGBColors.color6);
            openChildForm(new FormDashboard.ThongTin());
        }

        private void Btntrangchu_Click(object sender, EventArgs e)
        {
            Reset();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }
        private void Reset()
        {
            disableButton();
            leftBorderBtn.Visible = false;
            iconFormhientai.IconChar = IconChar.Home;
            iconFormhientai.IconColor = Color.FromArgb(6, 56, 108);
            lbltenformhientai.Text = "Home";
            lbltenformhientai.ForeColor = Color.FromArgb(6, 56, 108);
        }

        private void LblTime_Click(object sender, EventArgs e)
        {

        }

        private void Btnfacebook_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/dove.fonghoatuyetnguyet");
        }

        private void IconButton6_Click_1(object sender, EventArgs e)
        {
            String phoneContact = "0868952131";
            String emailContact = "huynhtansangit1999@gmail.com";
            String message = String.Format("Số điện thoại: {0}\nEmail: {1}", phoneContact, emailContact);
            MessageBox.Show(message, "Thông tin liên hệ",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
        }

        private void Btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đăng xuất khỏi ứng dụng ?", "Confirmation", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Btntwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4anvegetarian.vn");
        }
        
    }
}
