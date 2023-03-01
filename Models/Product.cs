using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace enityframework.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID {set; get;}

        [Required]
        [StringLength(50)]
        public string ProductName {set; get;}
        [StringLength(50)]
        public string Provider {set; get;}
        public void PrintInfo() => Console.WriteLine($"{ProductID} - {ProductName} -{Provider}");
    }
}