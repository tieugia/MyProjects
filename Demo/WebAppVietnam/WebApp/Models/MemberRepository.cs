using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApp.ModelViews;

namespace WebApp.Models
{
    public class MemberRepository : BaseRepository
    {
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
            string sql = "SELECT MemberId, Username, Email, Gender FROM Member WHERE MemberId = @Id";
            return connection.QueryFirstOrDefault<Member>(sql, new { Id = id });
        }
        public int Add(Member obj)
        {
            obj.MemberId = Helper.RandomString(64);
            var member = new
            {
                MemberId = obj.MemberId,
                Username = obj.Username,
                Password = Helper.Hash(obj.Password),
                Email = obj.Email,
                Gender = obj.Gender
            };
            return connection.Execute("AddMember", member, commandType: CommandType.StoredProcedure);
        }
        public Member Login(LoginModel obj)
        {
            var member = new
            {
                Username = obj.Username,
                Password = Helper.Hash(obj.Password)
            };
            return connection.QuerySingleOrDefault<Member>("LoginMember", member, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Member> GetMembers()
        {
            return connection.Query<Member>("SELECT MemberId, Username, Email, Gender FROM Member");
        }
    }
}
