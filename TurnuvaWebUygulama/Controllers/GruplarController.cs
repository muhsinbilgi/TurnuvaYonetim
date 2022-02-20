using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeritabaniKatmani;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.FiksturOperasyon;

namespace TurnuvaWebUygulama.Controllers
{
    public class GruplarController : Controller
    {
        // GET: Gruplar
        public ActionResult Index()
        {

                var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

                GrupListele model = new GrupListele();

                model.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                model.Gruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();



            return View(model);
         
        }

        public ActionResult Ekle()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            GrupTakim model = new GrupTakim();
            model.Takimlar = Grup.GrupsuzTakimGetir(m.SeciliTurnuva);
            model.GrupListe = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();
            model.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();



            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(GrupTakim model)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
          

            var SeciliTakimlar = model.Takimlar.Where(x => x.Secim == true).ToList<Takimlar>();
            Gruplar Grp = new Gruplar();

            foreach (var item in SeciliTakimlar)
            {
                Grp.GrupId = model.Gruplar.GrupId;
                Grp.TurnuvaId = m.SeciliTurnuva;
                Grp.TakimId = item.Id;

                MvcDbHelper.Repository.Insert(Queries.Gruplar.Insert, Grp);
            }

            
            model.Takimlar =  Grup.GrupsuzTakimGetir(m.SeciliTurnuva);
            model.GrupListe = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();
            model.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();

            ViewBag.Basari = 1;
            return View(model);
        }

        public ActionResult Sil(String GrupId)
        {
            Gruplar model = new Gruplar() { GrupId = GrupId};
            MvcDbHelper.Repository.Delete<Gruplar>(Queries.Gruplar.Delete, model);
            return RedirectToAction("Ekle");
        }



    }
}