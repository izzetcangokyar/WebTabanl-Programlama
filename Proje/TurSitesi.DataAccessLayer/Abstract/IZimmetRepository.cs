using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Abstract
{
    public interface IZimmetRepository : IRepository<Zimmet>
    {

        IEnumerable<Zimmet> GetAllWithZimmet();
    }
}
