using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ImageRepository : BaseRepository
    {
        public ImageRepository(IDbConnection connection) : base(connection) { }
        public IEnumerable<Image> GetImages()
        {
            return connection.Query<Image>("SELECT * FROM Image");
        }
        public int Add(Image obj)
        {
            var image = new { Original = obj.ImageOriginal, Url = obj.ImageUrl, Type = obj.ImageType, Size = obj.ImageSize };
            string sql = "INSERT INTO Image(ImageOriginal, ImageUrl, ImageType, ImageSize) VALUES (@Original, @Url, @Type, @Size)";
            return connection.Execute(sql, image);
        }
        public string GetUrlImageById(int id)
        {
            return connection.QuerySingleOrDefault<string>("SELECT ImageUrl FROM Image WHERE ImageId = @Id", new { Id = id });
        }
        public int Delete(int id)
        {
            return connection.Execute("DELETE Image WHERE ImageId = @Id", new { Id = id });
        }
        public IEnumerable<string> GetUrlsById(int[] ids)
        {
            string sql = "SELECT ImageUrl FROM Image WHERE ImageId IN @Ids";
            return connection.Query<string>(sql, new { Ids = ids });
        }
        public int Delete(int[] ids)
        {
            string sql = "DELETE Image WHERE ImageId IN @Ids";
            return connection.Execute(sql, new { Ids = ids });
        }
    }
}
