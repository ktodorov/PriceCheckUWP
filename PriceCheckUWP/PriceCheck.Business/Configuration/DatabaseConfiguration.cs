using Microsoft.EntityFrameworkCore;
using PriceCheck.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Business.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddMigrations()
        {
            using (var db = new PriceCheckContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
