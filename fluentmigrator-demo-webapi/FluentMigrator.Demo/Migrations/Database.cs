using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace FluentMigrator.Demo.Migrations
{
    public static class Database
    {
        public static void Migrate(string connectionString, string name)
        {
            using var connection = new SqlConnection(connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            if(!connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters).Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}
