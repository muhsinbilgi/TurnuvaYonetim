using VeritabaniKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.GrupOperasyon;

namespace TurnuvaWebUygulama.Controllers
{
    public class FiksturMotoruController : Controller
    {
        // GET: FiksturMotoru
        public ActionResult Index()
        {
            List<SelectListItem> TurnuvaTuru = new List<SelectListItem>();
            var TurnuvaTuruData = new[]{
                 new SelectListItem{ Value="1",Text="Eleme"},
                 new SelectListItem{ Value="2",Text="Gruplu"},
                 new SelectListItem{ Value="3",Text="Lig"},
             };
            TurnuvaTuru = TurnuvaTuruData.ToList();

            List<SelectListItem> ElemeSistemi = new List<SelectListItem>();
            var ElemeSistemiData = new[]{
                 new SelectListItem{ Value="1",Text="Ön Eleme"},
                 new SelectListItem{ Value="2",Text="Finale Kadar"},
             };
            ElemeSistemi = ElemeSistemiData.ToList();

            List<SelectListItem> GrupAdiTuru = new List<SelectListItem>();
            var GrupAdiTuruData = new[]{
                 new SelectListItem{ Value="1",Text="Rakam(1. Grup)"},
                 new SelectListItem{ Value="2",Text="Harf(A Grup)"},
                 new SelectListItem{ Value="3",Text="Harf(Kırmızı Grup)"},
             };
            GrupAdiTuru = GrupAdiTuruData.ToList();

            GrupListele ViewModel = new GrupListele();


            ViewBag.TurnuvaTuru = TurnuvaTuru;
            ViewBag.ElemeSistemi = ElemeSistemi;
            ViewBag.GrupAdiTuru = GrupAdiTuru;
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Index(GrupListele model)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            model.FiksturMotoru.TurnuvaId = m.SeciliTurnuva;

            List<SelectListItem> TurnuvaTuru = new List<SelectListItem>();
            var TurnuvaTuruData = new[]{
                 new SelectListItem{ Value="1",Text="Eleme"},
                 new SelectListItem{ Value="2",Text="Gruplu"},
                 new SelectListItem{ Value="3",Text="Lig"},
             };
            TurnuvaTuru = TurnuvaTuruData.ToList();

            List<SelectListItem> ElemeSistemi = new List<SelectListItem>();
            var ElemeSistemiData = new[]{
                 new SelectListItem{ Value="1",Text="Ön Eleme"},
                 new SelectListItem{ Value="2",Text="Finale Kadar"},
             };
            ElemeSistemi = ElemeSistemiData.ToList();

            List<SelectListItem> GrupAdiTuru = new List<SelectListItem>();
            var GrupAdiTuruData = new[]{
                 new SelectListItem{ Value="1",Text="Rakam(1. Grup)"},
                 new SelectListItem{ Value="2",Text="Harf(A Grup)"},
                 new SelectListItem{ Value="3",Text="Harf(Kırmızı Grup)"},
             };
            GrupAdiTuru = GrupAdiTuruData.ToList();




            GrupListele ViewModel = new GrupListele();
            ViewModel = Getir.FiksturOlustur(model.FiksturMotoru);
            



            ViewBag.TurnuvaTuru = TurnuvaTuru;
            ViewBag.ElemeSistemi = ElemeSistemi;
            ViewBag.GrupAdiTuru = GrupAdiTuru;
            return View(ViewModel);

        }

    }
}