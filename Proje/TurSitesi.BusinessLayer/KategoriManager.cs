using TurSitesi.DataAccessLayer;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.BusinessLayer
{
    public class KategoriManager : IDisposable
    {
        private UnitOfWork uow;
        public KategoriManager()
        {
            uow = new UnitOfWork();
        }

        public List<Kategori> Listele()
        {
            return uow.kategoriRepo.GetAll().ToList();
        }

        public List<Kategori> Ara(string kategori)
        {
            return uow.kategoriRepo.Ara(kategori).ToList();
        }

        public Kategori GetKategori(int id)
        {
            return uow.kategoriRepo.GetItem(id);
        }

        public int Sil(int id)
        {
            uow.kategoriRepo.Remove(id);
            return uow.Save();
        }

        public int Ekle(Kategori kategori)
        {
            uow.kategoriRepo.Add(kategori);
            return uow.Save();
        }

        public int Guncelle(Kategori kategori)
        {
            uow.kategoriRepo.Update(kategori);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
