namespace Viva_vegan.FormDashboard.GoiMonChild
{
    partial class FormBan
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
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.cbbkhuvuc = new System.Windows.Forms.ComboBox();
            this.xuiGradientPanel1 = new XanderUI.XUIGradientPanel();
            this.SuspendLayout();
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(219)))), ((int)(((byte)(149)))));
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 27);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.flpBan.Size = new System.Drawing.Size(800, 423);
            this.flpBan.TabIndex = 14;
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
            this.cbbkhuvuc.Size = new System.Drawing.Size(800, 27);
            this.cbbkhuvuc.TabIndex = 13;
            this.cbbkhuvuc.SelectedIndexChanged += new System.EventHandler(this.Cbbkhuvuc_SelectedIndexChanged);
            // 
            // xuiGradientPanel1
            // 
            this.xuiGradientPanel1.BottomLeft = System.Drawing.Color.Blue;
            this.xuiGradientPanel1.BottomRight = System.Drawing.Color.MediumTurquoise;
            this.xuiGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xuiGradientPanel1.Location = new System.Drawing.Point(0, 27);
            this.xuiGradientPanel1.Name = "xuiGradientPanel1";
            this.xuiGradientPanel1.PrimerColor = System.Drawing.Color.White;
            this.xuiGradientPanel1.Size = new System.Drawing.Size(2, 423);
            this.xuiGradientPanel1.Style = XanderUI.XUIGradientPanel.GradientStyle.Corners;
            this.xuiGradientPanel1.TabIndex = 15;
            this.xuiGradientPanel1.TopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.xuiGradientPanel1.TopRight = System.Drawing.Color.Red;
            // 
            // FormBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xuiGradientPanel1);
            this.Controls.Add(this.flpBan);
            this.Controls.Add(this.cbbkhuvuc);
            this.Name = "FormBan";
            this.Text = "Ban";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.ComboBox cbbkhuvuc;
        private XanderUI.XUIGradientPanel xuiGradientPanel1;
    }
}