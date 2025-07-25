using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
               : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {   Id = "2b245ea1-fc39-4035-a199-961caa71f622",
                    Name="Admin",
                    NormalizedName ="ADMIN"
                },
                new IdentityRole
                {   Id = "cc9131fd-9d63-439e-b9dc-ce2120065171",
                    Name="User",
                    NormalizedName ="USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }    

}