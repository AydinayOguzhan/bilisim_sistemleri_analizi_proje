using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bilisim_sistemleri_proje;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Server=.;Database=bilisim_sistemleri_proje;Trusted_Connection=true");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Day> Days { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<ReadyToUseDiet> ReadyToUseDiets { get; set; }
        public DbSet<ReadyToUseDietFood> ReadyToUseDietFoods { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserDiet> UserDiets { get; set; }
        public DbSet<UserMove> UserMoves { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutPlanMove> WorkoutPlanMoves { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserOperationClaim>(a =>
        //    {
        //        a.ToTable("UserOperationClaims").HasKey(k => k.Id);
        //        a.Property(k => k.OperationClaimId).HasColumnName("OperationClaimId");
        //        a.Property(k => k.UserId).HasColumnName("UserId");

        //        a.HasOne(k=>k.User);
        //    });

        //    modelBuilder.Entity<User>(a =>
        //    {
        //        a.ToTable("Users").HasKey(k => k.Id);
                
        //        a.HasMany(k => k.UserOperationClaim);
        //    });
        //}

    }
}
