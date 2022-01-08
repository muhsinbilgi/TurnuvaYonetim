using VeritabaniKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;
using PagedList;


namespace TurnuvaWebUygulama.Controllers
{
    public class SporcularController : Controller
    {
        // GET: Sporcu
        public ActionResult Index(int page = 1, int pageSize = 20)
        {

                   
            
                PagedList<Sporcular> model = new PagedList<Sporcular>(GetSporcular(), page, pageSize);

                return View(model);
        }

        [HttpPost]
        public ActionResult Index(string TakimAdi,string SporcuAdi, int page = 1, int pageSize = 20)
        {
          



            if (TakimAdi != "" || SporcuAdi != "")
            {

                if (TakimAdi != "")
                {
                    TakimAdi = "%" + TakimAdi + "%";

                }
                
                if (SporcuAdi != "")
                {
                    SporcuAdi = "%" + SporcuAdi + "%";

                }


                var aramodel = MvcDbHelper.Repository.GetSearch<Sporcular>(Queries.Sporcular.GetSearch, new { TakimAdi = TakimAdi, SporcuAdi = SporcuAdi}).ToList();

                PagedList<Sporcular> model = new PagedList<Sporcular>(aramodel, page, pageSize);

                return View(model);
            }
            else
            {
                PagedList<Sporcular> model = new PagedList<Sporcular>(GetSporcular(), page, pageSize);

                return View(model);
            }

            
        }

        public ActionResult Ekle()
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Statu>(Queries.Statu.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            List<SelectListItem> Takimlar = (from i in  MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.Takimlar = Takimlar;


            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Sporcular model, HttpPostedFileBase file)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Statu>(Queries.Statu.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            List<SelectListItem> Takimlar = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            



            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    model.Resim = model.Adi + model.Soyadi + "Resim" + file.FileName;

                    file.SaveAs(HttpContext.Server.MapPath("~/Image/")
                                                          + model.Resim);
                   

                }


            }
           
            if(model.TakimId == 0)
            {
                model.TakimId = m.TakimId;
            }

            /* Kullanıcı insert  */
            Kullanicilar Kullanici = new Kullanicilar();
            Kullanici.AdiSoyadi = model.Adi + ' ' + model.Soyadi;
            Kullanici.KullaniciAdi = model.Adi.Substring(0, 1) + model.Soyadi.ToLower();
            Kullanici.Parola = model.Adi + 123;
            Kullanici.Rol = "S";
            Kullanici.TakimId = model.TakimId;
            Kullanici.SeciliTurnuva = m.SeciliTurnuva;
            MvcDbHelper.Repository.Insert(Queries.Kullanicilar.Insert, Kullanici);

            /* Sporcu insert */
            var MaxId = MvcDbHelper.Repository.GetAll<Kullanicilar>(Queries.Kullanicilar.GetbyMaxId).FirstOrDefault();
            model.KullaniciId = MaxId.MaxId;
            model.TurnuvaId = m.SeciliTurnuva;
            MvcDbHelper.Repository.Insert(Queries.Sporcular.Insert, model);

            /* Kullanıcı Turnuva tablosuna iinsert */
            KullaniciTurnuva Kt = new KullaniciTurnuva();
            Kt.TurnuvaId = m.SeciliTurnuva;
            Kt.KullaniciId = MaxId.MaxId;
            MvcDbHelper.Repository.Insert(Queries.KullaniciTurnuva.Insert, Kt);




            ViewBag.Basari = 1;
            ViewBag.KullaniciAdi = Kullanici.KullaniciAdi;
            ViewBag.Parola = Kullanici.Parola;
            ViewBag.dgr = degerler;
            ViewBag.Takimlar = Takimlar;
            return View();

        }

        public ActionResult EvrakEkle()
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<EvrakTuru>(Queries.EvrakTuru.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
           
            return View();
        }


        [HttpPost]
        public ActionResult EvrakEkle(Evrak model, HttpPostedFileBase Evrak, int Id)
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<EvrakTuru>(Queries.EvrakTuru.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();



            if (ModelState.IsValid)
            {
                if (Evrak != null)
                {
                    model.EvrakAdi = Id + model.EvrakTuru + Evrak.FileName;
                    Evrak.SaveAs(HttpContext.Server.MapPath("~/Image/")
                                                          + model.EvrakAdi);
                    

                }


            }
            model.SporcuId = Id;
            MvcDbHelper.Repository.Insert(Queries.Evrak.Insert, model);
            ViewBag.Basari = 1;
            ViewBag.dgr = degerler;
            return View();

        }








        public ActionResult Detay(int Id)
        {

            SporcuEvrak model = new SporcuEvrak();

       
            model.Sporcular = MvcDbHelper.Repository.GetById<Sporcular>(Queries.Sporcular.GetbyId, new { Id = Id }).FirstOrDefault();
            model.Evrak = MvcDbHelper.Repository.GetById<Evrak>(Queries.Evrak.GetbySporcuId, new { Id = Id }).ToList();

            var KayitSayi = MvcDbHelper.Repository.GetById<KayitSayi>(Queries.Evrak.GetbyCount, new { Id = Id }).FirstOrDefault();

            ViewBag.ks = KayitSayi.Sayi;
            ViewBag.onay = model.Sporcular.Onay;

            return View(model);
        }


        public ActionResult Duzenle(int Id)
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Statu>(Queries.Statu.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            var model = MvcDbHelper.Repository.GetById<Sporcular>(Queries.Sporcular.GetbyId, new { Id = Id }).FirstOrDefault();

            return View(model);
        }



        [HttpPost]
        public ActionResult Duzenle(Sporcular model, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/")
                                                          + file.FileName);
                    model.Resim = file.FileName;

                }


            }

            
            model.TakimId = 1;
            model.TurnuvaId = 1;
            ViewBag.Basari = 1;


            MvcDbHelper.Repository.Update(Queries.Sporcular.Update, model);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult Sil(int Id)
        {
            Sporcular model = new Sporcular() { Id = Id };
            MvcDbHelper.Repository.Delete<Sporcular>(Queries.Sporcular.Delete, model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Onay(int Id)
        {
            int onay = 1;
            Sporcular model = new Sporcular() { Id = Id, Onay = onay };
            MvcDbHelper.Repository.Onay<Sporcular>(Queries.Sporcular.Onay, model);
            return RedirectToAction("Index");
        }
        public ActionResult Red(int Id)
        {
            int onay = 2;
            Sporcular model = new Sporcular() { Id = Id, Onay = onay };
            MvcDbHelper.Repository.Onay<Sporcular>(Queries.Sporcular.Onay, model);
            return RedirectToAction("Index");
        }


        public List<Sporcular> GetSporcular()
        {

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            if (m.Rol == "Y" || m.Rol == "A")
            {
                var sporcuResultY = MvcDbHelper.Repository.GetById<Sporcular>(Queries.Sporcular.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                return sporcuResultY;
            }
            else if (m.Rol == "T")
            {
                var sporcuResultT = MvcDbHelper.Repository.GetById<Sporcular>(Queries.Sporcular.GetbyT, new { TakimId = m.TakimId }).ToList();
                return sporcuResultT;
            }
            else if (m.Rol == "S")
            {
                var sporcuResultS = MvcDbHelper.Repository.GetById<Sporcular>(Queries.Sporcular.GetbyS, new { KullaniciId = m.Id }).ToList();
                return sporcuResultS;
            }
            else
            {
                var sporcuResult = MvcDbHelper.Repository.GetAll<Sporcular>(Queries.Sporcular.GetAll).ToList();
                return sporcuResult;
            }










            
        }





    }
}