using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;

namespace DataLayer
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext()
        {

        }

        public GamesDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL(@"Server=127.0.0.1;Port=3306;Database=GamesDB;Uid=root;Pwd=root;");

        //}

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
