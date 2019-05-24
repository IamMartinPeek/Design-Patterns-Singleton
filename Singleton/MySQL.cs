using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Model
{
    public class MySQL
    {
        #region SINGLETON

        static MySQL _Instance;
        MySqlConnection _Connection;

        public MySqlConnection Connection => _Connection;

        
        public static MySQL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MySQL();
                }
                return _Instance;
            }
        }
        
        private MySQL()
        {
            string connectionString = "datasource=" + "127.0.0.1" + ";port=" + 3306 + ";username=" + "root" + ";password=" + "" + ";database=" + "test;" + "SslMode=none;";
            _Connection = new MySqlConnection(connectionString); 
        }

        #endregion

     

        public void Open()
        {
            try
            {
                _Connection.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public SQLResult SendQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, _Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            SQLResult result = new SQLResult(reader);
            reader.Close();
            return result;
        }

        public SQLResult SendPreparedQuery(MySqlCommand cmd)
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            SQLResult result = new SQLResult(reader);
            reader.Close();
            return result;
        }

        public void SendStatement(string statement)
        {
            MySqlCommand cmd = new MySqlCommand(statement, _Connection);
            cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            _Connection.Close();
        }
        
    }
}
