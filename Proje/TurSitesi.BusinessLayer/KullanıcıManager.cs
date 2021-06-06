using TurSitesi.DataAccessLayer;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.BusinessLayer
{
    public class KullanıcıManager : IDisposable
    {
        private UnitOfWork uow;
        public KullanıcıManager()
        {
            uow = new UnitOfWork();
        }

        public bool Login(string eposta, string parola)
        {
            return uow.KullanıcıRepo.Login(eposta, parola);
        }

        public List<Kullanıcı> Listele() //sınıfından listeleme islemi
        {
            return uow.KullanıcıRepo.GetAll().ToList();
        }

        public Kullanıcı GetKullanıcı(string eposta)
        {
            return uow.KullanıcıRepo.GetItem(eposta);
        }

        public int Ekle(Kullanıcı kullanıcı)
        {
            if (uow.KullanıcıRepo.GetItem(kullanıcı.EPosta) != null)
                throw new Exception(kullanıcı.EPosta + " EPosta adresine sahip kullanıcı zaten var");
            uow.KullanıcıRepo.Add(kullanıcı);
            return uow.Save();
        }

        public int Sil(string eposta)
        {
            uow.KullanıcıRepo.Remove(eposta);
            return uow.Save();
        }
        // bos mu diye kontrol edip ekleme islemi
        //eski eposta ile yeni aynı mı kontrolü yapıyor
        public int Guncelle(string oldEposta, Kullanıcı kullanıcı)
        {
            if (!kullanıcı.EPosta.ToLower().Equals(oldEposta.ToLower()) && uow.KullanıcıRepo.GetItem(kullanıcı.EPosta) != null)
                throw new Exception(kullanıcı.EPosta + " EPosta adresine sahip kullanıcı zaten var");

            Kullanıcı user = uow.KullanıcıRepo.GetItem(oldEposta);
            user.EPosta = kullanıcı.EPosta;
            user.Ad = kullanıcı.Ad;
            user.Soyad = kullanıcı.Soyad;
            user.Parola = kullanıcı.Parola;
            user.Yetki = kullanıcı.Yetki;

            uow.KullanıcıRepo.Update(user);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
