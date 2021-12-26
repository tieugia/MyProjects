using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class DistrictRepository
    {
        //string connectionString;
        //public DistrictRepository(IConfiguration configuration)
        //{
        //    connectionString = configuration.GetConnectionString("Vietnam");
        //}
        IDbConnection connection;
        public DistrictRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public IEnumerable<District> GetDistricts(string id)
        {
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
                string sql = "SELECT * FROM District WHERE ProvinceId = @Id";
                return connection.Query<District>(sql, new { Id = id });
            //}
        }
        public IEnumerable<Statistic> StatisticDistricts()
        {
            return connection.Query<Statistic>("StatisticDistricts", commandType: CommandType.StoredProcedure);
        }
    }
}
