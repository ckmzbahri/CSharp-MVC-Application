using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcodev.Models.Data;

namespace mvcodev.Controllers
{
    public class adminController : Controller
    {
        mvcveriEntities5 db = new mvcveriEntities5();


        // GET: admin

        public ActionResult anasayfa()
        {
            var degerler = db.hakkimizda.ToList();
            return View(degerler);
        }


        // GET: admin
        public ActionResult duyurular()
        {

            var degerler = db.duyurular.ToList();
            return View(degerler);
        }
        // GET: admin
        public ActionResult iletisim()
        {
            var degerler = db.iletisim.ToList();
            return View(degerler);
        }
        // GET: admin
        public ActionResult kullanici()
        {
            var degerler = db.kullanici.ToList();
            return View(degerler);
        }
        // GET: admin
        public ActionResult yemek()
        {
            var degerler = db.yemekler.ToList();
            return View(degerler);
        }
        // GET: admin
        public ActionResult mekan()
        {
            var degerler = db.mekan.ToList();
            return View(degerler);
        }  // GET: admin
        public ActionResult sanatcilar()
        {
            var degerler = db.sanatcilar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yeniduyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniduyuru(duyurular p1, HttpPostedFileBase uploadfile)
        {
            if (uploadfile.ContentLength > 0)
            {
                string filepath = System.IO.Path.Combine(Server.MapPath("~/Content/images"), System.IO.Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filepath);
                p1.resim = System.IO.Path.GetFileName(uploadfile.FileName);
            }
            //if (!ModelState.IsValid)
            //{
            //    return View("yeniduyuru");
            //}
            db.duyurular.Add(p1);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult yenisanatci()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult yenisanatci(sanatcilar p1, HttpPostedFileBase uploadfile)
        {
            if (uploadfile.ContentLength > 0)
            {
                string filepath = System.IO.Path.Combine(Server.MapPath("~/Content/images"), System.IO.Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filepath);
                p1.sanatci_fotograf = System.IO.Path.GetFileName(uploadfile.FileName);
            }
            if (!ModelState.IsValid)
            {
                return View("yenisanatci");
            }
            db.sanatcilar.Add(p1);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult yeniyemek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniyemek(yemekler p1, HttpPostedFileBase uploadfile)
        {
            if (uploadfile.ContentLength > 0)
            {
                string filepath = System.IO.Path.Combine(Server.MapPath("~/Content/images"), System.IO.Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filepath);
                p1.menu_fotograf = System.IO.Path.GetFileName(uploadfile.FileName);
            }
            if (!ModelState.IsValid)
            {
                return View("yeniyemek");
            }
            db.yemekler.Add(p1);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult yenimekan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenimekan(mekan p1, HttpPostedFileBase uploadfile, HttpPostedFileBase uploadfile1, HttpPostedFileBase uploadfile2)
        {
            if (uploadfile.ContentLength > 0 && uploadfile1.ContentLength > 0 && uploadfile2.ContentLength > 0)
            {
                string filepath = System.IO.Path.Combine(Server.MapPath("~/Content/images"), System.IO.Path.GetFileName(uploadfile.FileName));
                string filepath1 = System.IO.Path.Combine(Server.MapPath("~/Content/images"), System.IO.Path.GetFileName(uploadfile1.FileName));
                string filepath2 = System.IO.Path.Combine(Server.MapPath("~/Content/images"), System.IO.Path.GetFileName(uploadfile2.FileName));
                uploadfile.SaveAs(filepath);
                uploadfile1.SaveAs(filepath1);
                uploadfile2.SaveAs(filepath2);
                p1.mekan_foto1 = System.IO.Path.GetFileName(uploadfile.FileName);
                p1.mekan_foto2 = System.IO.Path.GetFileName(uploadfile1.FileName);
                p1.mekan_foto3 = System.IO.Path.GetFileName(uploadfile2.FileName);
            }
            if (!ModelState.IsValid)
            {
                return View("yenimekan");
            }
            db.mekan.Add(p1);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult yenikullanici()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikullanici(kullanici p1)
        {
            if (!ModelState.IsValid)
            {
                return View("yenikullanici");
            }
            db.kullanici.Add(p1);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult yenihakkimiz()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenihakkimiz(hakkimizda p1)
        {

            if (!ModelState.IsValid)
            {
                return View("yenihakkimiz");
            }
            db.hakkimizda.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult duyurusil(int id)
        {
            var duyuru = db.duyurular.Find(id);
            db.duyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("duyurular");
        }
        public ActionResult SIL(int id)
        {
            var sil = db.hakkimizda.Find(id);
            db.hakkimizda.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("anasayfa");
        }
        public ActionResult iletSIL(int id)
        {
            var sil = db.iletisim.Find(id);
            db.iletisim.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("iletisim");
        }
        public ActionResult adminSIL(int id)
        {
            var sil = db.kullanici.Find(id);
            db.kullanici.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index","Anasayfa");
        }
        public ActionResult mekanSIL(int id)
        {
            var sil = db.mekan.Find(id);
            db.mekan.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("mekan");
        }
        public ActionResult sanatSIL(int id)
        {
            var sil = db.sanatcilar.Find(id);
            db.sanatcilar.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("sanatcilar");
        }
        public ActionResult yemekSIL(int id)
        {
            var sil = db.yemekler.Find(id);
            db.yemekler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("yemek");
        }
        public ActionResult guncelyemek(int id)
        {
            var guncel = db.yemekler.Find(id);
            Session["resim"] = guncel.menu_fotograf;
            return View("guncelyemek", guncel);
        }
        public ActionResult Guncelleyemek(yemekler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("guncelyemek");
            }
            var guncel = db.yemekler.Find(p1.menu_id);
            guncel.menu_adi = p1.menu_adi;
            guncel.menu_icerik = p1.menu_icerik;
            guncel.menu_fiyat = p1.menu_fiyat;
            db.SaveChanges();
            return RedirectToAction("yemek");
        }
        public ActionResult guncelhak(int id)
        {
            var guncel = db.hakkimizda.Find(id);

            return View("guncelhak", guncel);
        }
        public ActionResult Guncellehak(hakkimizda p1)
        {
            if (!ModelState.IsValid)
            {
                return View("guncelhak");
            }
            var guncel = db.hakkimizda.Find(p1.metin_id);
            guncel.metin = p1.metin;

            db.SaveChanges();
            return RedirectToAction("anasayfa");
        }
        public ActionResult guncelduy(int id)
        {
            var guncel = db.duyurular.Find(id);
            Session["resim"] = guncel.resim;
            return View("guncelduy", guncel);
        }
        public ActionResult Guncelleduy(duyurular p1)
        {
            if (!ModelState.IsValid)
            {
                return View("guncelduy");
            }
            var guncel = db.duyurular.Find(p1.id);
            guncel.baslik = p1.baslik;
            guncel.icerik = p1.icerik;
          
            db.SaveChanges();
            return RedirectToAction("duyurular");
        }
        public ActionResult gunceladmin(int id)
        {          
            var guncel = db.kullanici.Find(id);
            return View("gunceladmin", guncel);
        }
        public ActionResult Guncelleadmin(kullanici p1)
        {
            if (!ModelState.IsValid)
            {
                return View("gunceladmin");
            }
            var guncel = db.kullanici.Find(p1.kullanici_id);
            guncel.kullanici_adi = p1.kullanici_adi;
            guncel.kullanici_soyadi = p1.kullanici_soyadi;
            guncel.kullanici_girisadi = p1.kullanici_girisadi;
            guncel.kullanici_girissifre = p1.kullanici_girissifre;
            db.SaveChanges();
            return RedirectToAction("kullanici");
        }
        public ActionResult guncelmekan(int id)
        {
            var guncel = db.mekan.Find(id);
            Session["resim"] = guncel.mekan_foto1;
            Session["resim1"] = guncel.mekan_foto2;
            Session["resim2"] = guncel.mekan_foto3;
            return View("guncelmekan", guncel);
        }
        public ActionResult Guncellemekan(mekan p1)
        {
            if (!ModelState.IsValid)
            {
                return View("guncelmekan");
            }
            var guncel = db.mekan.Find(p1.mekan_id);
            guncel.mekan_adi = p1.mekan_adi;
            guncel.mekan_adres = p1.mekan_adres;
            guncel.kapasite = p1.kapasite;
            guncel.mekan_ucret = p1.mekan_ucret;
            db.SaveChanges();
            return RedirectToAction("mekan");
        }
        public ActionResult guncelsanatci(int id)
        {
            var guncel = db.sanatcilar.Find(id);
            Session["resim"] = guncel.sanatci_fotograf;

            return View("guncelsanatci", guncel);
        }
        public ActionResult Guncellesanatci(sanatcilar p1)
        {
            if (!ModelState.IsValid)
            {
                return View("guncelsanatci");
            }
            var guncel = db.sanatcilar.Find(p1.sanatci_id);
            guncel.sanatci_tc = p1.sanatci_tc;
            guncel.sanatci_ad = p1.sanatci_ad;
            guncel.sanatci_muzik = p1.sanatci_muzik;
            guncel.sanatci_telefon = p1.sanatci_telefon;
            guncel.sanatci_mail = p1.sanatci_mail;
            guncel.sanatci_yas = p1.sanatci_yas;
            guncel.sanatci_ücret = p1.sanatci_ücret;
            guncel.sanatci_video = p1.sanatci_video;
            guncel.sanatci_cinsiyet = p1.sanatci_cinsiyet;

            db.SaveChanges();
            return RedirectToAction("sanatcilar");
        }
        public ActionResult cikis()
        {
            Session["kullanici_girisadi"] = null;
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}