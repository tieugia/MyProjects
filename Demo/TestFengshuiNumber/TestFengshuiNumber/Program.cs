using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TestFengshuiNumber.DAL;

namespace TestFengshuiNumber
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            PrintCountries();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void PrintCountries()
        {
            var FengshuiDAL = new FengshuiDAL(_iconfiguration);
            var listNumberModel = FengshuiDAL.GetList();
            Console.WriteLine("Your Fengshui number is:");
            Console.WriteLine();
            listNumberModel.ForEach(item =>
            {
                Console.WriteLine(item.phoneNumber);
            });
            Console.WriteLine();
            Console.WriteLine("Press any key to stop.");
        }
    }
}
