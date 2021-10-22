using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SiteProvider : IDisposable
    {
        IConfiguration configuration;
        IDbConnection connection;
        public SiteProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            Console.WriteLine("***********Constructor***********");
            //Van con khuyet diem
            //Console.WriteLine("***********Da mo ket noi trong Constructor***********");
            //connection = new SqlConnection(configuration.GetConnectionString("Lotte"));
            //connection.Open();
        }
        IDbConnection Connection
        {
            get
            {
                if (connection is null)
                {
                    Console.WriteLine("**************Da mo ket noi**************");
                    connection = new SqlConnection(configuration.GetConnectionString("Lotte"));
                    connection.Open();
                }
                return connection;
            }
        }
        public void Dispose()
        {
            //Console.WriteLine("***********Site Provider Dispose***********");
            if (connection != null)
            {
                Console.WriteLine("**************Da dong ket noi****************");
                connection.Close();
            }
        }
        ProvinceRepository province;
        ResultRepository result;
        NumberRepository number;
        PrizeRepository prize;
        PatternRepository pattern;
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category is null)
                {
                    category = new CategoryRepository(Connection);
                }
                return category;
            }
        }
        public ProvinceRepository Province
        {
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(configuration);
                }
                return province;
            }
        }
        public ResultRepository Result
        {
            get
            {
                if (result is null)
                {
                    //result = new ResultRepository(configuration);
                    //result = new ResultRepository(connection);
                    result = new ResultRepository(Connection);
                }
                return result;
            }
        }
        public NumberRepository Number
        {
            get
            {
                if (number is null)
                {
                    number = new NumberRepository(configuration);
                }
                return number;
            }
        }
        public PrizeRepository Prize
        {
            get
            {
                if (prize is null)
                {
                    prize = new PrizeRepository(configuration);
                }
                return prize;
            }
        }
        public PatternRepository Pattern
        {
            get
            {
                if (pattern is null)
                {
                    pattern = new PatternRepository(configuration);
                }
                return pattern;
            }
        }
    }
}
