using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class NhanVien
    {
        private String manv;
        private String macv;
        private String mabp;
        private String tennv;
        private String dienthoai;
        private String email;
        private String diachi;
        private String sotk;
        private String tendangnhap;
        private String matkhau;
        private DateTime ngayvaolam;

        public NhanVien(string manv, string macv, string mabp, string tennv, string dienthoai, string email, string diachi, string sotk, string tendangnhap, string matkhau, DateTime ngayvaolam)
        {
            this.manv = manv;
            this.macv = macv;
            this.mabp = mabp;
            this.tennv = tennv;
            this.dienthoai = dienthoai;
            this.email = email;
            this.diachi = diachi;
            this.sotk = sotk;
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
            this.ngayvaolam = ngayvaolam;
        }

        //Method 
        public String Manv { get => manv; set => manv = value; }
        public String Mabp { get => mabp; set => mabp = value; }
        public String Macv { get => macv; set => macv = value; }
        public String Tennv { get => tennv; set => tennv = value; }
        public String Dienthoai { get => dienthoai; set => dienthoai = value; }
        public String Email { get => email; set => email = value; }
        public String Diachi { get => diachi; set => diachi = value; }
        public String Sotk { get => sotk; set => sotk = value; }
        public String Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
        public String Matkhau { get => matkhau; set => matkhau = value; }
        public DateTime Ngayvaolam { get => ngayvaolam; set => ngayvaolam = value; }
    }
}
