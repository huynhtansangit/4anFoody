using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva_vegan.ClassCSharp;

namespace Viva_vegan.FormDashboard.BaoCaoChild
{
    class BestSellerFood
    {

       private string ma;
       private String ten;
       private int soluong;

        public BestSellerFood(string ma, string ten, int soluong)
        {
            this.ma = ma;
            this.ten = ten;
            this.soluong = soluong;
        }
        public BestSellerFood(DataRow row)
        {
            this.ma = row[0].ToString();
            this.ten =row[1].ToString();
            this.soluong=Convert.ToInt32(row[2]);   
        }

        public BestSellerFood()
        {
        }

        public List<BestSellerFood> GetBestSellerFoods (String from,String to)
        {
            List<BestSellerFood> foods = new List<BestSellerFood>();
            String query = "loadbxhmonan @mocthoigian @tungay @denngay";
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query, new object[]
            {
                "none",from,to
            });
            if (table.Rows.Count>0)
            {
                foreach (DataRow row in table.Rows)
                {
                    foods.Add(new BestSellerFood(row));
                }
            }
            return foods;
        }
        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
