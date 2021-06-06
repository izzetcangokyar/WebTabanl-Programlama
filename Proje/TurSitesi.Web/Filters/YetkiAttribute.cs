using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurSitesi.Web.Filters
{
    public class YetkiAttribute : FilterAttribute, IAuthorizationFilter//author.. yetkilendirme filtresi,
    {
        //OnAuthentication: Bu metot, isteğin kimliğini doğrulamak için kullanılır. Parametre olarak
        //gelen AuthenticationContext nesnesi kimlik doğrulama kararı vermek için gerekli bilgileri
        //sağlar.
        public Yetkiler Rol { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] != null)
            {
                Kullanıcı user = filterContext.HttpContext.Session["user"] as Kullanıcı;
                if (user != null)
                {
                    if (user.Yetki == Rol)
                    {
                        return;
                    }
                }
            }
            filterContext.Result = new ViewResult()
            {
                ViewName = "YetkisizErisim"
            };
        }
    }
}