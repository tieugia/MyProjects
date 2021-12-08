using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

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
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Province>("SELECT * FROM Province");

            }    
        }
    }
}
