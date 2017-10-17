using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SinerjiOdev.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Rol> Roller { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>()
                .HasOne(p => p.Kullanıcı)
                .WithMany(b => b.Roles)
                .HasForeignKey(p => p.KullanıcıId)
                .HasConstraintName("ForeignKey_Rol_Kullanıcı");
        }


    }


    [Table("Users")]
    public class Kullanıcı
    {

        public int KullanıcıId { get; set; }
        public string KullaniciAdi { get; set; }

        public string Adi { get; set; }

        public string SoyAdi { get; set; }

        public string Sifre { get; set; }

        public List<Rol> Roles { get; set; }
    }

    public class Rol {

        public int RolID { get; set; }

        public string RolAd { get; set; }


        public int KullanıcıId { get; set; }

        public Kullanıcı Kullanıcı { get; set; }
    }

}
