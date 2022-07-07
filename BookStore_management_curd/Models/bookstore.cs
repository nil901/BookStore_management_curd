using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore_management_curd.Models
{
    public class bookstore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        public string Authers { get; set; }

        [Column("Year")]
        [Display(Name = "Publish Year")]
        [Required]
        public string publishYear { get; set; }

        [Column("Price")]
        [Display(Name = "Price")]
        [Required]
        public decimal BasePrice { get; set; }
    }
}