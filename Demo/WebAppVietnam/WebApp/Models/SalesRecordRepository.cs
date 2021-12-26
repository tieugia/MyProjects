using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class SalesRecordRepository : BaseRepository
    {
        public SalesRecordRepository(IDbConnection connection) : base(connection) { }
        public IEnumerable<SalesRecord> GetSalesRecords()
        {
            return connection.Query<SalesRecord>("StatisticSalesRecord", commandType: CommandType.StoredProcedure);
        }
    }
}
