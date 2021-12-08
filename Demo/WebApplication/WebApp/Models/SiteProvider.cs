using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SiteProvider
    {
        IDbConnection connection;
        IConfiguration configuration;
        public SiteProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            connection = new SqlConnection(configuration.GetConnectionString("Vietnam"));
        }
        AccessRepository access;
        RoleRepository role;
        MemberRepository member;
        ImageRepository image;
        public ImageRepository Image
        {
            get
            {
                if (image is null)
                {
                    image = new ImageRepository(connection);
                }
                return image;
            }
        }
        public MemberRepository Member
        {
            get
            {
                if(member is null)
                {
                    member = new MemberRepository(connection);
                }
                return member;
            }
        }
        public RoleRepository Role
        {
            get
            {
                if(role is null)
                {
                    role = new RoleRepository(configuration);
                }
                return role;
            }
        }
        public AccessRepository Access
        {
            get
            {
                if(access==null)
                {
                    access = new AccessRepository(connection);
                }
                return access;
            }
        }
    }
}
