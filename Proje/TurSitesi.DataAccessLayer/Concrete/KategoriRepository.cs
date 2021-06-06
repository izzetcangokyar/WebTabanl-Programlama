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
    public class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        public KategoriRepository(DbContext context) : base(context)  // yapıcısında base e contextı yolluyoruz
        {
        }

        public IEnumerable<Kategori> Ara(string aranan)   //tolower kücük harf 
                                                        
                                                         
        {
            return context.Set<Kategori>().Where(x =>
            x.Ad.ToLower().Contains(aranan.ToLower()) ||
           
             x.Ad.ToLower().Contains(aranan.ToLower()));
        }

        public IEnumerable<Kategori> GetAllWithKategori()
        {
            return context.Set<Kategori>().ToList();
        }
        //  gelen ıd  ıdsıne esıt mı kontrol edıyoruz esıt olanları getırıyoruz 
        public Kategori GetAllWithKategori(object key)
        {
            return context.Set<Kategori>().FirstOrDefault(x => x.Id == (int)key);
        } 
    }
}
