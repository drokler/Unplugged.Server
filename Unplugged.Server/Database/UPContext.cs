using System;
using Microsoft.EntityFrameworkCore;
using UnpluggedModel;

namespace Unplugged.Server.Database
{
    public class UPContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Presentation> Presentations { get; set; }

        public DbSet<UserRegistration> Registrations { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public UPContext(DbContextOptions<UPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(b =>
            {
                b.Property(t => t.Login).IsRequired();
                b.Property(t => t.Password).IsRequired();
                b.Property(t => t.Id).ValueGeneratedOnAdd();
                b.HasData(new User
                {
                    Fio = "Admin",
                    Login = "Admin",
                    Password = "QWEqwe123",
                    Role = UserRole.Admin,
                    ConnectInfo = "",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString(),
                });
            });

            
        }
    }
}