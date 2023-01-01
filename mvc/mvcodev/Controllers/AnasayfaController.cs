using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcodev.Models.Data;

namespace mvcodev.Controllers
{
    public class AnasayfaController : Controller
    {
        mvcveriEntities5 db = new mvcveriEntities5();
        // GET: Anasayfa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hakkinda()
        {
            var degerler = db.hakkimizda.ToList();
            return View(degerler);
        }
        public ActionResult duyurular()
        {
            var degerler = db.duyurular.ToList();
            return View(degerler);
        }
        public ActionResult Mekanlar()
        {

            var degerler = db.mekan.ToList();
            return View(degerler);
        }
        public ActionResult Sanatcilar()
        {
            var degerler = db.sanatcilar.ToList();
            return View(degerler);
        }
        public ActionResult Catring()
        {
            var degerler = db.yemekler.ToList();
            return View(degerler);
           
        }
        public ActionResult iletisim()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(uyebilgi uye )
        {
            var giris = db.uyebilgi.FirstOrDefault(m => m.kullanici_adi == uye.kullanici_adi && m.sifre == uye.sifre);
            if (giris != null)
            {
                Session["kullanici_id"] = giris.üye_id;
                Session["kullanici_adi"] = giris.kullanici_adi;
                return RedirectToAction("anasayfa", "UyeMenu");
            }
            else
            {
                return View("Giris");
            }
            return View();
        }
        [HttpGet]

        public ActionResult Yoneticigiris()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Yoneticigiris(kullanici admin)
        {
            var giris = db.kullanici.FirstOrDefault(m => m.kullanici_girisadi == admin.kullanici_girisadi && m.kullanici_girissifre == admin.kullanici_girissifre);
            if (giris != null)
            {
                Session["kullanici_id"] = giris.kullanici_id;
                Session["kullanici_girisadi"] = giris.kullanici_girisadi;
                return RedirectToAction("anasayfa", "admin");
            }
            else
            {
                return View();
            }

            return View();
        }
        [HttpGet]
        public ActionResult yeniuye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniuye(uyebilgi p1)
        {
            if (!ModelState.IsValid)
            {
                return View("yeniuye");
            }
            db.uyebilgi.Add(p1);
            db.SaveChanges();
            return View();
        }
       

    }
}