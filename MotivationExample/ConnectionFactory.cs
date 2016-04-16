using System.Data.SqlClient;
using System.Configuration;

namespace MotivationExample
{

	public static class ConnectionFactory
    {
        public static SqlConnection GetConnection(string connectionName)
        {
            var connectionString = ConfigurationManager.AppSettings[connectionName];
            var connection = new SqlConnection(connectionString);
			connection.Open ();
			return connection;
        }
    }
}
