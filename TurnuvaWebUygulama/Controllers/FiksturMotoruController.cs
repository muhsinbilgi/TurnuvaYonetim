using VeritabaniKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.FiksturOperasyon;

namespace TurnuvaWebUygulama.Controllers
{
    public class FiksturMotoruController : Controller
    {
        // GET: FiksturMotoru
        public ActionResult Index()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
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
            ViewModel.KayitliGruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();

            if (ViewModel.KayitliGruplar.Count == 0)
            {
                ViewBag.ManuelGrup = false;
            }
            else
            {
                ViewBag.ManuelGrup = true;
                ViewModel.Gruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();
                ViewModel.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
            }


            ViewBag.TurnuvaTuru = TurnuvaTuru;
            ViewBag.ElemeSistemi = ElemeSistemi;
            ViewBag.GrupAdiTuru = GrupAdiTuru;
            ViewBag.ViewModel = ViewModel;
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
            ViewModel = Grup.GrupOlustur(model.FiksturMotoru);
            ViewModel.KayitliGruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();

            if(ViewModel.KayitliGruplar.Count == 0)
            {
                ViewBag.ManuelGrup = false;
            } else
            {
                ViewBag.ManuelGrup = true;
                ViewModel.Gruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();
                ViewModel.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
            }


            ViewBag.TurnuvaTuru = TurnuvaTuru;
            ViewBag.ElemeSistemi = ElemeSistemi;
            ViewBag.GrupAdiTuru = GrupAdiTuru;
            ViewBag.ViewModel = ViewModel;
            ViewBag.Basari = 1;

            return View(ViewModel);

        }





        public ActionResult Eslesmeler()
        {






         return View();
        }
        [HttpPost]
        public ActionResult Eslesmeler(GrupListele model)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            model.KayitliGruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = m.SeciliTurnuva }).ToList();
           

            List<SelectListItem> GundeKacMac = new List<SelectListItem>();
            var GundeKacMacData = new[]{
                 new SelectListItem{ Value="0", Text=" "},
                 new SelectListItem{ Value="1",Text="1"},
                 new SelectListItem{ Value="2",Text="2"},
                 new SelectListItem{ Value="3",Text="3"},
                  new SelectListItem{ Value="4",Text="4"},
                   new SelectListItem{ Value="5",Text="5"},
             };
            GundeKacMac = GundeKacMacData.ToList();







            Gruplar Grp = new Gruplar();

            if (model.KayitliGruplar.Count == 0)
            {
                foreach (var item in model.Gruplar)
                {
                    Grp.GrupId = item.GrupId;
                    Grp.TurnuvaId = m.SeciliTurnuva;
                    Grp.TakimId = item.TakimId;

                    MvcDbHelper.Repository.Insert(Queries.Gruplar.Insert, Grp);
                }

            }



            if (model.EslesmeMotoru != null)
            {

                if(model.EslesmeMotoru.ManuelTarih == true)
                { 
                model.EslesmeMotoru.TurnuvaId = m.SeciliTurnuva;
                foreach(var item in Eslesme.MacOlustur(model))
                {
                    MvcDbHelper.Repository.Insert(Queries.Maclar.Insert, item);
                }
               
                model.MacHaftalari = MvcDbHelper.Repository.GetById<MacHaftalari>(Queries.MacHaftalari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                model.Maclar = MvcDbHelper.Repository.GetById<Maclar>(Queries.Maclar.GetAll, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                }else
                {

                    // Otomatik maç saatleri hesaplanacak



                }







            }


            ViewBag.GundeKacMac = GundeKacMac;
            return View(model);
        }















        public ActionResult Cikis()
        {

            ViewBag.Basari = null;
            return RedirectToAction("Index");

        }











    }
}