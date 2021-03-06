using System;
using Microsoft.EntityFrameworkCore;
using PreventDeskTool.Models;

namespace PreventDeskTool
{
    public partial class PreventDeskToolDBContext : DbContext
    {
        public PreventDeskToolDBContext()
        {
        }

        public PreventDeskToolDBContext(DbContextOptions<PreventDeskToolDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }

       public  DbSet<Users> Users { get; set; }
       public  DbSet<Videos> Videos { get; set; }
       public DbSet<VideoMcQs> VideoMCQs { get; set; }
       public DbSet <Chat> Chat { get; set; }
       
    }
}
