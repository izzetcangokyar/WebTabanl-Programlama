using TurSitesi.DataAccessLayer;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.BusinessLayer
{
    public class TurManager : IDisposable
    {
        private UnitOfWork work;
        public TurManager()
        {
            work = new UnitOfWork();
        }

        public List<Tur> Listele() 
        {
            return work.TurRepo.GetAllWithKategori().ToList();
        }

        public Tur GetTur(int id)
        {
            return work.TurRepo.GetItem(id);
        }

        public int Ekle(Tur tur)
        {

            work.TurRepo.Add(tur);
            return work.Save();
        }

        public int Sil(int id)
        {
            work.TurRepo.Remove(id);
            return work.Save();

        }
        public void Sil(Tur tur)
        {
            work.TurRepo.Remove(tur);
            work.Save();
        }

        public int Guncelle(Tur tur)
        {

            work.TurRepo.Update(tur);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
