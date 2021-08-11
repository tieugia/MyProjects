using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Diary
    {
        [Key]
        public int? DiaryId { get; set; }
        public int? UserID { get; set; }
        public User user { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
