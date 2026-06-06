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
<<<<<<< HEAD

    public static SqlConnection GetConnection()
=======
        private string connectionString = @"Server=DESKTOP-PUK4FIM;Database=MyProjectDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
>>>>>>> b94301e (Add project files.)
        {
            return new SqlConnection(conn);
        }
    }
}
