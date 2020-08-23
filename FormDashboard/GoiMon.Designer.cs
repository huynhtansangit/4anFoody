namespace Viva_vegan.FormDashboard
{
    partial class GoiMon
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
            this.pnBan = new System.Windows.Forms.Panel();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.cbbkhuvuc = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBan
            // 
            this.pnBan.Controls.Add(this.flpBan);
            this.pnBan.Controls.Add(this.cbbkhuvuc);
            this.pnBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBan.Location = new System.Drawing.Point(0, 0);
            this.pnBan.Name = "pnBan";
            this.pnBan.Size = new System.Drawing.Size(710, 596);
            this.pnBan.TabIndex = 3;
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 27);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.flpBan.Size = new System.Drawing.Size(710, 569);
            this.flpBan.TabIndex = 4;
            // 
            // cbbkhuvuc
            // 
            this.cbbkhuvuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cbbkhuvuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbkhuvuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbkhuvuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbkhuvuc.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbkhuvuc.FormattingEnabled = true;
            this.cbbkhuvuc.ItemHeight = 19;
            this.cbbkhuvuc.Location = new System.Drawing.Point(0, 0);
            this.cbbkhuvuc.Name = "cbbkhuvuc";
            this.cbbkhuvuc.Size = new System.Drawing.Size(710, 27);
            this.cbbkhuvuc.TabIndex = 3;
            this.cbbkhuvuc.SelectedIndexChanged += new System.EventHandler(this.Cbbkhuvuc_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(710, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 210);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(710, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 386);
            this.panel2.TabIndex = 5;
            // 
            // GoiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.ClientSize = new System.Drawing.Size(1096, 596);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnBan);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GoiMon";
            this.Text = "GoiMon";
            this.Resize += new System.EventHandler(this.GoiMon_ResizeEnd);
            this.pnBan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBan;
        private System.Windows.Forms.ComboBox cbbkhuvuc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
    }
}