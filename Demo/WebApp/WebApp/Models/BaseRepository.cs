using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public abstract class BaseRepository
    {
        protected string connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Vietnam");
        }
        protected IDbConnection connection;
        protected BaseRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
    }
}
