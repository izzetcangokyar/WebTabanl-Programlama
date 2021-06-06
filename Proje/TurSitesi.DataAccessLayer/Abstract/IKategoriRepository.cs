using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Abstract
{
    public interface IKategoriRepository : IRepository<Kategori> //kalıtıyoruz cünkü crud işlemlerini tekrar tekrar yapmamak icin
    {
        IEnumerable<Kategori> Ara(string aranan);
        
    }
}
