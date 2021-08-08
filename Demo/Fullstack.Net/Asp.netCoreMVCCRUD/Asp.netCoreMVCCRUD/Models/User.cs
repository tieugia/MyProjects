using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Required(ErrorMessage ="This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(10)")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Position { get; set; }
    }
}