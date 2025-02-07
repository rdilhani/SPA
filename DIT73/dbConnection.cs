using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    internal class dbConnection
    {
        public SqlConnection getConnection() {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5KH52MH;Initial Catalog=DIT73;Integrated Security=True;Pooling=False");
            return con;
        }
    }
}
