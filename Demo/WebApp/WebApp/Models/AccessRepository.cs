using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AccessRepository : BaseRepository
    {
        public AccessRepository(IDbConnection connection) :base(connection)
        {
        }
        public IEnumerable<Access> GetAccesses()
        {
            return connection.Query<Access>("GetAccesses", commandType: CommandType.StoredProcedure);
        }
        public int Add(Access obj)
        {
            var access = new { RoleId = obj.RoleId, Name = obj.AccessName, Url = obj.AccessUrl };
            return connection.Execute("AddAccess", access, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Access> GetAccessesByMemberId(string id)
        {
            return connection.Query<Access>("GetAccessesByMemberId", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
