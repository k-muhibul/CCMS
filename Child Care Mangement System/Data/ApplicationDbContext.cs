using Child_Care_Mangement_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Child_Care_Mangement_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

        public DbSet<Bill> Bills { get; set; }
        public DbSet<CareCategory> CareCategories { get; set; }
        public DbSet<CarerClockHistory> CarerClockHistories { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<ChildClockHistory> ChildClockHistories { get; set; }
        public DbSet<ChildHealthLog> ChildHealthLogs { get; set; }
        public DbSet<ChildMealLog> ChildMealLogs { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<EatWellCategory> EatWellCategories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<SetAvilability> SetAvilabilities { get; set; }
        public DbSet<Shift> Shifts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().Property(p => p.ConcurrencyStamp).HasColumnType("TEXT");
            modelBuilder.Entity<Bill>()
       .HasOne(bill => bill.PaymentHistory)
       .WithOne(paymentHistory => paymentHistory.Bill) 
       .HasForeignKey<PaymentHistory>(ph => ph.BillId);

            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            var roles = new List<Role>
        {
            new Role { Id = 1, Name = "Parent", NormalizedName = "PARENT" },
            new Role { Id = 2, Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Id = 3, Name = "Supervisor", NormalizedName = "SUPERVISOR" },
            new Role { Id = 4, Name = "Carer", NormalizedName = "CARER" }
        };

            modelBuilder.Entity<Role>().HasData(roles);
        }


        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            var adminUser = new User
            {
                Id = 1,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
               

            };

            var carerUser = new User
            {
                Id = 2,
                UserName = "carer@example.com",
                NormalizedUserName = "CARER@EXAMPLE.COM",
                Email = "carer@example.com",
                NormalizedEmail = "CARER@EXAMPLE.COM",
                EmailConfirmed = true,
               
            };

            var supervisorUser = new User
            {
                Id = 3,
                UserName = "supervisor@example.com",
                NormalizedUserName = "SUPERVISOR@EXAMPLE.COM",
                Email = "supervisor@example.com",
                NormalizedEmail = "SUPERVISOR@EXAMPLE.COM",
                EmailConfirmed = true,
                
            };

          
            adminUser.PasswordHash = hasher.HashPassword(null, "admin1234.");
            carerUser.PasswordHash = hasher.HashPassword(null, "carer1234.");
            supervisorUser.PasswordHash = hasher.HashPassword(null, "supervisor1234.");

           
            modelBuilder.Entity<User>().HasData(adminUser, carerUser, supervisorUser);

         
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new List<IdentityUserRole<int>>
    {
        new IdentityUserRole<int> { UserId = 1, RoleId = 2 }, 
        new IdentityUserRole<int> { UserId = 2, RoleId = 4 },
        new IdentityUserRole<int> { UserId = 3, RoleId = 3 }
    });
        }

    }
}
