using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ModelViews;

namespace WebApp.Models
{
    public class MemberRepository : BaseRepository
    {
        private IConfiguration configuration;

        public MemberRepository(IConfiguration configuration) : base(configuration) { }
        public MemberRepository(IDbConnection connection) : base(connection) { }
        public int UpdateMemberToken(ForgotModel obj)
        {
            return connection.Execute("UpdateMemberToken", obj, commandType: CommandType.StoredProcedure);
        }
        public int RecoveryPassword(RecoveryModel obj)
        {
            return connection.Execute("RecoveryPassword", new { Token = obj.Token, Password = Helper.Hash(obj.Password) }, commandType: CommandType.StoredProcedure);
        }
        public Member GetMemberById(string id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //tại sao ko lấy password
                string sql = "SELECT MemberId,Username,Email,Gender FROM Member WHERE MemberId=@id";
                return connection.QueryFirstOrDefault<Member>(sql,new { Id = id });
            }
        }
       public IEnumerable<Member> GetMembers()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //tại sao ko lấy password
                return connection.Query<Member>("SELECT MemberId,Username,Email,Gender FROM Member");
            }
        }
        

        public int Add(Member obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                obj.MemberId = Helper.RandomString(64);
                var member = new
                {
                    MemberId = obj.MemberId,
                    Username = obj.Username,
                    Password = Helper.Hash( obj.Password),
                    Email = obj.Email,
                    Gender = obj.Gender
                };
                return connection.Execute("AddMember", member, commandType: CommandType.StoredProcedure);
            }    
        }
        public Member Login(LoginModel obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var member = new { Username = obj.Username, Password = Helper.Hash(obj.Password) };
                return connection.QuerySingleOrDefault<Member>("LoginMember", member, commandType: CommandType.StoredProcedure);
            }    
        }
    }
}
