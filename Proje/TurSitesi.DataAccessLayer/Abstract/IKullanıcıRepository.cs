using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurSitesi.DataAccessLayer.Abstract
{
  public interface IKullanıcıRepository : IRepository<Kullanıcı>
    { //giriş kontrolü yapabilmek icin kullandıgımız interface

        bool Login(string eposta, string parola);
    }
}
