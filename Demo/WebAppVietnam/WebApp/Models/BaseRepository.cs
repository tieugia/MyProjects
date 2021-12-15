using System.Data;

namespace WebApp.Models
{
    public class BaseRepository
    {
        protected string connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Vietnam");
        }
        protected IDbConnection connection;
        public BaseRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
    }
}
