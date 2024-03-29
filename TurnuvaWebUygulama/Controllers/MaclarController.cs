﻿using System;
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
    public class MaclarController : Controller
    {
        // GET: Maclar
        public ActionResult Index()
        {

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            MacListele model = new MacListele();

            model.MacHaftalari = MvcDbHelper.Repository.GetById<MacHaftalari>(Queries.MacHaftalari.GetbyId, new { TurnuvaId = m.SeciliTurnuva }).ToList();
            model.Maclar = MvcDbHelper.Repository.GetById<Maclar>(Queries.Maclar.GetAll, new { TurnuvaId = m.SeciliTurnuva }).ToList();


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

                                 

            List<SelectListItem> tkm = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.MacDetay.GetTkm, new { Id = Id }).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }
                                        ).ToList();
                      
            tkm.Add(new SelectListItem() { Text = "Önce takımı Seç", Value = "0" });

            tkm.OrderByDescending(c => c.Value);


            List<SelectListItem> spr = new List<SelectListItem>();

            spr.Add(new SelectListItem() { Text = "Önce Takım Seç", Value = "0" });

            spr.OrderByDescending(c => c.Value);

            List<SelectListItem> dty = (from i in MvcDbHelper.Repository.GetAll<Detay>(Queries.Detay.GetAll).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();


            ViewBag.tkm = tkm;
            ViewBag.spr = spr;
            ViewBag.dty = dty;
            return View();
        }


        [HttpPost]
        public ActionResult DetayEkle(MacDetay model, int Id)
        {

            List<SelectListItem> tkm = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.MacDetay.GetTkm, new { Id = Id }).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();
            tkm.Add(new SelectListItem() { Text = "Önce Takım Seç", Value = "0" });
            tkm.OrderByDescending(c => c.Value);

            List<SelectListItem> spr = new List<SelectListItem>();

            spr.Add(new SelectListItem() { Text = "Önce Takım Seç", Value = "0" });

            spr.OrderByDescending(c => c.Value);
            List<SelectListItem> dty = (from i in MvcDbHelper.Repository.GetAll<Detay>(Queries.Detay.GetAll).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();

            model.MacId = Id;
            MvcDbHelper.Repository.Insert(Queries.MacDetay.Insert, model);


            Maclar MacSkor = new Maclar();
            MacSkor = MvcDbHelper.Repository.GetById<Maclar>(Queries.MacDetay.GetbyId, new { Id = Id }).FirstOrDefault();

            MacSkor.Id = Id;
            if(model.DetayId == 1 && model.TakimId == MacSkor.BirinciTakimId)
            {
               
                MvcDbHelper.Repository.Update(Queries.Maclar.SkorUpdate, MacSkor);
            }
            if (model.DetayId == 1 && model.TakimId == MacSkor.IkinciTakimId)
            {
       
                MvcDbHelper.Repository.Update(Queries.Maclar.SkorUpdate, MacSkor);
            }

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            Grup.PuanHesapla(m.SeciliTurnuva);






            ViewBag.Basari = 1;
            ViewBag.tkm = tkm;
            ViewBag.spr = spr;
            ViewBag.dty = dty;
            return View();

        }

        public JsonResult TakimSporcu(int Id)
        {

            var sporcular = (from x in MvcDbHelper.Repository.GetById<Sporcular>(Queries.Sporcular.GetbyT, new { TakimId = Id }).ToList()                      
                             select new
                             {
                                 Text = x.Adi + ' ' + x.Soyadi,
                                 Value = x.Id.ToString()

                             }).ToList();

            return Json(sporcular, JsonRequestBehavior.AllowGet);
                       
        }


        public JsonResult GrupTakim(int Id)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            var Takimlar = (from x in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyGT, new { TakimId = Id, TurnuvaId = m.SeciliTurnuva }).ToList()
                             select new
                             {
                                 Text = x.Adi,
                                 Value = x.Id.ToString()

                             }).ToList();
          

            return Json(Takimlar, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Sil(int Id)
        {
            Maclar model = new Maclar() { Id = Id };
            MvcDbHelper.Repository.Delete<Maclar>(Queries.Maclar.Delete, model);
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            Grup.PuanHesapla(m.SeciliTurnuva);
            return RedirectToAction("Index");
        }

        public ActionResult DetaySil(int Id)
        {
            

            MacDetay model = new MacDetay() { Id = Id };
            model = MvcDbHelper.Repository.GetById<MacDetay>(Queries.MacDetay.GetbyDetayId, new { Id = Id }).FirstOrDefault();

            MvcDbHelper.Repository.Delete<MacDetay>(Queries.MacDetay.Delete, model);


            Maclar MacSkor = new Maclar();
           
            MacSkor = MvcDbHelper.Repository.GetById<Maclar>(Queries.MacDetay.GetbyId, new { Id = model.MacId}).FirstOrDefault();


            MacSkor.Id = model.MacId;

            if (model.DetayId == 1 && model.TakimId == MacSkor.BirinciTakimId)
            {

                MvcDbHelper.Repository.Update(Queries.Maclar.SkorUpdate, MacSkor);
            }
            if (model.DetayId == 1 && model.TakimId == MacSkor.IkinciTakimId)
            {

                MvcDbHelper.Repository.Update(Queries.Maclar.SkorUpdate, MacSkor);
            }

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            Grup.PuanHesapla(m.SeciliTurnuva);




            return RedirectToAction("Index");
        }


        public ActionResult Ekle()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
           

            List<SelectListItem> tkm1 = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList()
            select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            tkm1.Add(new SelectListItem() { Text = "Önce ilk takımı Seç", Value = "0" });
            tkm1.OrderByDescending(c => c.Value);

            
            

            List<SelectListItem> hft = (from i in MvcDbHelper.Repository.GetAll<Hafta>(Queries.Hafta.GetAll).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();

            List<SelectListItem> tkm2 = new List<SelectListItem>();
            tkm2.Add(new SelectListItem() { Text = "Önce ilk takımı Seç", Value = "0" });
            tkm2.Add(new SelectListItem() { Text = "Bay", Value = "0" });
            tkm2.OrderByDescending(c => c.Value);

            ViewBag.tkm1 = tkm1;
            ViewBag.tkm2 = tkm2;
            ViewBag.hft = hft;
            return View();
        }



        [HttpPost]
        public ActionResult Ekle(Maclar model, HttpPostedFileBase file)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            List<SelectListItem> tkm1 = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList()
                                         select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();

            tkm1.Add(new SelectListItem() { Text = "Önce ilk takımı Seç", Value = "0" });
            tkm1.OrderByDescending(c => c.Value);
            List<SelectListItem> tkm2 = new List<SelectListItem>();

            tkm2.Add(new SelectListItem() { Text = "Önce ilk takımı Seç", Value = "0" });
            tkm2.Add(new SelectListItem() { Text = "Bay", Value = "0" });
            tkm2.OrderByDescending(c => c.Value);


            List<SelectListItem> hft = (from i in MvcDbHelper.Repository.GetAll<Hafta>(Queries.Hafta.GetAll).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();

           


         
            if(model.IkinciTakimId == 0)
            {
                model.Bay = 1;
            }


          
            model.TurnuvaId = m.SeciliTurnuva;
            MvcDbHelper.Repository.Insert(Queries.Maclar.Insert, model);
            ViewBag.Basari = 1;
            ViewBag.tkm1 = tkm1;
            ViewBag.tkm2 = tkm2;
            ViewBag.hft = hft;
            return View();
        }





    }
}