using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ResultRepository: Repository
    {
        //fields
        //IDbConnection connection;
        public ResultRepository(IDbConnection connection) : base(connection) { }

        public int Add(Result obj)
        {
            Parameter[] parameters =
            {
                new Parameter{Name="@id", DbType=DbType.Int32, Direction=ParameterDirection.Output},
                new Parameter{Name="@Date",DbType=DbType.DateTime, Value=obj.Date},
                new Parameter{Name="@provinceId", Value=obj.ProvinceId}
            };
            int ret = Save("AddResult", parameters, CommandType.StoredProcedure);
            if (ret>0)
            {
                //obj.Id = (int)parameters[0].DataParameter.Value;
                obj.Id = (int)parameters[0].Get<int>();
            }
            return ret;
        }
        //public ResultRepository(IConfiguration configuration) : base(configuration) { }
        public Result GetResult(int id)
        {
            //using (IDbConnection connection=new SqlConnection(connectionString))
            //{
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetResult";
                command.CommandType = CommandType.StoredProcedure;
                IDataParameter parameter = command.CreateParameter();
                parameter.Value = id;
                parameter.ParameterName = "@id";
                command.Parameters.Add(parameter);
                //connection.Open();
                IDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Fetch(reader);
                }
                return null;
            }
        }
        //}
        static Result Fetch(IDataReader reader)
        {
            return new Result
            {
                Id = (int)reader["ResultId"],
                Date = (DateTime)reader["ResultDate"],
                ProvinceId = (short)reader["ProvinceId"],
                ProvinceName = (string)reader["ProvinceName"]
            };
        }
        public List<Result> GetResults()
        {
            return FetchAll<Result>("GetResults", Fetch, CommandType.StoredProcedure);
        }
        //public List<Result> GetResults()
        //{
        //    //using (IDbConnection connection = new SqlConnection(connectionString))
        //    //{
        //    using (IDbCommand command = connection.CreateCommand())
        //    {
        //        command.CommandText = "GetResults";
        //        command.CommandType = CommandType.StoredProcedure;
        //        //connection.Open();
        //        using (IDataReader reader = command.ExecuteReader())
        //        {
        //            List<Result> list = new List<Result>();
        //            while (reader.Read())
        //            {
        //                list.Add(new Result
        //                {
        //                    Id = (int)reader["ResultId"],
        //                    Date = (DateTime)reader["ResultDate"],
        //                    ProvinceId = (short)reader["ProvinceId"]
        //                });
        //            }
        //            return list;
        //        }
        //    }
        //}
        //}
        //public int Add(Result obj)
        //{
        //    //Khuyet diem
        //    //using (IDbConnection connection = new SqlConnection(connectionString))
        //    //{
        //    using (IDbCommand command = connection.CreateCommand())
        //    {
        //        command.CommandText = "AddResult";
        //        command.CommandType = CommandType.StoredProcedure;
        //        //Lay tham so dau ra
        //        IDataParameter idParameter = command.CreateParameter();
        //        idParameter.ParameterName = "@id";
        //        //default string
        //        idParameter.DbType = DbType.Int32;
        //        idParameter.Direction = ParameterDirection.Output;
        //        command.Parameters.Add(idParameter);

        //        IDataParameter dateParameter = command.CreateParameter();
        //        dateParameter.Value = obj.Date;
        //        dateParameter.ParameterName = "@date";
        //        command.Parameters.Add(dateParameter);

        //        IDataParameter provinceParameter = command.CreateParameter();
        //        provinceParameter.Value = obj.ProvinceId;
        //        provinceParameter.ParameterName = "@provinceId";
        //        command.Parameters.Add(provinceParameter);

        //        //connection.Open();
        //        int ret = command.ExecuteNonQuery();
        //        if (ret > 0)
        //        {
        //            obj.Id = (int)idParameter.Value;
        //        }
        //        return ret;
        //        //ret >= 1: Trang thai tra ve thanh cong
        //        //ret = 0: Trang thai tra ve khong thanh cong
        //    }
        //}
    }
}
//}
