﻿using Microsoft.EntityFrameworkCore;
using PriceCheck.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Data.Context
{
    public class PriceCheckContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<PriceChange> PriceChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=priceCheck.db");
        }
    }
}
