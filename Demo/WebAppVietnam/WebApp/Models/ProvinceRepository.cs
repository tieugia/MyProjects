using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class ProvinceRepository : BaseRepository
    {
        //string connectionString;
        //public ProvinceRepository(IConfiguration configuration)
        //{
        //    connectionString = configuration.GetConnectionString("Vietnam");
        //}
        public ProvinceRepository(IDbConnection connection) : base(connection) { }
        public IEnumerable<Province> GetProvinces()
        {
            //using (IDbConnection connection=new SqlConnection(connectionString))
            //{
                return connection.Query<Province>("Select * FROM Province");
            //}
        }
    }
}
