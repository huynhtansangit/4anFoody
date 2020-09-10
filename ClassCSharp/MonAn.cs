using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class MonAn
    {
        private String mamon;
        private String tenmon;
        private int giaban;
        private String mota;
        private String dvt;
        private byte[] hinh;
        private long sl;
        
        public MonAn(String mamon)
        {
            String query = "select * from MonAn where mamon='" + mamon+
                "'";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5] == DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    this.mamon = row[0].ToString();
                    this.tenmon = row[1].ToString();
                    this.giaban = Convert.ToInt32(row[2]);
                    this.mota = row[3].ToString();
                    this.dvt = row[4].ToString();
                    this.hinh = image;
                    
                }
                else
                {
                    this.mamon = row[0].ToString();
                    this.tenmon = row[1].ToString();
                    this.giaban = Convert.ToInt32(row[2]);
                    this.mota = row[3].ToString();
                    this.dvt = row[4].ToString();
                    this.hinh = (byte[])(row[5]);
                }
            }
            
        }
        public MonAn()
        { }
            public MonAn(string mamon, string tenmon, int giaban, string mota, string dvt, byte[] hinh)
        {
            this.mamon = mamon;
            this.tenmon = tenmon;
            this.giaban = giaban;
            this.mota = mota;
            this.dvt = dvt;
            this.hinh = hinh;
        }
        public MonAn(string mamon, string tenmon, int giaban, string mota, string dvt, byte[] hinh,long soluong)
        {
            this.mamon = mamon;
            this.tenmon = tenmon;
            this.giaban = giaban;
            this.mota = mota;
            this.dvt = dvt;
            this.hinh = hinh;
            this.sl = soluong;
        }
        public MonAn(DataRow row)
        {
            MonAn mon = new MonAn();
            if (row[5] == DBNull.Value)
            {
                ImageConverter converter = new ImageConverter();
                Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                this.Mamon = row[0].ToString();
                this.Tenmon = row[1].ToString();
                this.giaban = Convert.ToInt32(row[2]);
                this.mota = row[3].ToString();
                this.Dvt=row[4].ToString();
                this.Hinh=image;
            }
            else
            {
                this.Mamon = row[0].ToString();
                this.Tenmon = row[1].ToString();
                this.giaban = Convert.ToInt32(row[2]);
                this.mota = row[3].ToString();
                this.Dvt = row[4].ToString();
                this.Hinh = (byte[])(row[5])
;
            }
        }
        public string Mamon { get => mamon; set => mamon = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public int Giaban { get => giaban; set => giaban = value; }
        public string Mota { get => mota; set => mota = value; }
        public byte[] Hinh { get => hinh; set => hinh = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public long Sl { get => sl; set => sl = value; }

        #region Methods
        public List<MonAn> GetMonAns ()
        {
            List<MonAn> list = new List<MonAn>();
            String query = "select * from MonAn";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5]==DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    list.Add(new MonAn(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    image
                    ));
                }
                else
                {
                    list.Add(new MonAn(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    (byte[])(row[5])
                    ));
                }
            }
            return list;
        }
        public List<MonAn> GetMonAns(String from, String to)
        {
            // lấy list món ăn có số lượng bán ra nằm trong khoảng thời gian
            List<MonAn> list = new List<MonAn>();
            String query = "select * from MONAN,(select ct.MAMON,sum (SOLUONG) as SLBANRA" +
                " from CTHD_MA as ct,MONAN as ma where ma.MAMON=ct.MAMON AND CT.MAHD " +
                "IN(SELECT MAHD FROM HOADON WHERE CONVERT (DATE,NGAYLAP) BETWEEN '" +from+
                "' AND '" +to+
                "') group by ct.MAMON union select a.MAMON, 0 as SLBANRA from MONAN as a where a.MAMON not in (select distinct mamon from CTHD_MA)) AS THONGKE where MONAN.MAMON = THONGKE.MAMON order by SLBANRA desc";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5] == DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    list.Add(new MonAn(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    image,
                    Convert.ToInt32(row[7])
                    ));
                }
                else
                {
                    list.Add(new MonAn(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    (byte[])(row[5])
                    , Convert.ToInt32(row[7])
                    ));
                }
            }
            return list;
        }
        // lấy list  món ăn . order là sắp xếp.
        public List<MonAn> GetMonAns (String order)
        {
            List<MonAn> list = new List<MonAn>();
            String query = "select * from MonAn";
            if (order.Contains ("giam"))
            {
                query = "select * from MonAn order by giaban asc";
            }
            else query = "select * from MonAn order by giaban desc";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                if (row[5] == DBNull.Value)
                {
                    ImageConverter converter = new ImageConverter();
                    Byte[] image = (byte[])converter.ConvertTo(Viva_vegan.Properties.Resources.an1, typeof(byte[]));
                    list.Add(new MonAn(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    image
                    ));
                }
                else
                {
                    list.Add(new MonAn(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToInt32(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    (byte[])(row[5])
                    ));
                }
            }
            return list;
        }
        public int xoaMonAn (String mamon)
        {
            String query = "delete from monan where mamon ='" + mamon+
                "'";
            int result = ConnectDataBase.SessionConnect.executeNonQuery(query);
            return result;
        }
        public List<MonAn> getMonAnTheoTuKhoa (String tukhoa, String timtheo=null)
        {
            List<MonAn> list = new List<MonAn>();
            String query = "";
            if (timtheo.Contains("Mã"))
            {
                query = "select * from MonAn where mamon like N'%" +tukhoa+
                    "%'";
                DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
                foreach(DataRow row in table.Rows)
                {
                    list.Add(new MonAn(row));
                }
            }
            else if(timtheo.Contains("Tên"))
            {
                query = "select * from MonAn where tenmon like N'%" + tukhoa +
                    "%'";
                DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new MonAn(row));
                }
            }
            return list;
        }
        #endregion
    }
}
