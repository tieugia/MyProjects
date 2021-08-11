using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Library.Controllers
{
    public class DiariesController : Controller
    {
        private readonly Context _context;
        public DiariesController(Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Diary.Include(p => p.Book).ToList());
        }
        public ActionResult Borrow(int[] id, int[] amount)
        {
            int uid = int.Parse(HttpContext.Session.GetString("userId"));
            var user = _context.User.Find(uid);
            if (ModelState.IsValid && user.Credit >= 5)
            {
                int sum = 0;
                for (int i = 0; i < amount.Length; i++)
                {
                    int a = amount[i];
                    if (a > 0)
                    {
                        sum += a;
                    }
                }
                if (sum <= 5)
                {
                    user.Credit -= 5 * sum;
                    _context.User.Update(user);
                    _context.SaveChanges();
                    for (int i = 0; i < amount.Length; i++)
                    {
                        if (amount[i] > 0)
                        {
                            var diary = new Diary();
                            int idd = id[i];
                            diary = _context.Diary.Find(idd);
                            diary.DiaryId = null;
                            diary.Amount = amount[i];
                            diary.BorrowDate = DateTime.Now;
                            diary.ExpiredDate = DateTime.Now.AddDays(5);
                            _context.Add(diary);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Diaries");
        }
        public ActionResult Return(int[] iname, int[] amountR, int[] diaryId)
        {
            int credit = 0;
            int uid = int.Parse(HttpContext.Session.GetString("userId"));
            var user = _context.User.Find(uid);
            for (int i = 0; i < amountR.Length; i++)
            {
                int idd = iname[i];
                int a = amountR[i];
                if (amountR[i] > 0)
                {
                    var diary = _context.Diary.Where(w => w.BookId == idd && w.ReturnDate != null).ToList();
                    int total = diary.Sum(item => item.Amount);
                    if (total > 0 || diary.Count == 0)
                    {
                        if (diary.Count > 0)
                        {
                            if (total <= diary[0].Amount)
                            {
                                var diary1 = _context.Diary.Find(idd);
                                diary1.DiaryId = null;
                                if (ModelState.IsValid && !(diary1.BorrowDate == null) && !(diary1.ExpiredDate == null))
                                {
                                    diary1.Amount = amountR[i];
                                    diary1.ReturnDate = DateTime.Now;
                                    if (diary1.ReturnDate > diary1.ExpiredDate)
                                    {
                                        credit += (diary1.ReturnDate - diary1.ExpiredDate).Value.Days;
                                    }
                                    _context.Add(diary1);
                                }
                            }
                        }
                        else
                        {
                            var diary1 = _context.Diary.Find(idd);
                            diary1.DiaryId = null;
                            if (ModelState.IsValid && !(diary1.BorrowDate == null) && !(diary1.ExpiredDate == null))
                            {
                                diary1.Amount = amountR[i];
                                diary1.ReturnDate = DateTime.Now;
                                if (diary1.ReturnDate > diary1.ExpiredDate)
                                {
                                    credit += (diary1.ReturnDate - diary1.ExpiredDate).Value.Days;
                                }
                                _context.Add(diary1);
                            }
                        }
                    }
                }
            }
            if (credit > 0)
            {
                user.Credit -= credit;
                _context.User.Update(user);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Diaries");
        }
    }
}


