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
        MemberInRoleRepository memberInRole;
        ImageRepository image;
        PdfRepository pdf;
        DistrictRepository district;
        ProvinceRepository province;
        WardRepository ward;
        SalesRepository sales;
        SalesRecordRepository salesRecord;
        public SalesRecordRepository SalesRecord
        {
            get
            {
                if (salesRecord is null)
                {
                    salesRecord = new SalesRecordRepository(connection);
                }
                return salesRecord;
            }
        }
        public SalesRepository Sales
        {
            get
            {
                if (sales is null)
                {
                    sales = new SalesRepository(connection);
                }
                return sales;
            }
        }
        public WardRepository Ward
        {
            get
            {
                if (ward is null)
                {
                    ward = new WardRepository(connection);
                }
                return ward;
            }
        }
        public ProvinceRepository Province
        {
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(connection);
                }
                return province;
            }
        }
        public DistrictRepository District
        {
            get
            {
                if (district is null)
                {
                    district = new DistrictRepository(connection);
                }
                return district;
            }
        }
        public PdfRepository Pdf
        {
            get
            {
                if (pdf is null)
                {
                    pdf = new PdfRepository(connection);
                }
                return pdf;
            }
        }
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
        public MemberInRoleRepository MemberInRole
        {
            get
            {
                if (memberInRole is null)
                {
                    memberInRole = new MemberInRoleRepository(connection);
                }
                return memberInRole;
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
