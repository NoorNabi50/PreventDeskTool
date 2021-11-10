using Microsoft.EntityFrameworkCore;
using PreventDeskTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreventDeskTool
{
    public class PDTDBContext:DbContext
    {

        public PDTDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


       public DbSet<User> users { get; set; }
    }
}
