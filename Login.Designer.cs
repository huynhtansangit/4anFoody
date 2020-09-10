namespace Viva_vegan
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pnBannerLeft = new System.Windows.Forms.Panel();
            this.pnline1 = new XanderUI.XUIGradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnthoat = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLogo_login = new System.Windows.Forms.PictureBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btndangnhap = new FontAwesome.Sharp.IconButton();
            this.cbshowpass = new XanderUI.XUICheckBox();
            this.lblChuyensangdky = new System.Windows.Forms.Label();
            this.lblmatkhau = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnBannerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo_login)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBannerLeft
            // 
            this.pnBannerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.pnBannerLeft.Controls.Add(this.pnline1);
            this.pnBannerLeft.Controls.Add(this.label3);
            this.pnBannerLeft.Controls.Add(this.btnthoat);
            this.pnBannerLeft.Controls.Add(this.label1);
            this.pnBannerLeft.Controls.Add(this.pictureBox1);
            this.pnBannerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBannerLeft.Location = new System.Drawing.Point(0, 0);
            this.pnBannerLeft.Name = "pnBannerLeft";
            this.pnBannerLeft.Size = new System.Drawing.Size(360, 485);
            this.pnBannerLeft.TabIndex = 0;
            // 
            // pnline1
            // 
            this.pnline1.BottomLeft = System.Drawing.Color.Gray;
            this.pnline1.BottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnline1.Location = new System.Drawing.Point(3, 424);
            this.pnline1.Name = "pnline1";
            this.pnline1.PrimerColor = System.Drawing.Color.White;
            this.pnline1.Size = new System.Drawing.Size(383, 2);
            this.pnline1.Style = XanderUI.XUIGradientPanel.GradientStyle.Corners;
            this.pnline1.TabIndex = 4;
            this.pnline1.TopLeft = System.Drawing.Color.Teal;
            this.pnline1.TopRight = System.Drawing.Color.Indigo;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 44);
            this.label3.TabIndex = 3;
            this.label3.Text = "Change What You Eat\r\nChange The World.";
            // 
            // btnthoat
            // 
            this.btnthoat.FlatAppearance.BorderSize = 0;
            this.btnthoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.btnthoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(150)))), ((int)(((byte)(131)))));
            this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthoat.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnthoat.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnthoat.IconColor = System.Drawing.Color.Black;
            this.btnthoat.IconSize = 25;
            this.btnthoat.Location = new System.Drawing.Point(0, 0);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnthoat.Rotation = 0D;
            this.btnthoat.Size = new System.Drawing.Size(40, 40);
            this.btnthoat.TabIndex = 2;
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.IBtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.pictureBox1.BackgroundImage = global::Viva_vegan.Properties.Resources.banner_login;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(87, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 420);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pbLogo_login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(360, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 126);
            this.panel1.TabIndex = 1;
            // 
            // pbLogo_login
            // 
            this.pbLogo_login.BackgroundImage = global::Viva_vegan.Properties.Resources.an1;
            this.pbLogo_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo_login.Location = new System.Drawing.Point(53, -51);
            this.pbLogo_login.Name = "pbLogo_login";
            this.pbLogo_login.Size = new System.Drawing.Size(197, 216);
            this.pbLogo_login.TabIndex = 0;
            this.pbLogo_login.TabStop = false;
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Minion Pro SmBd", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(26, 39);
            this.txtusername.Multiline = true;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(264, 25);
            this.txtusername.TabIndex = 2;
            this.txtusername.Text = "kimtoa";
            this.txtusername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btndangnhap);
            this.panel2.Controls.Add(this.cbshowpass);
            this.panel2.Controls.Add(this.lblChuyensangdky);
            this.panel2.Controls.Add(this.lblmatkhau);
            this.panel2.Controls.Add(this.txtpassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtusername);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Minion Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(360, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 378);
            this.panel2.TabIndex = 2;
            // 
            // btndangnhap
            // 
            this.btndangnhap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btndangnhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btndangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndangnhap.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btndangnhap.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangnhap.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btndangnhap.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btndangnhap.IconColor = System.Drawing.Color.DodgerBlue;
            this.btndangnhap.IconSize = 30;
            this.btndangnhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndangnhap.Location = new System.Drawing.Point(63, 199);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btndangnhap.Rotation = 0D;
            this.btndangnhap.Size = new System.Drawing.Size(187, 44);
            this.btndangnhap.TabIndex = 12;
            this.btndangnhap.Text = "Đăng nhập";
            this.btndangnhap.UseVisualStyleBackColor = false;
            this.btndangnhap.Click += new System.EventHandler(this.Btndangnhap_Click);
            // 
            // cbshowpass
            // 
            this.cbshowpass.CheckboxCheckColor = System.Drawing.Color.White;
            this.cbshowpass.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(129)))), ((int)(((byte)(60)))));
            this.cbshowpass.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.cbshowpass.CheckboxStyle = XanderUI.XUICheckBox.Style.Material;
            this.cbshowpass.Checked = false;
            this.cbshowpass.Font = new System.Drawing.Font("Minion Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbshowpass.ForeColor = System.Drawing.Color.Black;
            this.cbshowpass.Location = new System.Drawing.Point(26, 142);
            this.cbshowpass.Name = "cbshowpass";
            this.cbshowpass.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.cbshowpass.Size = new System.Drawing.Size(136, 19);
            this.cbshowpass.TabIndex = 11;
            this.cbshowpass.Text = "Hiện mật khẩu";
            this.cbshowpass.TickThickness = 2;
            this.cbshowpass.CheckedStateChanged += new System.EventHandler(this.XuiCheckBox1_CheckedStateChanged);
            // 
            // lblChuyensangdky
            // 
            this.lblChuyensangdky.AutoSize = true;
            this.lblChuyensangdky.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuyensangdky.Location = new System.Drawing.Point(75, 256);
            this.lblChuyensangdky.Name = "lblChuyensangdky";
            this.lblChuyensangdky.Size = new System.Drawing.Size(150, 22);
            this.lblChuyensangdky.TabIndex = 10;
            this.lblChuyensangdky.Text = "Tôi chưa có tài khoản";
            this.lblChuyensangdky.Click += new System.EventHandler(this.LblChuyensangdky_Click);
            this.lblChuyensangdky.MouseLeave += new System.EventHandler(this.LblChuyensangdky_MouseLeave);
            this.lblChuyensangdky.MouseHover += new System.EventHandler(this.LblChuyensangdky_MouseHover);
            // 
            // lblmatkhau
            // 
            this.lblmatkhau.AutoSize = true;
            this.lblmatkhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblmatkhau.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmatkhau.Location = new System.Drawing.Point(26, 76);
            this.lblmatkhau.Name = "lblmatkhau";
            this.lblmatkhau.Size = new System.Drawing.Size(72, 22);
            this.lblmatkhau.TabIndex = 5;
            this.lblmatkhau.Text = "Mật khẩu";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Minion Pro SmBd", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(26, 101);
            this.txtpassword.Multiline = true;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(264, 25);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.Text = "toa123";
            this.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đăng nhập";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(685, 485);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnBannerLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.pnBannerLeft.ResumeLayout(false);
            this.pnBannerLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo_login)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBannerLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbLogo_login;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblmatkhau;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnthoat;
        private XanderUI.XUICheckBox cbshowpass;
        private System.Windows.Forms.Label lblChuyensangdky;
        private XanderUI.XUIGradientPanel pnline1;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btndangnhap;
    }
}