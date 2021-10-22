using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class PrizeRepository : Repository
    {
        public PrizeRepository(IConfiguration configuration) : base(configuration) { }
        public List<Prize> GetPrizes()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "GetPrizes";
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            List<Prize> list = new List<Prize>();
            while (reader.Read())
            {
                list.Add(new Prize
                {
                    Id = (byte)reader["PrizeId"],
                    Name = (string)reader["PrizeName"]
                });
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }
        public Prize GetPrize(byte id)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "GetPrize";
            command.CommandType = CommandType.StoredProcedure;

            IDataParameter parameter = command.CreateParameter();
            parameter.Value = id;
            parameter.ParameterName = "@id";
            command.Parameters.Add(parameter);

            connection.Open();
            IDataReader reader = command.ExecuteReader();
            Prize obj = null;
            while (reader.Read())
            {
                obj = new Prize
                {
                    Id = (byte)reader["PrizeId"],
                    Name = (string)reader["PrizeName"]
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return obj;
        }
        public int EditPrize(Prize obj)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "EditPrize";
            command.CommandType = CommandType.StoredProcedure;

            IDataParameter id = command.CreateParameter();
            id.Value = obj.Id;
            id.ParameterName = "@id";
            id.DbType = DbType.Byte;
            command.Parameters.Add(id);

            IDataParameter name = command.CreateParameter();
            name.Value = obj.Name;
            name.ParameterName = "@name";
            command.Parameters.Add(name);

            connection.Open();
            int ret = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return ret;
        }
        public int Add(Prize obj)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "AddPrize";
            command.CommandType = CommandType.StoredProcedure;

            IDataParameter idParameter = command.CreateParameter();
            idParameter.Value = obj.Id;
            idParameter.ParameterName = "@id";
            command.Parameters.Add(idParameter);

            IDataParameter nameParameter = command.CreateParameter();
            nameParameter.Value = obj.Name;
            nameParameter.ParameterName = "@name";
            command.Parameters.Add(nameParameter);

            connection.Open();
            int ret = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return ret;
        }
        public int Delete(byte id)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "DeletePrize";
            command.CommandType = CommandType.StoredProcedure;

            IDataParameter parameter = command.CreateParameter();
            parameter.Value = id;
            parameter.ParameterName = "@id";
            command.Parameters.Add(parameter);

            connection.Open();
            int ret = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return ret;
        }
        public Prize[] GetPrizesAndCount()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetPrizesAndCount";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    //int c = (int)command.ExecuteScalar();//Tra ve 1 gia tri
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int c = (int)reader[0];
                            Prize[] arr = new Prize[c];
                            reader.NextResult();
                            while (reader.Read())
                            {
                                Prize prize = new Prize
                                {
                                    Id = (byte)reader["PrizeId"],
                                    Name = (string)reader["PrizeName"]
                                };
                                arr[prize.Id] = prize;
                            }
                            return arr;
                        }
                        return null;
                        //string[] arr = new string[c];
                        //while (reader.Read())
                        //{
                        //    byte i = (byte)reader["PrizeId"];
                        //    arr[i] = (string)reader["PrizeName"];
                        //}
                        //return arr;
                    }

                }
            }
        }
        public int Count()
        {
            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                using (IDbCommand command=connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Prize";//COUNT, SUM, AVG, STDV
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
    }
}

