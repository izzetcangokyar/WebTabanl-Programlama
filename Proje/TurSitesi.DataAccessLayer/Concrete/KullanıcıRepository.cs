using TurSitesi.DataAccessLayer.Abstract;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Concrete
{
    public class KullanıcıRepository : Repository<Kullanıcı>, IKullanıcıRepository
    {
        public KullanıcıRepository(DbContext context) : base(context)
        {
        }

        public bool Login(string eposta, string parola)
        {

            return (context.Set<Kullanıcı>().FirstOrDefault(x => x.EPosta.ToLower().Equals(eposta.ToLower()) && x.Parola.Equals(parola)) != null);
           
        }
    }
}
