using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriceCheck.Data.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PriceCheck.Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public virtual void Adding(PriceCheckContext context)
        {
            if (Id == 0)
            {
                DateCreated = DateTime.Now;
                DateModified = DateTime.Now;
            }
        }

        public virtual void Changing(PriceCheckContext context, EntityEntry dbEntityEntry)
        {
            if (Id != 0)
            {
                DateModified = DateTime.Now;
            }
        }
    }
}
