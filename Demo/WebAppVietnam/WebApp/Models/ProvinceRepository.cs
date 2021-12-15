using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class ProvinceRepository
    {
        string connectionString;
        public ProvinceRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Vietnam");
        }
        public IEnumerable<Province> GetProvinces()
        {
            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                return connection.Query<Province>("Select * FROM Province");
            }
        }
    }
}
