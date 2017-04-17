using PriceCheck.Core.Enums;
using PriceCheck.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> productsQuery, SortType sortType, SortOrder sortOrder)
        {
            switch (sortType)
            {
                case SortType.Name:
                    if (sortOrder == SortOrder.Ascending)
                    {
                        productsQuery = productsQuery.OrderBy(x => x.Name);
                    }
                    else
                    {
                        productsQuery = productsQuery.OrderByDescending(x => x.Name);
                    }
                    break;
                case SortType.DateCreated:
                    if (sortOrder == SortOrder.Ascending)
                    {
                        productsQuery = productsQuery.OrderBy(x => x.DateCreated);
                    }
                    else
                    {
                        productsQuery = productsQuery.OrderByDescending(x => x.DateCreated);
                    }
                    break;
                case SortType.Website:
                    if (sortOrder == SortOrder.Ascending)
                    {
                        productsQuery = productsQuery.OrderBy(x => x.Website);
                    }
                    else
                    {
                        productsQuery = productsQuery.OrderByDescending(x => x.Website);
                    }
                    break;
            }

            return productsQuery;
        }
    }
}
