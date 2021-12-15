using System.Collections.Generic;
using System.Data;
using Dapper;

namespace WebApp.Models
{
    public class PdfRepository : BaseRepository
    {
        public PdfRepository(IDbConnection connection):base(connection){}
        public IEnumerable<Pdf> GetPdfs()
        {
            return connection.Query<Pdf>("SELECT * FROM Pdf");
        }
        public Pdf GetPdfById(int id)
        {
            return connection.QuerySingleOrDefault<Pdf>("SELECT * FROM Pdf WHERE PdfId = @Id", new { Id = id });
        }
        public int Add(Pdf obj)
        {
            return connection.Execute("INSERT INTO Pdf(PdfUrl, Size) VALUES (@Url, @Size)", new { Url = obj.PdfUrl, Size = obj.Size });
        }
    }
}
