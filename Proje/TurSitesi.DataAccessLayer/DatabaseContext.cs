using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer
{
    public class DatabaseContext : DbContext
    { 
        public DbSet<Kullanıcı> Kullanıcılar { get; set; } //kullanıc  ki iliskiyi veritabanında düzenlemek icin kullanıcılar propunu tanımlıyoruz 
        //veritb. üzerinde döner, yaptıgı islem model ve verit iliskisini düzenlemek
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Tur> Turlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Zimmet> Zimmetler { get; set; }

        public DatabaseContext() : base("TurDB") //database baslatma yöntemi connection string ile baglantılı, kendi veritabanınıda direkt isim vererek kullanabilirsin.
        {
            Database.SetInitializer(new setdb()); //başlatma yöntemini yazıyoruz, asagıdaki islemi yapabilmek icin yazıyoruz
        }

        //set db adında class olusturuyorz bunuda createdatabase ile kalıtıypruz daha sonra baslatma yöntemini
        public class setdb : DropCreateDatabaseAlways<DatabaseContext>//normalde asagıdaki gibi yapıyoruz ama hata vs olu bende böyle dropladım silsin tekrar yapsın diye
        { //setdb adında class olusturuyoruz bunuda CreateDatabaseIfNotExists ile kalıtıyoruz.
            // daha sonra başlatma yöntemini ezip elimizle kayıt giriyoruz.
            protected override void Seed(DatabaseContext context)
            {
                Kullanıcı kullanıcı = context.Set<Kullanıcı>().Add(new Kullanıcı { EPosta = "admin", Parola = "1234", Yetki = Yetkiler.Yonetici, Ad = "admin", Soyad = "admin" });
                Kullanıcı kullanıcı2 = context.Set<Kullanıcı>().Add(new Kullanıcı { EPosta = "gorevli", Parola = "1234", Yetki = Yetkiler.Gorevli, Ad = "gorevli", Soyad = "gorevli" });

                Kategori kategori = context.Set<Kategori>().Add(new Kategori { Ad = "Test" });

                Calisan calisan = context.Set<Calisan>().Add(new Calisan { Ad = "Gorevli", Soyad = "Rehber" });
                
                base.Seed(context);  //seed ezme  işlemi
            }
        }
    }
}
