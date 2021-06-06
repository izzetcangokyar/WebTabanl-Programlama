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
    public class KullaniciController : Controller
    {
        
        public ActionResult Login()
        {
            if (Session["user"] == null)
                return View();
            else
            {
                return RedirectToAction("Listele", "Kullanici");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        
        public ActionResult Login(Kullanıcı kullanıcı)  
        {
            if (kullanıcı != null)
                using (KullanıcıManager manager = new KullanıcıManager())
                    if (manager.Login(kullanıcı.EPosta, kullanıcı.Parola))
                    {
                        Kullanıcı user = manager.GetKullanıcı(kullanıcı.EPosta);
                        Session["user"] = user;
                        return RedirectToAction("Listele", "Zimmet");
                    }
            ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!!!");
            return View(kullanıcı);
        }
      
        public ActionResult Logout()
        {
            if (Session["user"] != null)
                Session.Remove("user");
            return RedirectToAction("Login");
        }

        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Listele()
        {
            using (KullanıcıManager manager = new KullanıcıManager())
                return View(manager.Listele());
        }

        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Ekle(Kullanıcı kullanıcı)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (KullanıcıManager manager = new KullanıcıManager())
                    {
                        if (manager.Ekle(kullanıcı) > 0)
                            return RedirectToAction("Listele");
                    }
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);

            }
            return View(kullanıcı);
        }

        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(string eposta)
        {
            using (KullanıcıManager manager = new KullanıcıManager())
            {
                Kullanıcı user = manager.GetKullanıcı(eposta);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(string eposta, Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                using (KullanıcıManager manager = new KullanıcıManager())
                    if (manager.Guncelle(eposta, kullanıcı) > 0)
                        return RedirectToAction("Listele");
            }
            return View(kullanıcı);
        }

        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Sil(string eposta)
        {
            using (KullanıcıManager manager = new KullanıcıManager())
            {
                Kullanıcı user = manager.GetKullanıcı(eposta);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        [Kimlik, Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult SilOnay(string eposta, Kullanıcı kullanıcı) 
        {
            using (KullanıcıManager manager = new KullanıcıManager())
            {
                if (manager.Sil(kullanıcı.EPosta) > 0)
                    return RedirectToAction("Listele");
                else
                    ModelState.AddModelError("", "Silme yapılamadı...");

            }
            return View(kullanıcı);
        }
    }
}