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












  
    

    }
}