using Microsoft.EntityFrameworkCore;
using Weapons.Models;
namespace MyDB.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
        {
        }
        public DbSet<Адреса_регистрации> Адреса_регистрации { get; set; }
        public DbSet<Города> Города { get; set; }
        public DbSet<Граждане> Граждане { get; set; }
        public DbSet<Запросы_в_ГУ_МВД> Запросы_в_ГУ_МВД { get; set; }
        public DbSet<Заявления> Заявления { get; set; }
        public DbSet<Лицензии_на_приобретение_оружия> Лицензии_на_приобретение_оружия { get; set; }
        public DbSet<Лицензии_на_хранение_оружия> Лицензии_на_хранение_оружия { get; set; }
        public DbSet<Медицинские_заключения> Медицинские_заключения { get; set; }
        public DbSet<Медицинские_организации> Медицинские_организации { get; set; }
        public DbSet<Места_хранения_оружия> Места_хранения_оружия { get; set; }
        public DbSet<Модели> Модели { get; set; }
        public DbSet<Оружие> Оружие { get; set; }
        public DbSet<Отчёты_о_правонарушениях> Отчёты_о_правонарушениях { get; set; }
        public DbSet<Производители> Производители { get; set; }
        public DbSet<Протоколы_контрольного_отстрела> Протоколы_контрольного_отстрела { get; set; }

    }
}