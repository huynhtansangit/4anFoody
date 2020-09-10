using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class ThucUong
    {
        private String mathucuong;
        private String tenthucuong;
        private int giaban;
        private String mota;
        private String dvt;
        private byte[] hinh;
        private int sl;

        public ThucUong(String mathucuong)
        {
            String query = "select * from thucuong where mathucuong='" + mathucuong +
                "'";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5] == DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    this.mathucuong = row["MATHUCUONG"].ToString();
                    this.tenthucuong = row["TENTHUCUONG"].ToString();
                    this.giaban = Convert.ToInt32(row["GIABAN"]);
                    this.mota = row["MOTA"].ToString();
                    this.dvt = row["DVT"].ToString();
                    this.hinh = image;

                }
                else
                {
                    this.mathucuong = row["MATHUCUONG"].ToString();
                    this.tenthucuong = row["TENTHUCUONG"].ToString();
                    this.giaban = Convert.ToInt32(row["GIABAN"]);
                    this.mota = row["MOTA"].ToString();
                    this.dvt = row["DVT"].ToString();
                    this.hinh = (byte[])(row[5]);
                }
            }

        }
        public ThucUong(DataRow row, Boolean isBestSeller)
        {
            this.Mathucuong = row[0].ToString();
            this.Tenthucuong = row[1].ToString();
            this.Sl = Convert.ToInt32(row[2]);
        }
        public ThucUong()
        { }
        public ThucUong(string mathucuong, string tenthucuong, int giaban, string mota, string dvt, byte[] hinh)
        {
            this.mathucuong = mathucuong;
            this.tenthucuong = tenthucuong;
            this.giaban = giaban;
            this.mota = mota;
            this.dvt = dvt;
            this.hinh = hinh;
        }
        public ThucUong(DataRow row)
        {
            if (row[5] == DBNull.Value)
            {
                ImageConverter converter = new ImageConverter();
                Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                this.Mathucuong = row[0].ToString();
                this.Tenthucuong = row[1].ToString();
                this.Giaban = Convert.ToInt32(row["GIABAN"]);
                this.Mota = row["MOTA"].ToString();
                this.Dvt = row["DVT"].ToString();
                this.Hinh = image;
            }
            else
            {
                this.Mathucuong = row[0].ToString();
                this.Tenthucuong = row[1].ToString();
                this.Giaban = Convert.ToInt32(row["GIABAN"]);
                this.Mota = row["MOTA"].ToString();
                this.Dvt = row["DVT"].ToString();
                this.Hinh = (byte[])(row[5])
;
            }
        }

        public int Giaban { get => giaban; set => giaban = value; }
        public string Mota { get => mota; set => mota = value; }
        public byte[] Hinh { get => hinh; set => hinh = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public string Mathucuong { get => mathucuong; set => mathucuong = value; }
        public string Tenthucuong { get => tenthucuong; set => tenthucuong = value; }
        public int Sl { get => sl; set => sl = value; }

        #region Methods
        public List<ThucUong> GetThucUongs()
        {
            List<ThucUong> list = new List<ThucUong>();
            String query = "select * from thucuong";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5] == DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    list.Add(new ThucUong(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[4]),
                    row[2].ToString(),
                    row[3].ToString(),
                    image
                    ));
                }
                else
                {
                    list.Add(new ThucUong(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[4]),
                    row[2].ToString(),
                    row[3].ToString(),
                    (byte[])(row[5])
                    ));
                }
            }
            return list;
        }
        public List<ThucUong> GetThucUongs(String order)
        {
            List<ThucUong> list = new List<ThucUong>();
            String query = "select * from ThucUong";
            if (order.Contains("giam"))
            {
                query = "select * from ThucUong order by giaban asc";
            }
            else query = "select * from ThucUong order by giaban desc";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5] == DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    list.Add(new ThucUong(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[4]),
                    row[2].ToString(),
                    row[3].ToString(),
                    image
                    ));
                }
                else
                {
                    list.Add(new ThucUong(
                     row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[4]),
                    row[2].ToString(),
                    row[3].ToString(),
                    (byte[])(row[5])
                    ));
                }
            }
            return list;
        }
        public int xoaThucUong(String mathucuong)
        {
            String query = "delete from thucuong where mathucuong ='" + mathucuong +
                "'";
            int result = ConnectDataBase.SessionConnect.executeNonQuery(query);
            return result;
        }
        public List<ThucUong> getThucUongTheoTuKhoa(String tukhoa, String timtheo = null)
        {
            List<ThucUong> list = new List<ThucUong>();
            String query = "";
            if (timtheo.Contains("Mã"))
            {
                query = "select * from ThucUong where mathucuong like N'%" + tukhoa +
                    "%'";
                DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ThucUong(row));
                }
            }
            else if (timtheo.Contains("Tên"))
            {
                query = "select * from ThucUong where tenthucuong like N'%" + tukhoa +
                    "%'";
                DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ThucUong(row));
                }
            }
            return list;
        }
        #endregion
    }
}
