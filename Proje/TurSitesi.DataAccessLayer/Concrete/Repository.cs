using TurSitesi.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Concrete
{ // Repository sınıfının yapıcısında gelen context'i protected tanımladığımız context'e aktarıyoruz.
    public class Repository<T> : IRepository<T> where T : class
    {  // olusturdugumuz interface'i sınıfımıza kalıtıyoruz interface'in özelliklerini kullanıyoz
        protected DbContext context;

        public Repository(DbContext context) //sınıfın yapıcısında gelen contexti sınıftaki contexte eşitliyoruz
        {
            this.context = context;
        }

        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }
        // veritabına bu item'ı ekliyoruz ve eklediğimiz tipe göre bir sql sorgusu çalışıyor.
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetItem(object key)
        {
            return context.Set<T>().Find(key); // gelen "key" i veritabında aratıp. geriye bu bilgiyi dönüyoruz.
        }

        public void Remove(T item)
        {//itema atak yoksa (entity izlemiyorsa)
            if (context.Entry<T>(item).State == EntityState.Detached)
                context.Set<T>().Attach(item); //itema atak yap
            context.Entry<T>(item).State = EntityState.Deleted; //itemi guncelle
        }

        public void Remove(object key) // Entity durumu "Detached" ise yani entity bir context tarafından izlenmiyor ise
                                       // veri tabanına atak yapıp bu veriyi gönderiyoruz
        {
            context.Set<T>().Remove(GetItem(key));
        }

        public void Update(T item)
        {
            if (context.Entry<T>(item).State == EntityState.Detached)
                context.Set<T>().Attach(item);
            context.Entry<T>(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);  //İSLEM SONLANIR BELLEK BOŞALTILIR
        }
    }
}
