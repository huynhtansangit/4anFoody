namespace Viva_vegan.FormDashboard
{
    partial class BaoCao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnxuatbaocao = new FontAwesome.Sharp.IconButton();
            this.btnxembaocao = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDenngay = new System.Windows.Forms.DateTimePicker();
            this.dtpTungay = new System.Windows.Forms.DateTimePicker();
            this.dgvHoadon = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnxuatbaocao);
            this.panel1.Controls.Add(this.btnxembaocao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDenngay);
            this.panel1.Controls.Add(this.dtpTungay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 245);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(438, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Double click vào bất kỳ hàng nào để xem chi tiết hóa đơn";
            // 
            // btnxuatbaocao
            // 
            this.btnxuatbaocao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnxuatbaocao.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxuatbaocao.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnxuatbaocao.IconColor = System.Drawing.Color.Black;
            this.btnxuatbaocao.IconSize = 20;
            this.btnxuatbaocao.Location = new System.Drawing.Point(481, 39);
            this.btnxuatbaocao.Name = "btnxuatbaocao";
            this.btnxuatbaocao.Rotation = 0D;
            this.btnxuatbaocao.Size = new System.Drawing.Size(155, 36);
            this.btnxuatbaocao.TabIndex = 9;
            this.btnxuatbaocao.Text = "Xuất";
            this.btnxuatbaocao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxuatbaocao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnxuatbaocao.UseVisualStyleBackColor = true;
            this.btnxuatbaocao.Click += new System.EventHandler(this.Btnxuatbaocao_Click);
            // 
            // btnxembaocao
            // 
            this.btnxembaocao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnxembaocao.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxembaocao.IconChar = FontAwesome.Sharp.IconChar.StickyNote;
            this.btnxembaocao.IconColor = System.Drawing.Color.Black;
            this.btnxembaocao.IconSize = 20;
            this.btnxembaocao.Location = new System.Drawing.Point(320, 39);
            this.btnxembaocao.Name = "btnxembaocao";
            this.btnxembaocao.Rotation = 0D;
            this.btnxembaocao.Size = new System.Drawing.Size(155, 36);
            this.btnxembaocao.TabIndex = 8;
            this.btnxembaocao.Text = "Xem";
            this.btnxembaocao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxembaocao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnxembaocao.UseVisualStyleBackColor = true;
            this.btnxembaocao.Click += new System.EventHandler(this.Btnxembaocao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ";
            // 
            // dtpDenngay
            // 
            this.dtpDenngay.Location = new System.Drawing.Point(380, 6);
            this.dtpDenngay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDenngay.Name = "dtpDenngay";
            this.dtpDenngay.Size = new System.Drawing.Size(256, 26);
            this.dtpDenngay.TabIndex = 5;
            // 
            // dtpTungay
            // 
            this.dtpTungay.Location = new System.Drawing.Point(61, 6);
            this.dtpTungay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTungay.Name = "dtpTungay";
            this.dtpTungay.Size = new System.Drawing.Size(256, 26);
            this.dtpTungay.TabIndex = 4;
            // 
            // dgvHoadon
            // 
            this.dgvHoadon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoadon.Location = new System.Drawing.Point(0, 245);
            this.dgvHoadon.Name = "dgvHoadon";
            this.dgvHoadon.ReadOnly = true;
            this.dgvHoadon.RowTemplate.Height = 35;
            this.dgvHoadon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoadon.Size = new System.Drawing.Size(984, 482);
            this.dgvHoadon.TabIndex = 6;
            this.dgvHoadon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHoadon_CellDoubleClick);
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.ClientSize = new System.Drawing.Size(984, 727);
            this.Controls.Add(this.dgvHoadon);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaoCao";
            this.Text = "Báo Cáo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpDenngay;
        public System.Windows.Forms.DateTimePicker dtpTungay;
        public FontAwesome.Sharp.IconButton btnxuatbaocao;
        public FontAwesome.Sharp.IconButton btnxembaocao;
        public System.Windows.Forms.DataGridView dgvHoadon;
        public System.Windows.Forms.Label label3;
    }
}