using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcodev.Models.Data;
using System.Diagnostics;

namespace mvcodev.Controllers
{
    public class UyeMenuController : Controller
    {
        mvcveriEntities5 db = new mvcveriEntities5();

        // GET: UyeMenu

        public ActionResult anasayfa()
        {
            return View();
        }
        public ActionResult duyurular()
        {
            var degerler = db.duyurular.ToList();
            return View(degerler);
        }
        public ActionResult hakkinda()
        {
            var degerler = db.hakkimizda.ToList();
            return View(degerler);
        }
        public ActionResult mekanlar()
        {
            var degerler1 = db.mekan.ToList();
            return View(degerler1);
        }
        public ActionResult sanatcilar()
        {
            var degerler = db.sanatcilar.ToList();
            return View(degerler);
        }
        public ActionResult catring()
        {
            var degerler = db.yemekler.ToList();
            return View(degerler);
        }
        public ActionResult rezervasyonyap()
        {
            var rzv = db.mekan.ToList();
            return View(rzv);

        }
        public ActionResult rezervasyonyap1(int id)
        {
            Session["mekanid"] = id;
            var rzv = db.sanatcilar.ToList();
            return View(rzv);

        }
        public ActionResult rezervasyonyap2(int id)
        {
            Session["sanatciid"] = id;
            var rzv = db.yemekler.ToList();
            return View(rzv);

        }
        public ActionResult rezervasyonlarim()
        {
            var degerler = db.rezervasyon.ToList();
            return View(degerler);
        }
        public ActionResult iletisim()
        {
            return View();
        }
        public ActionResult uyedetay()
        {
            var degerler = db.uyebilgi.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yeniiletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniiletisim(iletisim p1)
        {
            if (!ModelState.IsValid)
            {
                return View("yeniiletisim");
            }
            db.iletisim.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult rezervsil(int id)
        {
            var sil = db.rezervasyon.Find(id);
            db.rezervasyon.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("rezerzasyonlarim");
        }
        public ActionResult guncelrezerv(int id)
        {
            var guncel = db.rezervasyon.Find(id);

            return View("guncelrezerv", guncel);
        }
        public ActionResult Guncellerezerv(rezervasyon p1)
        {
            var guncel = db.rezervasyon.Find(p1.id);
            guncel.mekan_id = p1.mekan.mekan_id;
            guncel.sanatci_id = p1.sanatcilar.sanatci_id;
            guncel.menu_id = p1.yemekler.menu_id;
            guncel.tarih = p1.tarih;
            guncel.davetli = p1.davetli;


            db.SaveChanges();
            return RedirectToAction("rezervasyonlarim");
        }
        public ActionResult cikis()
        {
            Session["kullanici_adi"] = null;
            return RedirectToAction("Index", "Anasayfa");
        }
        //public ActionResult mekansec(int p1)
        //{
        //    var sec = db.hakkimizda.Find(p1);

        //    return View("mekansec", sec);
        //}
        [HttpGet]
        public ActionResult rzvtut(int id)
        {

            Session["yemekid"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult rzvtut(rezervasyon p1)
        {

        
            p1.mekan_id = int.Parse(Session["mekanid"].ToString());
            p1.sanatci_id = int.Parse(Session["sanatciid"].ToString());
            p1.menu_id = int.Parse(Session["yemekid"].ToString());
            p1.kullanici_detay = Session["kullanici_id"].ToString();
            db.rezervasyon.Add(p1);
            db.SaveChanges();

            return View("anasayfa");
        }
        public ActionResult rzvSIL(int id)
        {
            var sil = db.rezervasyon.Find(id);
            db.rezervasyon.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("rezervasyonyap");
        }
        //  static public int e = 0;

        //  public ActionResult rzvhesap(int sanatciUcret)
        //  {


        ///*      int id = 0;
        //      foreach(var i in db.rezervasyon)
        //      {
        //          id = i.id;
        //      }
        //      int a = 0, b = 0, c = 0, d = 0;
        //      var p1 = db.rezervasyon.Find(id);
        //              a = int.Parse(p1.mekan.mekan_ucret.ToString());
        //              b = int.Parse(p1.yemekler.menu_fiyat.ToString());
        //              c = int.Parse(p1.davetli.ToString());
        //              d = int.Parse(p1.sanatcilar.sanatci_ücret.ToString());
        //              e = a + d + (b * c);

        //      //p1.toplam_fiyat = e;
        //      //db.SaveChanges(); */
        //      return RedirectToAction("rzvtut");
        //  }

        //  [HttpPost]
        //  public void getSanatciucret(int sanatciUcret)
        //  {
        //      Debug.WriteLine("ey : " + sanatciUcret);
        //  }
        public ActionResult uyeSIL(int id)
        {
            var sil = db.uyebilgi.Find(id);
            db.uyebilgi.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index", "Anasayfa");
        }
        
        public ActionResult gunceluye(int id)
        {
            var guncel = db.uyebilgi.Find(id);
            return View("gunceluye", guncel);
        }
        public ActionResult Guncelleuye(uyebilgi p1)
        {
            if (!ModelState.IsValid)
            {
                return View("gunceluye");
            }
            var guncel = db.uyebilgi.Find(p1.üye_id);
            guncel.üye_adi = p1.üye_adi;
            guncel.üye_soyadi = p1.üye_soyadi;
            guncel.mail = p1.mail;
          
            guncel.cinsiyet = p1.cinsiyet;
            guncel.kullanici_adi = p1.kullanici_adi;
            guncel.sifre = p1.sifre;
            db.SaveChanges();
            return RedirectToAction("uyedetay");
        }
    }
}