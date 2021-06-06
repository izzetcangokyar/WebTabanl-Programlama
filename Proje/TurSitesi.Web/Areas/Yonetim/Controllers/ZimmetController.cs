using TurSitesi.BusinessLayer;
using TurSitesi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurSitesi.Web.Areas.Yonetim.Controllers
{
    public class ZimmetController : Controller
    {
        // GET: Yonetim/Calisan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listele()
        {
            using (ZimmetManager manager = new ZimmetManager())
                return View(manager.Listele());
        }


        public ActionResult Ekle()
        {

            using (CalisanManager manager = new CalisanManager())
                ViewBag.Calisanlar = new SelectList(manager.Listele(), "Id", "Ad","Soyad");


            using (TurManager manager2 = new TurManager())
                ViewBag.Turlar = new SelectList(manager2.Listele(), "Id", "Ad");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult Ekle(Zimmet zimmet)
        {
            try
            {
                if (ModelState.IsValid) // model gecerliyse (kosullar 4karakter vs) ifin icine giriyo,
                                        //her columa bossa yazamayız onun icin isvalid kullanıyoruz
                {
                    using (ZimmetManager manager = new ZimmetManager())
                    {
                        if (manager.Ekle(zimmet) > 0)
                            return RedirectToAction("Listele");
                    }
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);

            }
            using (CalisanManager manager = new CalisanManager())
                ViewBag.Calisanlar = new SelectList(manager.Listele(), "Id", "Ad", "Soyad");


            using (TurManager manager2 = new TurManager())
                ViewBag.Turlar = new SelectList(manager2.Listele(), "Id", "Ad");
            return View(zimmet);
        }


        public ActionResult Guncelle(int id)
        {
            using (ZimmetManager manager = new ZimmetManager())
            {
                Zimmet zimmet = manager.GetZimmet(id);
                if (zimmet != null)
                {
                    using (CalisanManager manager2 = new CalisanManager())
                        ViewBag.Calisanlar = new SelectList(manager2.Listele(), "Id", "Ad", "Soyad");


                    using (TurManager manager3 = new TurManager())
                        ViewBag.Turlar = new SelectList(manager3.Listele(), "Id", "Ad");
                    return View(zimmet);

                }

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult Guncelle(Zimmet zimmet)
        {
            if (ModelState.IsValid)
            {
                using (ZimmetManager manager = new ZimmetManager())
                    if (manager.Guncelle(zimmet) > 0)
                        return RedirectToAction("Listele");
            }
            using (CalisanManager manager2 = new CalisanManager())
                ViewBag.Calisanlar = new SelectList(manager2.Listele(), "Id", "Ad", "Soyad");


            using (TurManager manager3 = new TurManager())
                ViewBag.Turlar = new SelectList(manager3.Listele(), "Id", "Ad");
            return View(zimmet);
        }


        public ActionResult Sil(int id)
        {
            using (ZimmetManager manager = new ZimmetManager())
            {
                Zimmet user = manager.GetZimmet(id);
                if (user != null)
                    return View(user);

            }
            return RedirectToAction("Listele");
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]

        public ActionResult SilOnay(Zimmet zimmet)
        {
            using (ZimmetManager manager = new ZimmetManager())
            {
                if (manager.Sil(zimmet.Id) > 0)
                    return RedirectToAction("Listele");
                else
                    ModelState.AddModelError("", "Silme yapılamadı...");

            }
            return View();
        }
    }
}