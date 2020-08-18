using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Viva_vegan.FormDashboard
{
    public partial class BangDieuKhien : Form
    {
        public BangDieuKhien()
        {
            InitializeComponent();
        }

        private void Btnthemnhanvien_Click(object sender, EventArgs e)
        {
            saveHistory();
        }
        private void saveHistory()
        {
            String mabp = cbbmabp.SelectedItem.ToString();
            String macv = cbbmacv.SelectedItem.ToString();
            String ten = txttennv.Text;
            String sdt = txtsodt.Text;
            String email = txtemail.Text;
            String diachi = txtdiachi.Text;
            String sotk = txtsotk.Text;
            String tendangnhap = txttendangnhap.Text;
            String matkhau = txtmatkhau.Text;
            String ngaythem = DateTime.Now.ToLongDateString();
            String[] mangNhanvien = { macv, mabp, ten, sdt, email, diachi, sotk, tendangnhap, matkhau , ngaythem };
            String content = String.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}{8} - {9}", mangNhanvien);
            //System.IO.File.WriteLine(@"C:\Users\Public\TestFolder\WriteText.txt", text);
            using (StreamWriter sw = new StreamWriter(File.Open(@".\Staff_history.txt", FileMode.Append), Encoding.Unicode))
            {
                sw.WriteLine(content);
            }
        }

        private void XuiButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\Staff_history.txt");
            ThuNhoFormCha();
        }

        public event EventHandler ReclickRequest;

        private void ThuNhoFormCha()
        {
            OnReclickRequest(EventArgs.Empty);
        }

        protected virtual void OnReclickRequest(EventArgs e)
        {
            EventHandler eh = ReclickRequest;
            if (eh != null)
                eh(this, e);
        }

        private void Btnchonanh_Click(object sender, EventArgs e)
        {
            imgboxxemtruoc.SizeMode = PictureBoxSizeMode.StretchImage;
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
                {
                    lblpath.Text = dialog.FileName;
                    imgboxxemtruoc.ImageLocation = lblpath.Text.ToString();
                }
            }
            catch (Exception) {
                MessageBox.Show("Error");
            }
        }
    }
}
