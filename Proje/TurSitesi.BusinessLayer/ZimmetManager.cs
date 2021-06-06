using TurSitesi.DataAccessLayer;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.BusinessLayer
{

    public class ZimmetManager : IDisposable
    {
        private readonly UnitOfWork uow;
        public ZimmetManager()
        {
            uow = new UnitOfWork();
        }

        public List<Zimmet> Listele()
        {

            return uow.ZimmetRepo.GetAllWithZimmet().ToList();
        }

       

        public Zimmet GetZimmet(int id)
        {
            return uow.ZimmetRepo.GetItem(id);
        }

      
        public int Ekle(Zimmet zimmet)
        {
            uow.ZimmetRepo.Add(zimmet);
            Tur tur = uow.TurRepo.GetItem(zimmet.TurId);
            tur.DoluMu = true;
            uow.TurRepo.Update(zimmet.Tur);
                return uow.Save();
        }

        public int Guncelle(Zimmet zimmet)
        {
            using(UnitOfWork uow1 = new UnitOfWork())
                    {
                Zimmet old_zimmet = uow1.ZimmetRepo.GetItem(zimmet.Id);
                if(zimmet.TurId != old_zimmet.TurId)
                {
                    Tur turEski = uow1.TurRepo.GetItem(old_zimmet.TurId);
                    turEski.DoluMu = false;
                    uow1.TurRepo.Update(turEski);

                    Tur tur = uow1.TurRepo.GetItem(zimmet.TurId);
                       tur.DoluMu = true;
                    uow1.TurRepo.Update(tur);
                    uow1.Save();

                }
            }

            uow.ZimmetRepo.Update(zimmet);
            return uow.Save();
        }
        public int Sil(int id)
        {
            Zimmet zimmet = uow.ZimmetRepo.GetItem(id);
            Tur tur = uow.TurRepo.GetItem(zimmet.TurId);
            tur.DoluMu = false;
            uow.TurRepo.Update(tur);

            uow.ZimmetRepo.Remove(id);
            return uow.Save();
        }
        public int Sil(Zimmet zimmet)
        {
            return Sil(zimmet.Id);
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
