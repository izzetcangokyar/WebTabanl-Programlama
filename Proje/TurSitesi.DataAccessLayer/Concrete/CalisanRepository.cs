using TurSitesi.DataAccessLayer.Abstract;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Concrete
{
    public class CalisanRepository : Repository<Calisan>, ICalisanRepository
    { //Her seferinde hem kendi interfaceini ve ana repository sınıfını kalıtım yaparız
        public CalisanRepository(DbContext context) : base(context) //yapıcısında base'e context yollar
        //base yollamazsak hata veriyor yollaman gerekiyor diye
        {
        }

        public IEnumerable<Calisan> Ara(string aranan)
        {
            return context.Set<Calisan>().Where(x =>
            x.Ad.ToLower().Contains(aranan.ToLower()) ||
            x.Soyad.ToLower().Contains(aranan.ToLower()) ||
             x.AdSoyad.ToLower().Contains(aranan.ToLower()));
        }  //tolower kücük harf 
           //equals eşit mi kontrolü yapar
           //firstord.. değer türünün varsayılan değerini döndürür aratır 

        public IEnumerable<Calisan> GetAllWithZimmet()
        {
            return context.Set<Calisan>().ToList();
        }

        public Calisan GetAllWithZimmet(object key)
        {
            return context.Set<Calisan>().FirstOrDefault(x => x.Id == (int)key);
        }
    }
}
