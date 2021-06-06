using TurSitesi.BusinessLayer;
using TurSitesi.EntityLayer;
using TurSitesi.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurSitesi.Web.Areas.Yonetim.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Yonetim/Calisan
        [Yetki(Rol = Yetkiler.Yonetici)] //yetkileri cagırıyoruz yonetici rolunde olanlar bu katmana erisebilir
        public ActionResult Index()
        {
            return View();
        }
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Listele()
        {
            using (CalisanManager manager = new CalisanManager())
                return View(manager.Listele()); 
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]  // saldırılara karşı sen misin diye kontrol etmek için
        [Yetki(Rol = Yetkiler.Yonetici)] 
        public ActionResult Ekle(Calisan calisan)
        {
            try
            {
                if (ModelState.IsValid) // model gecerliyse (kosullar 4karakter vs) ifin icine giriyo,
                                        //her columa bossa yazamayız onun icin isvalid kullanıyoruz
                {
                    using (CalisanManager manager = new CalisanManager())
                    {
                        if (manager.Ekle(calisan) > 0)
                            return RedirectToAction("Listele");
                    }
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);

            }
            return View(calisan);
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(int id)
        {
            using (CalisanManager manager = new CalisanManager())
            {
                Calisan user = manager.GetCalisan(id);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                using (CalisanManager manager = new CalisanManager())
                    if (manager.Guncelle(calisan) > 0)
                        return RedirectToAction("Listele");
            }
            return View(calisan);
        }

        [Yetki(Rol = Yetkiler.Yonetici)]

        public ActionResult Sil(int id) 
        {
            using (CalisanManager manager = new CalisanManager())
            {
                Calisan user = manager.GetCalisan(id);
                if (user != null) // bos degilse user gidiyor o da degilse hataya düsüyor listeleye gidiy
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
       
        public ActionResult SilOnay(Calisan calisan)
        {
            using (CalisanManager manager = new CalisanManager())
            {
                if (manager.Sil(calisan.Id) > 0)
                    return RedirectToAction("Listele");
                else
                    ModelState.AddModelError("", "Silme yapılamadı...");

            }
            return View(calisan);
        }
    }
}