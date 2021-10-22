using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ResultController : Controller
    {
        //provider.Result provider.Result;
        //provider.Province provider.Province;
        //provider.Number provider.Number;
        //provider.Prize provider.Prize;
        //provider.Pattern provider.Pattern;
        SiteProvider provider;
        public ResultController(SiteProvider provider)
        {
            this.provider = provider;
        }
        //SiteProvider provider;
        //public ResultController(IConfiguration configuration)
        //{
        //    provider = new SiteProvider(configuration);
        //    //provider.Result = new provider.Result(configuration);
        //    //provider.Province = new provider.Province(configuration);
        //    //provider.Number = new provider.Number(configuration);
        //    //provider.Prize = new provider.Prize(configuration);
        //    //provider.Pattern = new provider.Pattern(configuration);
        //}
        public IActionResult Index()
        {
            Console.WriteLine("***********Truoc khi ket thuc***********");
            return View(provider.Result.GetResults());
        }
        public IActionResult Create()
        {
            ViewBag.provinces = provider.Province.GetProvinces();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Result obj, string[] prizeId, string[] num)
        {
            int ret = provider.Result.Add(obj);
            List<Number> list = new List<Number>();
            for (int i = 0; i < prizeId.Length; i++)
            {
                list.Add(new Number
                {
                    ResultId = obj.Id,
                    PrizeId = byte.Parse(prizeId[i]),
                    Value = num[i]
                });
            }
            int t = provider.Number.Add(list);
            Console.WriteLine($"****************************Total Number: {t}");
            string[] msg = { "Failed", "Success" };
            TempData["msg"] = msg[ret];
            Console.WriteLine($"****************************ResultId: {obj.Id}");
            return Redirect($"/result/detail/{obj.Id}");
        }
        public IActionResult Detail3(int id)
        {
            //No co 17 so
            string[] arr = provider.Number.GetNumbersByResult(id).ToArray();
            Result obj = provider.Result.GetResult(id);
            //Pattern co 18 so

            ViewBag.pattern = provider.Pattern.GetShow(obj.ProvinceId);
            ViewBag.numbers = arr;
            return View(obj);
        }
        public IActionResult Detail2(int id)
        {
            List<Prize> prizes = provider.Prize.GetPrizes();
            ViewBag.prizes = prizes;
            List<Number> numbers = provider.Number.GetNumbers(id);
            //array, dict
            List<Number>[] arr = new List<Number>[prizes.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new List<Number>();
            }
            foreach (Number item in numbers)
            {
                arr[item.PrizeId].Add(item);
            }
            ViewBag.numbers = arr;
            return View(provider.Result.GetResult(id));

            //ViewBag.prizes = provider.Prize.GetPrizes();
            //ViewBag.numbers = provider.Number.GetNumbers(id);
            //return View(provider.Result.GetResult(id));
        }
        public IActionResult Detail(int id)
        {
            Prize[] prizes = provider.Prize.GetPrizesAndCount();
            foreach (Number item in provider.Number.GetNumbers(id))
            {
                byte i = item.PrizeId;
                if (prizes[i].Numbers is null)
                {
                    prizes[i].Numbers = new List<Number>();
                }
                prizes[i].Numbers.Add(item);
            }
            ViewBag.prizes = prizes;
            return View(provider.Result.GetResult(id));
        }
        public IActionResult Add(short id)
        {
            ViewBag.provinces = provider.Province.GetProvinces();
            ViewBag.pattern = provider.Pattern.GetAdd(id);
            return View(provider.Province.GetProvince(id));
        }
        [HttpPost]
        public IActionResult Add(short id, Result obj, string[] prizeId, string[] num)
        {
            obj.ProvinceId = id;
            int ret = provider.Result.Add(obj);
            List<Number> list = new List<Number>();
            for (int i = 0; i < prizeId.Length; i++)
            {
                list.Add(new Number
                {
                    ResultId = obj.Id,
                    PrizeId = byte.Parse(prizeId[i]),
                    Value = num[i]
                });
            }
            int t = provider.Number.Add(list);
            Console.WriteLine($"****************************Total Number: {t}");
            string[] msg = { "Failed", "Success" };
            TempData["msg"] = msg[ret];
            Console.WriteLine($"****************************ResultId: {obj.Id}");
            return Redirect($"/result/detail3/{obj.Id}");
        }
        public IActionResult Insert()
        {
            ViewBag.provinces = provider.Province.GetProvinces();
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Result obj, string[] prizeId, string[] num)
        {
            int ret = provider.Result.Add(obj);
            List<Number> list = new List<Number>();
            for (int i = 0; i < prizeId.Length; i++)
            {
                list.Add(new Number
                {
                    ResultId = obj.Id,
                    PrizeId = byte.Parse(prizeId[i]),
                    Value = num[i]
                });
            }
            int t = provider.Number.Add(list);
            string[] msg = { "Failed", "Success" };
            TempData["msg"] = msg[ret];
            return Redirect($"/result/detail3/{obj.Id}");
        }
        public IActionResult GetAdd(short id)
        {
            return Json(provider.Pattern.GetAdd(id));
        }
        public IActionResult GetAddByPattern(byte id)
        {
            return Json(provider.Pattern.GetAddById(id));
        }
        public IActionResult Edit(int id)
        {
            ViewBag.provinces = provider.Province.GetProvinces();
            Result obj = provider.Result.GetResult(id);
            ViewBag.pattern = provider.Pattern.GetAdd(obj.ProvinceId);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, string[] prizeId, string[] num)
        {
            List<Number> list = new List<Number>();
            for (int i = 0; i < prizeId.Length; i++)
            {
                list.Add(new Number
                {
                    //ResultId = id,
                    Id = long.Parse(prizeId[i]),
                    Value = num[i]
                });
            }
            int t = provider.Number.Edit(list);
            return Redirect($"/result/detail3/{id}");
        }
        public IActionResult GetNumbers(int id)
        {
            return Json(provider.Number.GetNumbers(id));
        }
    }
}
