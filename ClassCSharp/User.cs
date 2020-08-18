using System;
using System.Collections.Generic;
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

        //Method 
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

    }
}
