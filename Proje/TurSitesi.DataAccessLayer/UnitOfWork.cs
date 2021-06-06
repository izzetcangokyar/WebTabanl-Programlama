using TurSitesi.DataAccessLayer.Concrete;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    { //ıdisposbledan kalıtılmıştır, bellek yönetimi yapabilmek icin
        private DatabaseContext context;

        private KullanıcıRepository kullanıcı_repo;
        private CalisanRepository calisan_repo;
        private ZimmetRepository zimmet_repo;
        private KategoriRepository kategori_repo;
        private TurRepository tur_repo;
        public KullanıcıRepository KullanıcıRepo
        {
            get //sarmallama işlemi 
            {
                if (kullanıcı_repo == null)
                    kullanıcı_repo = new KullanıcıRepository(context);
                return kullanıcı_repo;
            }
        }

        public CalisanRepository CalisanRepo
        {
            get
            {
                if (calisan_repo == null)
                    calisan_repo = new CalisanRepository(context);
                return calisan_repo;
            }
        }
        public TurRepository TurRepo
        {
            get
            {
                if (tur_repo == null)
                    tur_repo = new TurRepository(context);
                return tur_repo;
            }
        }
        public KategoriRepository kategoriRepo
        {
            get
            {
                if (kategori_repo == null)
                    kategori_repo = new KategoriRepository(context);
                return kategori_repo;
            }
        }

        public ZimmetRepository ZimmetRepo
        {
            get
            {
                if (zimmet_repo == null)
                    zimmet_repo = new ZimmetRepository(context);
                return zimmet_repo;
            }
        }

        public UnitOfWork()
        {
            context = new DatabaseContext();
        }

        public int Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int adet = context.SaveChanges();
                    transaction.Commit();
                    return adet;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            kullanıcı_repo?.Dispose();
            calisan_repo?.Dispose();
            zimmet_repo?.Dispose();
            kategori_repo?.Dispose();
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
