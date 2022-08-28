using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PreventDeskTool
{
    public static class SQLConnect
    {

        private static SqlConnection connection;

   
        public static SqlConnection ConnectDatabase()
        {
              connection = new SqlConnection("Server=localhost;Database=PreventDeskToolDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
          //  connection = new SqlConnection("Server=SQL8004.site4now.net;Database=db_a8c024_noornabibaloch;User Id = db_a8c024_noornabibaloch_admin; Password = hassan12345678");

            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;

        }

    }
}
