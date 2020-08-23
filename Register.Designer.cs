namespace Viva_vegan
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.cardThongtin = new XanderUI.XUICard();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnhap = new System.Windows.Forms.TextBox();
            this.btntim = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txttendangnhap = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbketquatim = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndangky = new FontAwesome.Sharp.IconButton();
            this.btntrolai = new FontAwesome.Sharp.IconButton();
            this.xuiGradientPanel1 = new XanderUI.XUIGradientPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardThongtin
            // 
            this.cardThongtin.BackColor = System.Drawing.Color.Transparent;
            this.cardThongtin.Color1 = System.Drawing.Color.DodgerBlue;
            this.cardThongtin.Color2 = System.Drawing.Color.LimeGreen;
            this.cardThongtin.ForeColor = System.Drawing.Color.White;
            this.cardThongtin.Location = new System.Drawing.Point(12, 13);
            this.cardThongtin.Name = "cardThongtin";
            this.cardThongtin.Size = new System.Drawing.Size(354, 210);
            this.cardThongtin.TabIndex = 0;
            this.cardThongtin.Text = "xuiCard1";
            this.cardThongtin.Text1 = "Họ tên";
            this.cardThongtin.Text2 = "Số tài khoản";
            this.cardThongtin.Text3 = "Ngày vào làm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(457, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập mã nhân viên hoặc tên";
            // 
            // txtnhap
            // 
            this.txtnhap.Location = new System.Drawing.Point(374, 34);
            this.txtnhap.Name = "txtnhap";
            this.txtnhap.Size = new System.Drawing.Size(272, 22);
            this.txtnhap.TabIndex = 2;
            this.txtnhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtnhap_KeyDown);
            // 
            // btntim
            // 
            this.btntim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntim.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btntim.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntim.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btntim.IconColor = System.Drawing.Color.Black;
            this.btntim.IconSize = 22;
            this.btntim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntim.Location = new System.Drawing.Point(548, 62);
            this.btntim.Name = "btntim";
            this.btntim.Rotation = 0D;
            this.btntim.Size = new System.Drawing.Size(98, 28);
            this.btntim.TabIndex = 3;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.Btntim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(548, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txttendangnhap
            // 
            this.txttendangnhap.Location = new System.Drawing.Point(374, 151);
            this.txttendangnhap.Name = "txttendangnhap";
            this.txttendangnhap.Size = new System.Drawing.Size(272, 22);
            this.txttendangnhap.TabIndex = 6;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(374, 200);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(272, 22);
            this.txtpassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(583, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // cbbketquatim
            // 
            this.cbbketquatim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbketquatim.FormattingEnabled = true;
            this.cbbketquatim.Location = new System.Drawing.Point(374, 96);
            this.cbbketquatim.Name = "cbbketquatim";
            this.cbbketquatim.Size = new System.Drawing.Size(272, 22);
            this.cbbketquatim.TabIndex = 10;
            this.cbbketquatim.SelectedIndexChanged += new System.EventHandler(this.Cbbketquatim_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btndangky);
            this.panel1.Controls.Add(this.btntrolai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 35);
            this.panel1.TabIndex = 11;
            // 
            // btndangky
            // 
            this.btndangky.Dock = System.Windows.Forms.DockStyle.Right;
            this.btndangky.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndangky.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btndangky.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangky.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btndangky.IconColor = System.Drawing.Color.Black;
            this.btndangky.IconSize = 22;
            this.btndangky.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndangky.Location = new System.Drawing.Point(374, 0);
            this.btndangky.Name = "btndangky";
            this.btndangky.Rotation = 0D;
            this.btndangky.Size = new System.Drawing.Size(279, 35);
            this.btndangky.TabIndex = 11;
            this.btndangky.Text = "Đăng ký";
            this.btndangky.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndangky.UseVisualStyleBackColor = true;
            this.btndangky.Click += new System.EventHandler(this.Btndangky_Click);
            // 
            // btntrolai
            // 
            this.btntrolai.Dock = System.Windows.Forms.DockStyle.Left;
            this.btntrolai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btntrolai.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btntrolai.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntrolai.IconChar = FontAwesome.Sharp.IconChar.Backward;
            this.btntrolai.IconColor = System.Drawing.Color.Black;
            this.btntrolai.IconSize = 22;
            this.btntrolai.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntrolai.Location = new System.Drawing.Point(0, 0);
            this.btntrolai.Name = "btntrolai";
            this.btntrolai.Rotation = 0D;
            this.btntrolai.Size = new System.Drawing.Size(375, 35);
            this.btntrolai.TabIndex = 10;
            this.btntrolai.Text = "Trở lại đăng nhập";
            this.btntrolai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btntrolai.UseVisualStyleBackColor = true;
            this.btntrolai.Click += new System.EventHandler(this.Btntrolai_Click);
            // 
            // xuiGradientPanel1
            // 
            this.xuiGradientPanel1.BottomLeft = System.Drawing.Color.Black;
            this.xuiGradientPanel1.BottomRight = System.Drawing.Color.Fuchsia;
            this.xuiGradientPanel1.Location = new System.Drawing.Point(360, 128);
            this.xuiGradientPanel1.Name = "xuiGradientPanel1";
            this.xuiGradientPanel1.PrimerColor = System.Drawing.Color.White;
            this.xuiGradientPanel1.Size = new System.Drawing.Size(292, 2);
            this.xuiGradientPanel1.Style = XanderUI.XUIGradientPanel.GradientStyle.Corners;
            this.xuiGradientPanel1.TabIndex = 12;
            this.xuiGradientPanel1.TopLeft = System.Drawing.Color.DeepSkyBlue;
            this.xuiGradientPanel1.TopRight = System.Drawing.Color.Fuchsia;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 263);
            this.Controls.Add(this.cardThongtin);
            this.Controls.Add(this.xuiGradientPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbbketquatim);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttendangnhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btntim);
            this.Controls.Add(this.txtnhap);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XanderUI.XUICard cardThongtin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnhap;
        private FontAwesome.Sharp.IconButton btntim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttendangnhap;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbketquatim;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btndangky;
        private FontAwesome.Sharp.IconButton btntrolai;
        private XanderUI.XUIGradientPanel xuiGradientPanel1;
    }
}