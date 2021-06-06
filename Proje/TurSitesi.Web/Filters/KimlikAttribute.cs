using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace TurSitesi.Web.Filters
{
    public class KimlikAttribute : FilterAttribute, IAuthenticationFilter //IAuthorizationFilter: yetkilendirme filtresi icin yöntemleri filtreler
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {  //OnAuthentication: Bu metot, isteğin kimliğini doğrulamak için kullanılır. Parametre olarak
           //gelen AuthenticationContext nesnesi kimlik doğrulama kararı vermek için gerekli bilgileri
           //sağlar.
            if (filterContext.HttpContext.Session["user"] != null)
            { //user oturumu geliyor , gelen otrum bos degilse kullabıcı tipinde usera aktarıyor, user bos degilse döndürüyor
                Kullanıcı user = filterContext.HttpContext.Session["user"] as Kullanıcı; //"as" kullancı tipine cevirmek icin 
                if (user != null)
                {
                    return;
                }
            }
            //amac session bos mu dolu mu diye falan icin bakıyoruz
            filterContext.Result = new HttpUnauthorizedResult();
        }
        //OnAuthenticationChallenge : Bu metot, kimlik doğrulama başarısız ise veya kimlik
        //   doğrulama başarılı ise istek gönderilen action metot çalıştıktan çalışır
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result != null && filterContext.Result is HttpUnauthorizedResult)
            {//result: geri dönüs değeri calsmadan önce yda sonra calısan
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    { //basarısızsa logine yönleniyo
                   
                        {"controller", "Kullanici" },
                        {"action", "Login" }
                    }
                    );
            }
        }
    }
}