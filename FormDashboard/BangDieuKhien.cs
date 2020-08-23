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
using System.Data.SqlClient;
using Viva_vegan.ClassCSharp;

namespace Viva_vegan.FormDashboard
{
    public partial class BangDieuKhien : Form
    {
        // Khai báo
        private List<ClassCSharp.KhuVuc> listKhuvuc = new List<ClassCSharp.KhuVuc>();
        private List<ClassCSharp.ChucVu> listChucvu = new List<ClassCSharp.ChucVu>();
        private List<ClassCSharp.BoPhan> listBophan = new List<ClassCSharp.BoPhan>();
        private Ban objBan=new Ban();
        private NhanVien objNhanVien = new NhanVien();
        
        // Hết khai báo

        public BangDieuKhien()
        {
            InitializeComponent();
            // tab bàn
            loadKhuvuc();
            loadBan();
            //tab nhân viên
            loadNhanVien("");
            loadMachucvu();
            loadMabophan();
            // tab món ăn
            loadMonan("");
            //tab đồ uống
        }

        

        #region Events
        private void Btnthemnhanvien_Click(object sender, EventArgs e)
        {
            saveHistory("them");
        }

        private void XuiButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\Staff_history.txt");
            ThuNhoFormCha();
        }

        public event EventHandler ReclickRequest;

        protected virtual void OnReclickRequest(EventArgs e)
        {
            EventHandler eh = ReclickRequest;
            if (eh != null)
                eh(this, e);
        }

        private void Btnchonanh_Click(object sender, EventArgs e)
        {
            imgboxxemtruoc.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
                {
                    lblpath.Text = dialog.FileName;
                    imgboxxemtruoc.ImageLocation = lblpath.Text.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }



        private void Dgvban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvban.Rows[e.RowIndex];
                txtmaban.Text = row.Cells["soban"].Value.ToString();
                txttenban.Text = row.Cells["tenban"].Value.ToString();
                cbbkhuvuc.Text = row.Cells["makhuvuc"].Value.ToString();
            }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            txtmaban.Text = "";
            txttenban.Text = "";
            cbbkhuvuc.Text = "";
        }

        private void Btnthem_Click(object sender, EventArgs e)
        {
            // code sau
        }


        private void Txttimkiemnhanvien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btntimnhanvien.PerformClick();
            }
        }

        private void Btntimnhanvien_Click(object sender, EventArgs e)
        {
            String inputTim = txttimkiemnhanvien.Text;
            loadNhanVien(inputTim);
        }

        private void Dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvnhanvien.Rows[e.RowIndex];
                cbbmacv.Text = row.Cells["macv"].Value.ToString();
                cbbmabp.Text = row.Cells["mabp"].Value.ToString();
                txttennv.Text = row.Cells["tennv"].Value.ToString();
                txtemail.Text = row.Cells["emailnv"].Value.ToString();
                txtdiachi.Text = row.Cells["diachinv"].Value.ToString();
                txtsotk.Text = row.Cells["sotaikhoannv"].Value.ToString();
                txttendangnhap.Text = row.Cells["tendangnhap"].Value.ToString();
                txtmatkhau.Text = row.Cells["matkhau"].Value.ToString();
                txtsodt.Text = row.Cells["dienthoainv"].Value.ToString();
            }
        }

        private void IconButton1_Click(object sender, EventArgs e)  /// button xoa nhan vien
        {
            saveHistory("xoa");
        }

        private void Btnsuanhanvien_Click(object sender, EventArgs e)
        {
            saveHistory("sua");
        }

        private void Btncleartextnhanvien_Click(object sender, EventArgs e)
        {
            cbbmacv.Text = "";
            cbbmabp.Text = "";
            txttennv.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";
            txtsotk.Text = "";
            txttendangnhap.Text = "";
            txtmatkhau.Text = "";
            txtsodt.Text = "";
        }

        private void Txttimmonan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btntimmonan.PerformClick();
            }
        }

        private void Btntimmonan_Click(object sender, EventArgs e)
        {
            String tieuchi = cbbtimtheomonan.Text;
            String inputTim = txttimmonan.Text;
            if (String.IsNullOrWhiteSpace(tieuchi))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm");
            }
            else
            {
                if (tieuchi.Contains("Tất cả"))
                {
                    loadMonan("");
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(inputTim))
                    {
                        loadMonan(inputTim);
                    }
                }
            }
        }

        private void Dgvmonan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                imgboxxemtruoc.Image = null;
                DataGridViewRow row = dgvmonan.Rows[e.RowIndex];
                txtmamon.Text = row.Cells["mamon"].Value.ToString();
                txttenmon.Text = row.Cells["tenmon"].Value.ToString();
                txtgiaban.Text = row.Cells["giaban"].Value.ToString();
                rtbmota.Text = row.Cells["mota"].Value.ToString();
                cbbdvt.Text = row.Cells["dvt"].Value.ToString();
                if (!String.IsNullOrWhiteSpace(row.Cells["hinh"].Value.ToString()))
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(row.Cells["hinh"].Value);
                    MemoryStream mem = new MemoryStream(data);
                    imgboxxemtruoc.Image = Image.FromStream(mem);   
                }
            }
        }
        // Chỉ cho giá bán nhập số
        private void txtGiaban_KeyPress(object sender, KeyPressEventArgs e)
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
        private void Btnsuamon_Click(object sender, EventArgs e)
        {
            byte[] images = { 0x20 };
            String request = "updatenonimage";
            if (!String.IsNullOrWhiteSpace(lblpath.Text))
            {
                FileStream stream = new FileStream(lblpath.Text, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(stream);
                images = binaryReader.ReadBytes((int)stream.Length);
                request = "update";
            }
                String mamon = txtmamon.Text;
                String tenmon = txttenmon.Text;
                String giaban = txtgiaban.Text;
                String mota = rtbmota.Text;
                String dvt = cbbdvt.Text;
                if (String.IsNullOrWhiteSpace(mamon)
                    | String.IsNullOrWhiteSpace(tenmon)
                    | String.IsNullOrWhiteSpace(dvt)
                    | String.IsNullOrWhiteSpace(giaban))
                {
                    MessageBox.Show("Vui không bỏ trống những trường có (*) ");
                }
                else
                {
                    int IntGiaban = Convert.ToInt32(giaban);
                    String query = "themmonan @MAMON @tenmon @giaban @mota @dvt @hinh @request";
                    int result = ConnectDataBase.SessionConnect.executeNonQuery(query, new object[] {
                        mamon, tenmon, IntGiaban, mota, dvt, images, request
                    });
                    Console.WriteLine(result);
                    if (result>=1)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    loadMonan("");
                }
            
        }
        private void BangDieuKhien_SizeChanged(object sender, EventArgs e)
        {
            if (this.Size.Height < 550)
            {
                dgvmonan.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;//hình
                dgvmonan.Columns[5].Width = 60;
                dgvmonan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;//dvt
                dgvmonan.Columns[4].Width = 45;
                dgvmonan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;//mã
                dgvmonan.Columns[0].Width = 45;
                dgvmonan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;//tên
                dgvmonan.Columns[1].Width = 200;
                dgvmonan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;//giá
                dgvmonan.Columns[2].Width = 80;
                //
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i != 3)
                    {
                        dgvmonan.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;//mã

                    }
                    else
                    {
                        dgvmonan.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//mã
                    }
                }
                //
                for (int i = 0; i < 10; i++)
                {
                    if (i != 6)
                    {
                        dgvnhanvien.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;//mã

                    }
                    else
                    {
                        dgvnhanvien.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//mã
                    }
                }

            }
        }
        #endregion

        #region Methods
        private void loadBan()
        {
            dgvban.DataSource = objBan.loadTableBan();
        }
        private void loadMonan(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                String query = "select * from monan";
                DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
                dgvmonan.DataSource = table;
            }
            else
            {
                String query = "";
                if (cbbtimtheomonan.Text.Contains("Tên"))
                {
                    query = "select * from monan where tenmon like N'%" +
                    input.Trim() + "%'";
                }
                else if (cbbtimtheomonan.Text.Contains("Mã"))
                {
                    query = "select * from monan where mamon like '%" +
                    input.Trim() + "%'";
                }
                DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
                dgvmonan.DataSource = table;
            }
            for (int i = 0; i < dgvmonan.Columns.Count; i++)
                if (dgvmonan.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvmonan.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }
        }
        private void loadMabophan()
        {
            cbbmabp.Items.Clear();
            listBophan = new BoPhan().loadListBoPhan();
            foreach (BoPhan item in listBophan)
            {
                cbbmabp.Items.Add(item.Mabp);
            }
        }

        private void loadMachucvu()
        {
            cbbmacv.Items.Clear();
            listChucvu = new ChucVu().loadListChucVu();
            foreach (ChucVu item in listChucvu)
            {
                cbbmacv.Items.Add(item.Macv);
            }
        }
        private void saveHistory(String yeucau)
        {
            String mabp = cbbmabp.Text;
            String macv = cbbmacv.Text;
            String ten = txttennv.Text;
            String sdt = txtsodt.Text;
            String email = txtemail.Text;
            String diachi = txtdiachi.Text;
            String sotk = txtsotk.Text;
            String tendangnhap = txttendangnhap.Text;
            String matkhau = txtmatkhau.Text;
            String ngaythem = DateTime.Now.ToLongDateString();
            String[] mangNhanvien = { macv.Trim(),
                mabp.Trim(),
                ten.Trim(), sdt.Trim(),
                email.Trim(),
                diachi.Trim(),
                sotk.Trim(),
                tendangnhap.Trim(),
                matkhau.Trim(),
                ngaythem.Trim() };
            String content = "";
            if (yeucau.Contains("them"))
            {
                content = String.Format(ClassCSharp.User.Manv + " đã thêm:" +
                    "{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}{8}-{9}"
                    , mangNhanvien);
            }
            else if (yeucau.Contains("sua"))
            {
                DataGridViewRow row = dgvnhanvien.Rows[dgvnhanvien.CurrentCell.RowIndex];
                String[] dataSua = {
                row.Cells["macv"].Value.ToString(),macv,
                row.Cells["mabp"].Value.ToString(),mabp,
                row.Cells["tennv"].Value.ToString(),ten,
                row.Cells["emailnv"].Value.ToString(),email,
                row.Cells["diachinv"].Value.ToString(),diachi,
                row.Cells["sotaikhoannv"].Value.ToString(),sotk,
                row.Cells["tendangnhap"].Value.ToString(),tendangnhap,
                row.Cells["matkhau"].Value.ToString(),matkhau,
                row.Cells["dienthoainv"].Value.ToString(),sdt,
                ngaythem
                };
                content = String.Format(ClassCSharp.User.Manv + " đã sửa: " +
                    "\n\t{0} -> {1}" +
                    "\n\t{2} -> {3}" +
                    "\n\t{4} -> {5}" +
                    "\n\t{6} -> {7}" +
                    "\n\t{8} -> {9}" +
                    "\n\t{10} -> {11}" +
                    "\n\t{12} -> {13}" +
                    "\n\t{14} -> {15}" +
                    "\n\t{16} -> {17}-{18}"
                    , dataSua);
            }
            else if (yeucau.Contains("xoa"))
            {
                content = String.Format(ClassCSharp.User.Manv + " đã xóa: " +
                    "{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}{8}-{9}"
                    , mangNhanvien);
            }
            //System.IO.File.WriteLine(@"C:\Users\Public\TestFolder\WriteText.txt", text);
            using (StreamWriter sw = new StreamWriter(File.Open(@".\Staff_history.txt", FileMode.Append), Encoding.Unicode))
            {
                sw.WriteLine(content);
            }
        }
        private void ThuNhoFormCha()
        {
            OnReclickRequest(EventArgs.Empty);
        }
        private void loadKhuvuc()
        {
            cbbkhuvuc.Items.Clear();
            listKhuvuc = new KhuVuc().loadListKhuVuc();
            foreach (KhuVuc item in listKhuvuc)
            {
                cbbkhuvuc.Items.Add(item.Makhuvuc);
            }
        }
       
        private void loadNhanVien(String input)
        {
            dgvnhanvien.DataSource=objNhanVien.loadTableNhanVien(input,cbbtimtheonhanvien.Text);
        }
        
        #endregion
    }
}
