using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Crawler
{
    class Program
    {
        static List<Result> GetResults(string url, Province province)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//ul[@class=\"menu\"]/li/a/span");
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class=\"box_kqxs\"]");
            //List<Province> list = new List<Province>();
            List<Result> results = new List<Result>();
            foreach (HtmlNode node in nodes)
            {
                //string text = node.InnerText;
                //list.Add(new Province
                //{
                //    AreaId = areaId,
                //    Name = text.Substring("Kết quả xổ số ".Length),
                //    PatternId = patternId
                //});
                HtmlNodeCollection titles = node.SelectNodes(".//div[@class=\"title\"]/a");
                DateTime date = DateTime.ParseExact(titles[1].InnerText.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine(date);
                Result result = new Result
                {
                    Date = date,
                    Province = province
                    //ProvinceId = 304,
                };
                results.Add(result);
                HtmlNodeCollection trs = node.SelectNodes(".//table[@class=\"box_kqxs_content\"]/tbody/tr");
                byte c = 0;
                List<Number> numbers = new List<Number>();
                foreach (HtmlNode tr in trs)
                {
                    HtmlNodeCollection divs = tr.SelectNodes("./td/div");
                    foreach (HtmlNode div in divs)
                    {
                        Console.WriteLine(div.InnerText.Trim());
                        numbers.Add(new Number
                        {
                            PrizeId = c,
                            Value = div.InnerText.Trim(),
                            Result = result
                        });

                        result.Numbers = numbers;
                        //Console.WriteLine(tr.InnerText);
                    }
                    c++;
                }
                //using (LotteContext context = new LotteContext())
                //{
                //    context.Results.AddRange(results);
                //    Console.WriteLine(context.SaveChanges());
                //}
            }
            return results;
        }
        static List<Province> GetProvinces(string url, short areaId, byte patternId)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//ul[@class=\"menu\"]/li/a/span");

            List<Province> list = new List<Province>();
            foreach (HtmlNode node in nodes)
            {
                string text = node.InnerText;
                list.Add(new Province
                {
                    AreaId = areaId,
                    Name = text.Substring("Kết quả xổ số ".Length),
                    PatternId = patternId
                });

            }
            return list;
        }
        static void LoadProvinces()
        {
            string url = "https://www.minhngoc.net.vn/ket-qua-xo-so/mien-nam/tp-hcm.html";
            List<Province> list = GetProvinces(url, 102, 1);
            //Entity Framework
            using (LotteContext context = new LotteContext())
            {
                context.Provinces.AddRange(list);
                Console.WriteLine(context.SaveChanges());
            }
        }
        static void Main(string[] args)
        {
            //LoadProvinces();
            string url = "https://www.minhngoc.net.vn/ket-qua-xo-so/mien-nam/tp-hcm.html";
            //List<Result> results = GetResults(url);
            //Console.WriteLine(Save(results));
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//ul[@class=\"menu\"]/li/a");
            List<Province> provinces = new List<Province>();
            foreach (HtmlNode node in nodes)
            {
                string href = node.GetAttributeValue("href", "Not found");
                Console.WriteLine(href);
                //Console.WriteLine(node.GetAttributeValue("href", "Not found"));
                //Console.WriteLine(node.InnerText);
                string provinceName = node.InnerText.Substring("Kết quả xổ số ".Length);
                Console.WriteLine(provinceName);
                Province province = new Province
                {
                    AreaId = 3,
                    Name = provinceName,
                    PatternId = 1
                };
                provinces.Add(province);
                province.Results = GetResults("https://www.minhngoc.net.vn/" + href, province);
            }
            using (LotteContext context = new LotteContext())
            {
                context.Provinces.AddRange(provinces);
                Console.WriteLine(context.SaveChanges());
            }
        }
        static int Save(List<Result> results)
        {
            using (LotteContext context = new LotteContext())
            {
                context.Results.AddRange(results);
                return context.SaveChanges();
            }
        }
    }
}
