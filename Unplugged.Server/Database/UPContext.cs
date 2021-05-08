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
                    ConnectInfo = "contact info",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString(),
                    
                });
                b.HasData(new User
                {
                    Fio = "Moderator",
                    Login = "Moderator",
                    Password = "QWEqwe123",
                    Role = UserRole.Moderator,
                    ConnectInfo = "contact info",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1).ToString(),
                });
                b.HasData(new User
                {
                    Fio = "Трембрвецкий Николай",
                    Login = "koperniki",
                    Password = "org100h",
                    Role = UserRole.Common,
                    ConnectInfo = "https://vk.com/mypag",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2).ToString(),
                });
                b.HasData(new User
                {
                    Fio = "Куркутов Павел",
                    Login = "kpavel",
                    Password = "QWEqwe123",
                    Role = UserRole.Common,
                    ConnectInfo = "contact info",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3).ToString(),
                });
                b.HasData(new User
                {
                    Fio = "Адаричев Вадим",
                    Login = "avadik",
                    Password = "QWEqwe123",
                    Role = UserRole.Common,
                    ConnectInfo = "contact info",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4).ToString(),
                });
                b.HasData(new User
                {
                    Fio = "Библенко Артем",
                    Login = "bartem",
                    Password = "QWEqwe123",
                    Role = UserRole.Common,
                    ConnectInfo = "contact info",
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5).ToString(),
                });
            });

            modelBuilder.Entity<Presentation>(b =>
            {
                b.Property(t => t.UserId).IsRequired();
                b.Property(t => t.EventId).HasConversion(t => string.IsNullOrEmpty(t) ? null : t, t => t);
                b.Property(t => t.Name).IsRequired();
                b.Property(t => t.Id).ValueGeneratedOnAdd();
                b.Ignore(t => t.EventId);
                b.Property(t => t._EventId).HasColumnName(nameof(Presentation.EventId));
                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2).ToString(),
                    Name = "Как я на флатере писал",
                    Description = "Плюсы и минусы программирования на flutter",
                    AdditionalFileUrls = "tap-fileserver/d1",
                    Duration = 25,
                });

                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2).ToString(),
                    Name = "Как я покончил с флатером",
                    Description = "Минусов оказалось больше",
                    AdditionalFileUrls = "tap-fileserver/d2",
                    Duration = 35,
                });


                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3).ToString(),
                    Name = "Рогалики и сурки",
                    Description = "Пишем свою rougelike рпг. Как не попасть в петлю.",
                    AdditionalFileUrls = "tap-fileserver/d3",
                    Duration = 30,
                });

                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3).ToString(),
                    Name = "Каждый может быть манагером",
                    Description = "Или про то как я писал свою аркаду.",
                    AdditionalFileUrls = "tap-fileserver/d4",
                    Duration = 20,
                });

                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4).ToString(),
                    Name = "Давим змею",
                    Description = "Что лучше python или .net core",
                    AdditionalFileUrls = "tap-fileserver/d5",
                    Duration = 25,
                });

                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4).ToString(),
                    Name = "Щель в земле",
                    Description = "Реестр карьеров и возникшие там проблемы",
                    AdditionalFileUrls = "tap-fileserver/d6",
                    Duration = 40,
                });

                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5).ToString(),
                    Name = "Темно как в жо...",
                    Description = "Или почему в Маяке все не очень",
                    AdditionalFileUrls = "tap-fileserver/d7",
                    Duration = 25,

                });

                b.HasData(new Presentation
                {
                    Id = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5).ToString(),
                    UserId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5).ToString(),
                    Name = "Рандомный доклад",
                    Description = "лень было думать",
                    AdditionalFileUrls = "tap-fileserver/d8",
                    Duration = 35,
                });

            });


        }
    }
}