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
        public int Add(Image obj)
        {
            var image = new
            {
                Original = obj.ImageOriginal,
                Url = obj.ImageUrl,
                Type = obj.ImageType,
                Size = obj.ImageSize
            };
            string sql = "INSERT INTO Image(ImageOriginal, ImageUrl, ImageType, ImageSize) VALUES (@Original, @Url, @Type, @Size)";
            return connection.Execute(sql, image);
        }
        public IEnumerable<Image> GetImages()
        {
            return connection.Query<Image>("SELECT * FROM Image");
        }
        //public int Add(Access obj)
        //{
        //    var access = new { RoleId = obj.RoleId, Name = obj.AccessName, Url = obj.AccessUrl };
        //    return connection.Execute("AddAccess", access, commandType: CommandType.StoredProcedure);
        //}
        //public IEnumerable<Access> GetAccessesByMemberId(string id)
        //{
        //    return connection.Query<Access>("GetAccessesByMemberId", new { Id = id }, commandType: CommandType.StoredProcedure);
        //}
    }
}
