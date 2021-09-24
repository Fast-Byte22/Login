using System;
using Login.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace Login.Context
{
    public class LoginContext000 : DbContext
    {
        public LoginContext000(DbContextOptions<LoginContext000> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                //entity.Property( e => e.Id).HasColumnName
            });
        }
    }
}

