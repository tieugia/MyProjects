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
            Print();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void Print()
        {
            string[] lastTaboo = { "00", "66", "04", "45", "85", "27", "67", "17", "57", "97", "98", "58", "42", "82", "69" };
            var FengshuiDAL = new FengshuiDAL(_iconfiguration);
            var listNumberModel = FengshuiDAL.GetList();
            Console.WriteLine("Your Fengshui number is:");
            Console.WriteLine();
            listNumberModel.ForEach(item =>
            {
                for (int i = 0; i < lastTaboo.Length; i++)
                {
                    var sub = item.phoneNumber.Substring(item.phoneNumber.Length - 2);
                    if (sub != lastTaboo[i])
                    {
                        Console.WriteLine(item.phoneNumber);
                        break;
                    }
                }
            });
            Console.WriteLine();
            Console.WriteLine("Press any key to stop.");
        }
    }
}
