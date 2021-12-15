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
    public class WardRepository
    {
        string connectionString;
        public WardRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Vietnam");
        }
        public IEnumerable<Ward> GetWards(string id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Ward>("SELECT * FROM Ward WHERE DistrictId=@Id", new { Id = id });
            }    
        }
    }
}
