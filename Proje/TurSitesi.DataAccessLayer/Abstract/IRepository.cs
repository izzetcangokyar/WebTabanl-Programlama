using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Abstract
{
    public interface IRepository<T> : IDisposable where T : class // where t gelen tip her seferinde class olmak zorunda
    { // GetItem'ın başındaki T ise oraya "int,string,object" veri türlerinden birinin gelebilecek olmasıdır.
      // Bu sayade bir modelden item çekiyorsak bunun int mi ya da string mi olduğunu tanımladığımız generic metod tanır.
        IEnumerable<T> GetAll(); //listeleme,  t demesinin sebebi ise jenerik olmasıdır
        T GetItem(object key);
        void Add(T item);
        void Remove(T item);
        void Remove(object key);
        void Update(T item);
    }
}
