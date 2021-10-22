using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public abstract class Repository
    {
        protected string connectionString;
        public Repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Lotte");
        }
        protected IDbConnection connection;
        public Repository(IDbConnection connection)
        {
            this.connection = connection;
        }
        protected void Set(IDbCommand command, Parameter obj)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.Value = obj.Value;
            parameter.ParameterName = obj.Name;
            //Thieu
            command.Parameters.Add(parameter);
        }
        protected void Set(IDbCommand command, Parameter[] parameters)
        {
            foreach (Parameter item in parameters)
            {
                Set(command, item);
            }
        }
        //Save: 3 truong hop insert, update, delete
        protected int Save(string sql, Parameter[] parameters, CommandType commandType = CommandType.Text)
        {
            using (IDbCommand command=connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = commandType;
                Set(command, parameters);
                return command.ExecuteNonQuery();
            }
        }
        public int Save(string sql, Parameter parameter, CommandType commandType = CommandType.Text)
        {
            return Save(sql, new Parameter[] { parameter }, commandType);
        }
        //Select, Count
        protected List<T> FetchAll<T>(string sql, Func<IDataReader, T> func, CommandType commandType = CommandType.Text)
        {
            using (IDbCommand command=connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = commandType;
                using (IDataReader reader=command.ExecuteReader())
                {
                    List<T> list = new List<T>();
                    while (reader.Read())
                    {
                        list.Add(func.Invoke(reader));
                    }
                    return list;
                }
            }
        }
    }
}
