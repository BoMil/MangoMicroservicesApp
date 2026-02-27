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

        // !This is an example of how we can add data to the database
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Coupon>().HasData(
        //         new Coupon()
        //         {
        //             CouponId = 1,
        //             CouponCode = "1-OFF",
        //             DiscountAmount = 10,
        //             MinAmount = 100,
        //             // LastUpdated = DateTime.Now
        //         },
        //         new Coupon()
        //         {
        //             CouponId = 2,
        //             CouponCode = "2-OFF",
        //             DiscountAmount = 20,
        //             MinAmount = 200,
        //             // LastUpdated = DateTime.Now
        //         },
        //         new Coupon()
        //         {
        //             CouponId = 3,
        //             CouponCode = "3-OFF",
        //             DiscountAmount = 30,
        //             MinAmount = 300,
        //             // LastUpdated = DateTime.Now
        //         }
        //     );

        //     modelBuilder.Entity<PointOfInterest>().HasData(
        //         new PointOfInterest("Eiffel Tower")
        //         {
        //             Id = 1,
        //             CityId = 1,
        //             Description = "The Eiffel Tower is a wrought iron lattice tower in Paris, France. It is the world's oldest existing structure."
        //         },
        //         new PointOfInterest("London Eye")
        //         {
        //             Id = 2,
        //             CityId = 2,
        //             Description = "The London Eye is a giant Ferris wheel in London, England. It is the world's tallest structure."
        //         },
        //         new PointOfInterest("Statue of Liberty")
        //         {
        //             Id = 3,
        //             CityId = 3,
        //             Description = "The Statue of Liberty is a colossal neoclassical sculpture in New York, United States. It is the world's largest statue."
        //         }
        //     );
        //     base.OnModelCreating(modelBuilder);
        // }


    }
}