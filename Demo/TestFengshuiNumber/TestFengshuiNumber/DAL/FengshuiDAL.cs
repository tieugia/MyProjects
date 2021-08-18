using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFengshuiNumber.Model;

namespace TestFengshuiNumber.DAL
{
    public class FengshuiDAL
    {
        private string _connectionString;
        public FengshuiDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DevConnection");
        }
        public List<Fengshui> GetList()
        {
            var listFengshui = new List<Fengshui>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("usplistFengshuinumber", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listFengshui.Add(new Fengshui
                        {
                            phoneNumber = rdr[0].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listFengshui;
        }
    }
}
