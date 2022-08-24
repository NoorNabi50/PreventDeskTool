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

            if(connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;

        }

    }
}
