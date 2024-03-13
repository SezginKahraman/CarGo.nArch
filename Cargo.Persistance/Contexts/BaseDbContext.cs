﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarGo.Domain.Entities;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarGo.Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Fuel> Fuels { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Transmission> Transmision { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration): base(dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated(); // in first migration, close this line for running.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
