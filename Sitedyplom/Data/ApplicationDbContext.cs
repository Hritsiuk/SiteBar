using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sitedyplom.Models;

namespace Sitedyplom.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
        public DbSet<User> UsersInformation { get; set; }

        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
