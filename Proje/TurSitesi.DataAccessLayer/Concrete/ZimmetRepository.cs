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
    public class ZimmetRepository : Repository<Zimmet>, IZimmetRepository
    {
        public ZimmetRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Zimmet> GetAllWithZimmet()
        {
            return context.Set<Zimmet>().Include(x => x.Tur).Include(y => y.Calisan).ToList();
        }


     

    }
}
