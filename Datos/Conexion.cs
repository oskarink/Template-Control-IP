using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        public SqlConnection theConnection;
        public SqlConnection theConnection2;

        public Conexion()
        {
            theConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Control_de_IPs.Properties.Settings.DB_IPCONTROLConnectionString"].ConnectionString);

            theConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["Control_de_IPs.Properties.Settings.DB_IPCONTROLConnectionString2"].ConnectionString);


        }
    }
}
