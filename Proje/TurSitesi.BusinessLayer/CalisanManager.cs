using TurSitesi.DataAccessLayer;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.BusinessLayer
{
    public class CalisanManager : IDisposable
    {
        private UnitOfWork uow;
        public CalisanManager()
        {
            uow = new UnitOfWork();
        }

        public List<Calisan> Listele()
        {
            return uow.CalisanRepo.GetAll().ToList();
        }

        public List<Calisan> Ara(string aranan)
        {
            return uow.CalisanRepo.Ara(aranan).ToList();
        }

        public Calisan GetCalisan(int id)
        {
            return uow.CalisanRepo.GetItem(id);
        }

        public int Sil(int id)
        {
            uow.CalisanRepo.Remove(id);
            return uow.Save();
        }

        public int Ekle(Calisan calisan)
        {
            uow.CalisanRepo.Add(calisan);
            return uow.Save();
        }

        public int Guncelle(Calisan calisan)
        {
            uow.CalisanRepo.Update(calisan);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
