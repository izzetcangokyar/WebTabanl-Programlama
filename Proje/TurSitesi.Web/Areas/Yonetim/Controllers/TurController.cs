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
    public class TurController : Controller
    {
        // GET: Yonetim/Calisan
        public ActionResult Index()
        {
            return View();
        } 
        [Yetki(Rol = Yetkiler.Yonetici)] //yetkileri cagırıyoruz yonetici rolunde olanlar bu katmana erisebilir
        public ActionResult Listele()
        {
            using (TurManager manager = new TurManager())
                return View(manager.Listele());
        }
        [Yetki(Rol = Yetkiler.Yonetici)]

        public ActionResult Ekle()
        {
            using (KategoriManager manager = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(manager.Listele(), "Id", "Ad");
            return View();
        }
       

        [HttpPost, ValidateAntiForgeryToken] //yetkileri cagırıyoruz yonetici rolunde olanlar bu katmana erisebilir
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Ekle(Tur tur)
        {
            try
            {
                if (ModelState.IsValid) // model gecerliyse (kosullar 4karakter vs) ifin icine giriyo,
                                        //her columa bossa yazamayız onun icin isvalid kullanıyoruz
                {
                    using (TurManager manager = new TurManager())
                    {
                        if (manager.Ekle(tur) > 0)
                            return RedirectToAction("Listele");
                    }
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);

            }

            using (KategoriManager manager = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(manager.Listele(), "Id", "Ad");
            
            return View(tur);
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(int id)
        {

            if (id != null)
            {
                using (TurManager manager = new TurManager())
                {
                    Tur tur = manager.GetTur((int)id);
                    if (tur != null)
                    {
                        using (KategoriManager managerKategori = new KategoriManager())
                            ViewBag.Kategoriler = new SelectList(managerKategori.Listele(), "Id", "Ad");
                        return View(tur);
                    }
                }
            }

          
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Guncelle(Tur tur)
        {
            if (ModelState.IsValid)
            {
                using (TurManager manager = new TurManager())
                    if (manager.Guncelle(tur) > 0)
                        return RedirectToAction("Listele");
            }

            using (KategoriManager managerKategori = new KategoriManager())
                ViewBag.Kategoriler = new SelectList(managerKategori.Listele(), "Id", "Ad");
            
            return View(tur);
        }

        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult Sil(int id)
        {
            using (TurManager manager = new TurManager())
            {
                Tur user = manager.GetTur(id);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        [Yetki(Rol = Yetkiler.Yonetici)]
        public ActionResult SilOnay(Tur tur)
        {
            using (TurManager manager = new TurManager())
            {
                if (manager.Sil(tur.Id) > 0)
                    return RedirectToAction("Listele");
                else
                    ModelState.AddModelError("", "Silme yapılamadı...");

            }
            return View();
        }
    }

}