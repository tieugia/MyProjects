using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(IConfiguration configuration) : base(configuration) { }
        public IEnumerable<Role> GetAllRolesByMemberId(string id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Role>("GetAllRolesByMemberId", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<string> GetRolesByMemberId(string id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<string>("GetRolesByMemberId", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<Role> GetRoles()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Role>("SELECT * FROM Role");
            }
        }
        public int Add(Role obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute("INSERT INTO Role (RoleName) VALUES (@Name)", new { Name = obj.RoleName });
            }
        }
    }
}
