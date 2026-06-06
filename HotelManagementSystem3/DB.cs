using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem3
{
    public class DB
    {
        public static string conn = @"Data Source=VIMUTHLAP;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
        {
            return new SqlConnection(conn);
        }
    }
}
