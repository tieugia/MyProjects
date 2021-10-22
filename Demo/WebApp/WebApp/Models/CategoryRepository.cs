using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CategoryRepository : Repository
    {
        //string connectionString; 
        //public CategoryRepository(IConfiguration configuration) : base(configuration)
        //{
        //    connectionString = configuration.GetConnectionString("Lotte");
        //    Console.WriteLine(connectionString);
        //}
        public CategoryRepository(IDbConnection connection) : base(connection) { }
        public int Edit(Category obj)
        {
            Parameter[] parameters =
            {
                new Parameter{Name="@name", Value=obj.Name},
                new Parameter{Name="@id", Value=obj.Id}
            };
            return Save("UPDATE Category SET CategoryName = @name WHERE CategoryID = @id", parameters);
        }
        public int Delete(int id)
        {
            return Save("DELETE Category WHERE CategoryId = @id", new Parameter { Name = "@id", Value = id });
        }
        public int Add(Category obj)
        {
            return Save("INSERT INTO Category (CategoryName) VALUES (@name)", new Parameter { Name = "@name", Value = obj.Name });
        }
        //SELECT => IDataReader
        //UPDATE, INSERT, DELETE => ExecuteNonQuery
        //public int Edit(Category obj)
        //{
        //    IDbConnection connection = new SqlConnection(connectionString);
        //    IDbCommand command = connection.CreateCommand();
        //    command.CommandText = "UPDATE Category SET CategoryName = @name WHERE CategoryId = @id";

        //    IDataParameter nameParameter = command.CreateParameter();
        //    nameParameter.ParameterName = "@name";
        //    nameParameter.Value = obj.Name;
        //    command.Parameters.Add(nameParameter);

        //    IDataParameter idParameter = command.CreateParameter();
        //    idParameter.ParameterName = "@id";
        //    idParameter.Value = obj.Id;
        //    command.Parameters.Add(idParameter);

        //    connection.Open();
        //    int ret = command.ExecuteNonQuery();
        //    command.Dispose();
        //    connection.Dispose();
        //    return ret;

        //}
        public Category GetCategory(int id)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Category WHERE CategoryId = @id";

            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@id";
            parameter.Value = id;
            command.Parameters.Add(parameter);
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            Category obj = null;
            if (reader.Read())
            {
                obj = new Category
                {
                    Id = (int)reader["CategoryId"],
                    Name = (string)reader["CategoryName"]
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return obj;
        }
        //public int Delete(int id)
        //{
        //    IDbConnection connection = new SqlConnection(connectionString);
        //    IDbCommand command = connection.CreateCommand();
        //    //2 cach: cau lenh sql va Thu tuc
        //    command.CommandText = "DELETE Category WHERE CategoryId = @id";
        //    //Thiet lap tham so
        //    IDataParameter parameter = command.CreateParameter();
        //    parameter.ParameterName = "@id";
        //    parameter.Value = id;
        //    command.Parameters.Add(parameter);
        //    connection.Open();
        //    //Thuc thi xoa
        //    int ret = command.ExecuteNonQuery();
        //    command.Dispose();
        //    connection.Dispose();
        //    return ret;
        //}
        //public int Add(Category obj)
        //{
        //    IDbConnection connection = new SqlConnection(connectionString);
        //    IDbCommand command = connection.CreateCommand();
        //    command.CommandText = "INSERT INTO Category(CategoryName) VALUES (@name)";
        //    //Tao parameter
        //    IDataParameter parameter = command.CreateParameter();
        //    parameter.Value = obj.Name;
        //    parameter.ParameterName = "@name";
        //    command.Parameters.Add(parameter);

        //    command.Dispose();
        //    connection.Open();
        //    //Them du lieu vao bang
        //    int ret = command.ExecuteNonQuery();
        //    connection.Close();
        //    return ret;
        //}
        public List<Category> GetCategories()
        {
            //Tao ket noi SQL Server
            IDbConnection connection = new SqlConnection(connectionString);
            //Tao Command thuc thi Sql
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "Select * from Category";
            //Mo ket noi
            connection.Open();
            //Doc du lieu tu bang
            IDataReader reader = command.ExecuteReader();
            List<Category> list = new List<Category>();
            //Duyet tung dong trong bang
            while (reader.Read())
            {
                Category obj = new Category
                {
                    //Doc tung cot trong bang
                    Id = (int)reader["CategoryId"],
                    Name = (string)reader["CategoryName"]
                };
                list.Add(obj);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }
    }
}
