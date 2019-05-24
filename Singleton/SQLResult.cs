using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Model
{
    public class SQLResult
    {
        bool _HasRows;
        List<object[]> _Rows;

        public bool HasRows
        {
            get
            {
                return _HasRows;
            }
        }

        public List<object[]> Rows
        {
            get
            {
                return _Rows;
            }
        }

        public object[] FirstRow
        {
            get
            {
                return _Rows[0];
            }
        }

        public SQLResult(MySqlDataReader dataReader)
        {
            _HasRows = dataReader.HasRows;
            _Rows = new List<object[]>();
            int numberOfColumns = dataReader.FieldCount;
            object[] values;
            while (dataReader.Read())
            {
                values = new object[numberOfColumns];
                dataReader.GetValues(values);
                _Rows.Add(values);
            }
        }

      
    }
}
