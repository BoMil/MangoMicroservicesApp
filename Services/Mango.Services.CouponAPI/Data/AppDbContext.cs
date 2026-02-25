using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        ///  This allow us to set the connection string in the Program.cs file
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }


    }
}