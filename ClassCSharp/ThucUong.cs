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


        public int Giaban { get => giaban; set => giaban = value; }
        public string Mota { get => mota; set => mota = value; }
        public byte[] Hinh { get => hinh; set => hinh = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public string Mathucuong { get => mathucuong; set => mathucuong = value; }
        public string Tenthucuong { get => tenthucuong; set => tenthucuong = value; }

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
        #endregion
    }
}
