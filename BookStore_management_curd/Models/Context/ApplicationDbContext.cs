using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore_management_curd.Models.Context
{
    public class ApplicationDbContext :DbContext 
    {
        public ApplicationDbContext() : base("name =BookStore ")
        {

        } 
      public   DbSet<bookstore> book { get; set; } 
    }

    
}