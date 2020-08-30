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

        public string Mamon { get => mamon; set => mamon = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public int Giaban { get => giaban; set => giaban = value; }
        public string Mota { get => mota; set => mota = value; }
        public byte[] Hinh { get => hinh; set => hinh = value; }
        public string Dvt { get => dvt; set => dvt = value; }

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
        #endregion
    }
}
