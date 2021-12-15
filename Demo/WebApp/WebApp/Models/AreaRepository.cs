using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AreaRepository : Repository
    {
        //Goi constructor lop cha
        public AreaRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Area> GetAreas()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "GetAreas";
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            List<Area> list = new List<Area>();
            while (reader.Read())
            {
                list.Add(new Area
                {
                    Id = (short)reader["AreaId"],
                    Name = (string)reader["AreaName"]
                });
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }
    }
}
