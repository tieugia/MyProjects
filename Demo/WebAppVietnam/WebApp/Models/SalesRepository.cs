using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class SalesRepository : BaseRepository
    {
        public SalesRepository(IDbConnection connection) : base(connection) { }
        public IEnumerable<SalesRestaurant> GetSalesRestaurants(out double slope, out double intercept)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Slope", dbType: DbType.Double, direction: ParameterDirection.Output);
            dynamicParameters.Add("@Intercept", dbType: DbType.Double, direction: ParameterDirection.Output);
            IEnumerable<SalesRestaurant> list = connection.Query<SalesRestaurant>("GetSalesRestaurants", dynamicParameters, commandType: CommandType.StoredProcedure);
            slope = dynamicParameters.Get<Double>("@Slope");
            intercept = dynamicParameters.Get<Double>("@Intercept");  
            return list;
            //return connection.Query<SalesRestaurant>("GetSalesRestaurants", commandType: CommandType.StoredProcedure);
        }
    }
}
