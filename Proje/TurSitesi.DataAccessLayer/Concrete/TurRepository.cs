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
    public class TurRepository : Repository<Tur>, ITurRepository 
    {
        public TurRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<Tur> GetAllWithKategori()
        {
            return context.Set<Tur>().Include(x => x.kategori).ToList();
        }



    }
}
