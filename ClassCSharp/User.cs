using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    static class User
    {
        private static String manv;
        private static String macv;
        private static String mabp;
        private static String tennv;
        private static String dienthoai;
        private static String email;
        private static String diachi;
        private static String sotk;
        private static String tendangnhap;
        private static String matkhau;
        private static DateTime ngayvaolam;
        private static Boolean isMaximized;

        //Method 
        #region getterAndsetter
        public static String Manv { get => manv; set => manv = value; }
        public static String Mabp { get => mabp; set => mabp = value; }
        public static String Macv { get => macv; set => macv = value; }
        public static String Tennv { get => tennv; set => tennv = value; }
        public static String Dienthoai { get => dienthoai; set => dienthoai = value; }
        public static String Email { get => email; set => email = value; }
        public static String Diachi { get => diachi; set => diachi = value; }
        public static String Sotk { get => sotk; set => sotk = value; }
        public static String Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
        public static String Matkhau { get => matkhau; set => matkhau = value; }
        public static DateTime Ngayvaolam { get => ngayvaolam; set => ngayvaolam = value; }
        public static bool IsMaximized { get => isMaximized; set => isMaximized = value; }
        #endregion

        public static Boolean kiemTraDangNhap (String tendangnhap, String matkhau)
        {
            String querylogin = "select * from nhanvien where tendangnhap='" +
                    tendangnhap.Trim() + "' and matkhau='" +
                    matkhau.Trim() + "'";
            DataTable dataTable = ConnectDataBase.SessionConnect.executeQuery(querylogin);
            if (dataTable.Rows.Count == 1)
            {
                ClassCSharp.User.Manv = dataTable.Rows[0].Field<String>(0);
                ClassCSharp.User.Macv = dataTable.Rows[0].Field<String>(1);
                ClassCSharp.User.Mabp = dataTable.Rows[0].Field<String>(2);
                ClassCSharp.User.Tennv = dataTable.Rows[0].Field<String>(3);
                ClassCSharp.User.Dienthoai = dataTable.Rows[0].Field<String>(4);
                ClassCSharp.User.Email = dataTable.Rows[0].Field<String>(5);
                ClassCSharp.User.Diachi = dataTable.Rows[0].Field<String>(6);
                ClassCSharp.User.Sotk = dataTable.Rows[0].Field<String>(7);
                ClassCSharp.User.Tendangnhap = dataTable.Rows[0].Field<String>(8);
                ClassCSharp.User.Matkhau = dataTable.Rows[0].Field<String>("matkhau");
                ClassCSharp.User.Ngayvaolam = Convert.ToDateTime(dataTable.Rows[0]["ngayvaolam"]);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
