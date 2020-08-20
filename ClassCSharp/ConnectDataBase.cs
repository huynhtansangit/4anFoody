using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class ConnectDataBase
    {
        private SqlConnection connection;
        private String stringConnect;
        private String stringAvailable = "Data Source=DESKTOP-S418B85\\SQLEXPRESS;Initial Catalog=QuanLiNhaHang;Integrated Security=True";
        // method
        public ConnectDataBase( string stringConnect)
        {
            // Truyền vào chuỗi rỗng thì lấy chuỗi string có sẵn để kết nối
            if (String.IsNullOrWhiteSpace(stringConnect))
            {
                this.connection = new SqlConnection(this.stringAvailable);
                this.stringConnect = this.stringAvailable;
            }
            // Không thì lấy chuỗi string truyền vào để kết nối.
            else
            {
                this.connection = new SqlConnection(stringConnect);
                this.stringConnect = stringConnect;
            }
        }
        public SqlConnection getConnection()
        {
            return this.connection;
        }
        public void closeDB()
        {
            this.connection.Close();
        }
        public void openDB()
        {
            this.connection.Open();
        }
        public void setConnection (SqlConnection temp)
        {
            this.connection = temp;
        }
        public String getStringConnection()
        {
            return this.stringConnect;
        }
        public void setStringConnection(String temp)
        {
            this.stringConnect = temp;
        }
    }
}
