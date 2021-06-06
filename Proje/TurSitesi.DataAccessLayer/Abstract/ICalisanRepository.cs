using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Abstract
{
    public interface ICalisanRepository : IRepository<Calisan>
    {
        IEnumerable<Calisan> Ara(string aranan);
        IEnumerable<Calisan> GetAllWithZimmet();
        Calisan GetAllWithZimmet(object key);
    }
 
}
