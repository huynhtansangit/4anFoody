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
namespace Viva_vegan.FormDashboard
{
    public partial class GoiMon : Form
    {
        private List<KhuVuc> khuvucs = new List<KhuVuc>();
        public GoiMon()
        {
            InitializeComponent();
            loadKhuVuc();
            loadBan("");
        }

       


        #region Methods
        private void loadBan(String khuvuc)
        {
            flpBan.Controls.Clear();
            List<Ban> bans = new Ban().loadList("");
            if (!String.IsNullOrWhiteSpace(khuvuc))
            {
                bans = new Ban().loadList(khuvuc);
            }
            foreach (Ban item in bans)
            {
                XUICustomGroupbox grbBtn = createCustomBtn(item.Tenban, item.Trangthai, item.Makhuvuc);
                flpBan.Controls.Add(grbBtn);

            }
        }
        private void loadKhuVuc()
        {
            khuvucs = new KhuVuc().loadListKhuVuc();
            foreach(KhuVuc item in khuvucs)
            {
                cbbkhuvuc.Items.Add(item.Tenkhuvuc);
            }
            cbbkhuvuc.Items.Add("Tất cả");
        }
        private XUICustomGroupbox createCustomBtn (String text,String tinhtrang, String khuvuc)
        {
            XUICustomGroupbox grbBan = new XUICustomGroupbox();
            IconButton ibutton = new IconButton();
            Label lbltenban = new Label();

            lbltenban.AutoSize = true;
            lbltenban.Font = new System.Drawing.Font("Adobe Heiti Std R", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lbltenban.Size = new System.Drawing.Size(48, 16);
            lbltenban.TabIndex = 2;
            lbltenban.Text = text+" - "+ khuvuc;
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
            // group box
            grbBan.BorderWidth = 1;
            grbBan.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grbBan.ShowText = true;
            grbBan.Size = new System.Drawing.Size(115, 120);
            grbBan.TabIndex = 0;
            grbBan.TabStop = false;
            grbBan.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);

            if (tinhtrang.Contains("empty"))
            {
                Console.WriteLine("free");
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

        #endregion

        #region Events
        private void Cbbkhuvuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            String makv = "";
            foreach (KhuVuc item in khuvucs)
            {
                if(item.Tenkhuvuc==cbbkhuvuc.Text)
                {
                    makv = item.Makhuvuc;
                }
            }
            loadBan(makv);
        }
        private void GoiMon_ResizeEnd(object sender, EventArgs e)
        {
            if(this.Width<948)
            {
                pnBan.Width = this.Width / 2 - 40;
            }
            else
            {
                pnBan.Width = this.Width / 2 - 90 ;
            }
        }
        #endregion
    }
}
