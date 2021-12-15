using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class MemberInRoleRepository : BaseRepository
    {
        public MemberInRoleRepository(IDbConnection connection) : base(connection) { }
        public int Add(MemberInRole obj)
        {
            return connection.Execute("SaveMemberInRole", obj, commandType: CommandType.StoredProcedure);
        }
    }
}
