﻿using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { Id = 1, Name = "206" },
                new VehicleModel { Id = 2, Name = "پرشیا" },
                new VehicleModel { Id = 3, Name = "207" },
                new VehicleModel { Id = 4, Name = "کوییک" },
                new VehicleModel { Id = 5, Name = "شاهین" },
                new VehicleModel { Id = 6, Name = "رانا" },
                new VehicleModel { Id = 7, Name = "تیبا" }
            );
            base.OnModelCreating(modelBuilder);
        }
         
    }
}
