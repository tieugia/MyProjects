using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProvinceRepository : Repository
    {
        public ProvinceRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public int Add(Province obj)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "AddProvince";
            command.CommandType = CommandType.StoredProcedure;
            IDataParameter nameParameter = command.CreateParameter();
            nameParameter.Value = obj.Name;
            nameParameter.ParameterName = "@name";
            command.Parameters.Add(nameParameter);

            IDataParameter patternParameter = command.CreateParameter();
            patternParameter.Value = obj.PatternId;
            patternParameter.ParameterName = "@patternId";
            command.Parameters.Add(patternParameter);

            IDataParameter areaIdParameter = command.CreateParameter();
            areaIdParameter.Value = obj.AreaId;
            areaIdParameter.ParameterName = "@areaId";
            command.Parameters.Add(areaIdParameter);

            connection.Open();
            int ret = command.ExecuteNonQuery();
            command.Dispose();
            connection.Dispose();
            return ret;
        }
        public int Edit(Province obj)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "EditProvince";
            command.CommandType = CommandType.StoredProcedure;
            IDataParameter idParameter = command.CreateParameter();
            idParameter.Value = obj.Id;
            idParameter.ParameterName = "@id";
            command.Parameters.Add(idParameter);

            IDataParameter nameParameter = command.CreateParameter();
            nameParameter.Value = obj.Name;
            nameParameter.ParameterName = "@name";
            command.Parameters.Add(nameParameter);

            IDataParameter areaIdParameter = command.CreateParameter();
            areaIdParameter.Value = obj.AreaId;
            areaIdParameter.ParameterName = "@areaId";
            command.Parameters.Add(areaIdParameter);

            connection.Open();
            int ret = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return ret;
        }
        public Province GetProvince(short id)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "GetProvince";
            command.CommandType = CommandType.StoredProcedure;
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@id";
            parameter.Value = id;
            command.Parameters.Add(parameter);
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            Province obj = null;
            if (reader.Read())
            {
                obj = new Province
                {
                    Id = (short)reader["ProvinceId"],
                    AreaId = (short)reader["AreaId"],
                    Name = (string)reader["ProvinceName"],
                    PatternId=(byte)reader["PatternId"]
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return obj;
        }
        public List<Province> GetProvinces()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "GetProvinces";
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            List<Province> list = new List<Province>();
            while (reader.Read())
            {
                list.Add(new Province
                {
                    Id = (short)reader["ProvinceId"],
                    AreaId = (short)reader["AreaId"],
                    AreaName = (string)reader["AreaName"],
                    Name = (string)reader["ProvinceName"],
                    PatternId = (byte)reader["PatternId"]
                });
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }
    }
}
