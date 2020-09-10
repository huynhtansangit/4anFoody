using System;
using System.Collections.Generic;
using System.Data;
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
        private String stringAvailable = "Data Source=DESKTOP-S418B85\\SQLEXPRESS;Initial Catalog=QLNH30-08;Integrated Security=True";
        private static ConnectDataBase sessionConnect;
        public static ConnectDataBase SessionConnect
        {
            get { if (sessionConnect == null) sessionConnect = new ConnectDataBase(); return ConnectDataBase.sessionConnect; }
            private set
            {
                ConnectDataBase.sessionConnect = value;
            }
        }

        #region privateMethods
        private ConnectDataBase() { }
        #endregion
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

        public DataTable executeQuery (String query, Object [] paramaters=null)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.stringAvailable))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                
                if(paramaters!=null)
                {
                 
                    String[] listParams = query.Split(' ');
                    cmd = new SqlCommand(listParams[0], conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = 0;
                    foreach (String item in listParams)
                    {
                        if(item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramaters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                conn.Close();
            }
            return table;
        }
        public DataTable executeQueryNoProc(String query, Object[] paramaters = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.stringAvailable))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (paramaters != null)
                {

                    String[] listParams = query.Split(' ');
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    int i = 0;
                    foreach (String item in listParams)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramaters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                conn.Close();
            }
            return table;
        }
        // trả về số bảng ghi truy vấn thành công
        public int executeNonQuery(String query, Object[] paramaters = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(stringAvailable))
            {
                conn.Open();
                SqlCommand cmd= cmd = new SqlCommand(query, conn);
                if (paramaters != null)
                {
                    String[] listParams = query.Split(' ');
                    cmd = new SqlCommand(listParams[0], conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = 0;
                    foreach (String item in listParams)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramaters[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }
        // trả về giá trị đầu tiên của bảng.
        public object executeScalar(String query, Object[] paramaters = null) //select count (*)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(stringAvailable))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int i = 0;
                if (paramaters != null)
                {
                    String[] listParams = query.Split(' ');
                    cmd = new SqlCommand(listParams[0], conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (String item in listParams)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, paramaters[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                conn.Close();
            }
            return data;
        }
        public DataTable executeReaderDependency (SqlCommand cmd,String query =null)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.stringAvailable))
            {
                conn.Open();
                cmd.Connection = conn;
                if(!String.IsNullOrWhiteSpace(query))
                {
                    cmd.CommandText = query;
                }
                table.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                conn.Close();
            }
            return table;
        }
        public SqlConnection getConnection()
        {
            return this.connection=new SqlConnection(stringAvailable);
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
            return this.stringAvailable;
        }
        public void setStringConnection(String temp)
        {
            this.stringConnect = temp;
        }
    }
}
