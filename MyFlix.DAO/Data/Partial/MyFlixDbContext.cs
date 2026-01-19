using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFlix.DAO.Models;


namespace MyFlix.DAO.Data
{
    public partial class MyFlixDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), @"../MyFlix.API/appsettings.json")).Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")));
            }
        }
    }
}
