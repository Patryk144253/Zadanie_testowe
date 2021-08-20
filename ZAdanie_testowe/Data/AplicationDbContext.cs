using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ZAdanie_testowe.Models;

namespace ZAdanie_testowe.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext() : base("AplicationDbContext")
        {

        }

        public DbSet<Rezerwacja> Rezerwacja { get; set; }
        public DbSet<Gosc> Gosc { get; set; }
        public DbSet<Przejsciowa> Przejsciowa { get; set; }

    }
}