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
    public class KategoriController : Controller
    {
        // GET: Yonetim/Calisan
        public ActionResult Index()
        {
            return View();
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Listele()
        {
            using (KategoriManager manager = new KategoriManager())
                return View(manager.Listele());
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Ekle(Kategori kategori)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (KategoriManager manager = new KategoriManager())
                    {
                        if (manager.Ekle(kategori) > 0)
                            return RedirectToAction("Listele");
                    }
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);

            }
            return View(kategori);
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(int id)
        {
            using (KategoriManager manager = new KategoriManager())
            {
                Kategori user = manager.GetKategori(id);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                using (KategoriManager manager = new KategoriManager())
                    if (manager.Guncelle(kategori) > 0)
                        return RedirectToAction("Listele"); // RedirectToAction : o ekşına ACTION git
            }
            return View(kategori);
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Sil(int id) 
        {
            using (KategoriManager manager = new KategoriManager())
            {
                Kategori user = manager.GetKategori(id);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult SilOnay(Kategori kategori)
        {
            using (KategoriManager manager = new KategoriManager())
            {
                if (manager.Sil(kategori.Id) > 0)
                    return RedirectToAction("Listele");
                else
                    ModelState.AddModelError("", "Silme yapılamadı...");

            }
            return View();
        }
    }
}