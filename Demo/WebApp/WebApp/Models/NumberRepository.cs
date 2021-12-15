using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NumberRepository : Repository
    {
        //public NumberRepository(IConfiguration configuration) : base(configuration) { }
        public NumberRepository(IDbConnection connection) : base(connection) { }
        /*static void Set(IDbCommand command, Parameter parameter)
        {
            IDataParameter dataParameter = command.CreateParameter();
            dataParameter.Value = parameter.Value;
            dataParameter.ParameterName = parameter.Name;
            command.Parameters.Add(dataParameter);
        }
        static void Set(IDbCommand command, Parameter[] parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                Set(command, parameter);
            }
        }*/
        public int Edit(Number obj)
        {
            Parameter[] parameters =
            {
                new Parameter{ Name = "@id", Value= obj.Id },
                new Parameter{ Name = "@value", Value= obj.Value },
            };
            return Save("UPDATE Number SET NumberValue = @value WHERE NumberId = @id", parameters);
        }
        public int Add(List<Number> list)
        {
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AddNumber";
                    command.CommandType = CommandType.StoredProcedure;

                    //Set(command, new Parameter { Name = "@ProvinceId", Value = obj.ProvinceId });
                    //Set(command, new Parameter { Name = "@PrizeId", Value = obj.PrizeId });
                    //Set(command, new Parameter { Name = "@Date", Value = obj.Date });
                    //Set(command, new Parameter { Name = "@Value", Value = obj.Value });

                    //Parameter[] parameters =
                    //{
                    //    new Parameter { Name = "@ProvinceId", Value = obj.ProvinceId },
                    //    new Parameter { Name = "@PrizeId", Value = obj.PrizeId },
                    //    new Parameter { Name = "@Date", Value = obj.Date },
                    //    new Parameter { Name = "@Value", Value = obj.Value }
                    //};
                    //Set(command, parameters);
                    //connection.Open();
                    //return command.ExecuteNonQuery();

                    IDataParameter resultParameter = command.CreateParameter();
                    resultParameter.ParameterName = "@ResultId";
                    command.Parameters.Add(resultParameter);

                    IDataParameter prizeParameter = command.CreateParameter();
                    prizeParameter.ParameterName = "@PrizeId";
                    command.Parameters.Add(prizeParameter);

                    IDataParameter valueParameter = command.CreateParameter();
                    valueParameter.ParameterName = "@Value";
                    command.Parameters.Add(valueParameter);

                    //connection.Open();
                    int ret = 0;
                    foreach (Number item in list)
                    {
                        valueParameter.Value = item.Value;
                        prizeParameter.Value = item.PrizeId;
                        resultParameter.Value = item.ResultId;
                        ret += command.ExecuteNonQuery();
                    }
                    return ret;
                }
            }
        //}
        public int Edit(List<Number> list)
        {
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "EditNumber";
                    command.CommandType = CommandType.StoredProcedure;

                    IDataParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@id";
                    command.Parameters.Add(idParameter);

                    IDataParameter valueParameter = command.CreateParameter();
                    valueParameter.ParameterName = "@Value";
                    command.Parameters.Add(valueParameter);

                    //connection.Open();
                    int ret = 0;
                    foreach (Number item in list)
                    {
                        idParameter.Value = item.Id;
                        valueParameter.Value = item.Value;
                        ret += command.ExecuteNonQuery();
                    }
                    return ret;
                }
            }
        //}
        public List<Number> GetNumbers(int id)
        {
            ////using (IDbConnection connection = new SqlConnection(connectionString))
            //{
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNumbersByResult";
                    command.CommandType = CommandType.StoredProcedure;
                    //connection.Open();
                    Set(command, new Parameter { Name = "@id", Value = id });
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Number> list = new List<Number>();
                        while (reader.Read())
                        {
                            list.Add(new Number
                            {
                                Id = (long)reader["NumberId"],
                                PrizeId = (byte)reader["PrizeId"],
                                ResultId = (int)reader["ResultId"],
                                Value = (string)reader["NumberValue"]
                                //Date = (DateTime)reader["NumberDate"]
                            });
                        }
                        //reader.Close();
                        //command.Dispose();
                        //connection.Close();
                        return list;
                    }
                }
            }
        //}
        public List<string> GetNumbersByResult(int id)
        {
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT NumberValue FROM Number WHERE ResultId = @id ORDER BY PrizeId";
                    command.CommandType = CommandType.Text;
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    //connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<string> list = new List<string>();
                        while (reader.Read())
                        {
                            list.Add((string)reader["NumberValue"]);
                        }
                        return list;
                    }
                }
            }
        }
    }
//}
