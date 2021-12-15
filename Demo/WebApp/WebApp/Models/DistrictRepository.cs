using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DistrictRepository 
    {
        string connectionString;
        public DistrictRepository (IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Vietnam");
        }
        public IEnumerable<District> GetDistricts(string id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM District WHERE ProvinceId=@Id";
                return connection.Query<District>(sql, new { Id = id });
            }    
        }
    }
}
