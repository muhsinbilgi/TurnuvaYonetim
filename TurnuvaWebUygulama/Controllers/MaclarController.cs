using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeritabaniKatmani;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.GrupOperasyon;

namespace TurnuvaWebUygulama.Controllers
{
    public class MaclarController : Controller
    {
        // GET: Maclar
        public ActionResult Index()
        {

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            MacListele model = new MacListele();

            model.MacHaftalari = MvcDbHelper.Repository.GetById<MacHaftalari>(Queries.MacHaftalari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
            model.Maclar = MvcDbHelper.Repository.GetById<Maclar>(Queries.Maclar.GetAll, new { Id = m.SeciliTurnuva }).ToList();


            return View(model);
        }

        public ActionResult Gruplar()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            
            GrupListele model = new GrupListele();
            
            model.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
            model.Gruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();
       

            return View(model);
        }


        public ActionResult Detay(int Id)
        {

            MacTakimDetay model = new MacTakimDetay();
            

            model.MacDetay = MvcDbHelper.Repository.GetById<MacDetay>(Queries.MacDetay.GetbyId, new { Id = Id }).FirstOrDefault();
            model.Detaylar = MvcDbHelper.Repository.GetById<MacDetay>(Queries.MacDetay.GetbyId, new { Id = Id }).ToList();


            return View(model);
        }

        public ActionResult DetayEkle(int Id)
        {
            List<SelectListItem> tkm = (from i in MvcDbHelper.Repository.GetById<MacDetay>(Queries.MacDetay.GetTkm, new { Id = Id }).ToList()
            select new SelectListItem
                                             {
                                                 Text = i.BirinciTakimAdi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

     


            ViewBag.tkm = tkm;

            return View();
        }


        [HttpPost]
        public ActionResult DetayEkle(MacDetay model, HttpPostedFileBase MacDetay, int Id)
        {
            List<SelectListItem> tkm = (from i in MvcDbHelper.Repository.GetById<MacDetay>(Queries.MacDetay.GetTkm, new { Id = Id }).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.BirinciTakimAdi,
                                            Value = i.Id.ToString()
                                        }).ToList();





            MvcDbHelper.Repository.Insert(Queries.MacDetay.Insert, model);
            ViewBag.Basari = 1;
            ViewBag.tkm = tkm;
            return View();

        }













    }
}