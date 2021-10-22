using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class PatternRepository : Repository
    {
        public PatternRepository(IConfiguration configuration) : base(configuration) { }
        //public List
        public Pattern GetPatternById(byte id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Pattern WHERE PatternId = @id";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pattern
                            {
                                Id = (byte)reader["PatternId"],
                                Show = reader["PatternShow"] != DBNull.Value ? (string)reader["PatternShow"] : null,
                                Add = reader["PatternAdd"] != DBNull.Value ? (string)reader["PatternAdd"] : null
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public Pattern GetPatternByProvince(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetPatternByProvince";
                    command.CommandType = CommandType.StoredProcedure;
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pattern
                            {
                                Id = (byte)reader["PatternId"],
                                Show = (string)reader["PatternShow"],
                                Add = reader["PatternAdd"] != DBNull.Value ? (string)reader["PatternAdd"] : null
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public int Edit(Pattern obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "EditPattern";
                    command.CommandType = CommandType.StoredProcedure;

                    IDataParameter idparameter = command.CreateParameter();
                    idparameter.ParameterName = "@id";
                    idparameter.Value = obj.Id;
                    command.Parameters.Add(idparameter);

                    IDataParameter showParameter = command.CreateParameter();
                    showParameter.ParameterName = "@show";
                    showParameter.Value = obj.Show;
                    command.Parameters.Add(showParameter);

                    IDataParameter addParameter = command.CreateParameter();
                    addParameter.ParameterName = "@add";
                    addParameter.Value = obj.Add;
                    command.Parameters.Add(addParameter);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public string GetShow(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetShowByProvince";
                    command.CommandType = CommandType.StoredProcedure;
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    return (string)command.ExecuteScalar();
                    //using (IDataReader reader = command.ExecuteReader())
                    //{
                    //    if (reader.Read())
                    //    {
                    //        return new Pattern
                    //        {
                    //            Id = (byte)reader["PatternId"],
                    //            Show = (string)reader["PatternShow"]
                    //        };
                    //    }
                    //    return null;
                    //}
                }
            }
        }
        public List<Pattern> GetPatterns()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetPatterns";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Pattern> patterns = new List<Pattern>();
                        while (reader.Read())
                        {
                            patterns.Add(new Pattern
                            {
                                Id = (byte)reader["PatternId"],
                                Show = reader["PatternShow"] == DBNull.Value ? null : (string)reader["PatternShow"],
                                Add = reader["PatternAdd"] == DBNull.Value ? null : (string)reader["PatternAdd"]
                            });
                        }
                        return patterns;
                    }
                }
            }
        }
        public int Add(Pattern obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AddPattern";
                    command.CommandType = CommandType.StoredProcedure;

                    IDataParameter showParameter = command.CreateParameter();
                    showParameter.ParameterName = "@Show";
                    showParameter.Value = obj.Show;
                    command.Parameters.Add(showParameter);

                    IDataParameter addParameter = command.CreateParameter();
                    addParameter.ParameterName = "@Add";
                    addParameter.Value = obj.Add;
                    command.Parameters.Add(addParameter);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Delete(byte id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Pattern WHERE PatternId = @id";
                    IDataParameter idParameter = command.CreateParameter();
                    idParameter.Value = id;
                    idParameter.ParameterName = "@id";
                    command.Parameters.Add(idParameter);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public string GetAdd(short id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetAddByProvince";
                    command.CommandType = CommandType.StoredProcedure;
                    IDataParameter parameter = command.CreateParameter();
                    parameter.Value = id;
                    parameter.ParameterName = "@id";
                    command.Parameters.Add(parameter);
                    connection.Open();
                    return (string)command.ExecuteScalar();
                }
            }
        }
        public string GetAddById(byte id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT PatternAdd FROM Pattern WHERE PatternId = @id";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.Value = id;
                    parameter.ParameterName = "@id";
                    command.Parameters.Add(parameter);
                    connection.Open();
                    return (string)command.ExecuteScalar();
                }
            }
        }
    }
}
