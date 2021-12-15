using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MemberInRoleRepository : BaseRepository
    {
        public MemberInRoleRepository(IConfiguration configuration) :base(configuration) { }
        public int Add(MemberInRole obj)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute("SaveMemberInRole", obj, commandType: CommandType.StoredProcedure);
            }    
        }
    }
}
