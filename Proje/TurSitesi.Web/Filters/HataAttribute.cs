using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurSitesi.Web.Filters
{
    public class HataAttribute : FilterAttribute, IExceptionFilter
    { //result: geri dönüs değeri calsmadan önce yda sonra calısan
        public void OnException(ExceptionContext filterContext)//exeption hata olusunca calısacak filtre
        { //onexepception : Controller’ımızın içindeki kod çalışmaya başlamadan önce browser kontrolünü yapacağımız için OnActionExecuting olayına kodumuzu ekleyeceğiz
            filterContext.Result = new ViewResult //yenı bır viewresult olusturup fıltercontexte eşitliyoruz
            {
                ViewName = "Hata",// olusturdugumuz vıewresultın vıewname ini hata olarak belırlıyoruz
                ViewData = new ViewDataDictionary(filterContext.Exception)//vıewdatadıctıonary nesnesı olusturup ıcıne exceptıon yollayıp vıewdataya eşitliyoruz
            };
            filterContext.ExceptionHandled = true;
        }
    }
}