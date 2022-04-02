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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();


            GenelBilgiler model = new GenelBilgiler();          
            model.Istatistikler = MvcDbHelper.Repository.GetById<Istatistikler>(Queries.GenelBilgiler.istatistikler, new { Id = m.SeciliTurnuva }).FirstOrDefault();
            model.GolKralligi = MvcDbHelper.Repository.GetById<GolKralligi>(Queries.GenelBilgiler.golkralligi, new { Id = m.SeciliTurnuva }).ToList();
            model.Centilmenlik = MvcDbHelper.Repository.GetById<Centilmenlik>(Queries.GenelBilgiler.centilmenlik, new { Id = m.SeciliTurnuva }).ToList();

            

            return View(model);
        }

        public ActionResult Test()
        {
            return View();

        }

        public ActionResult Ayarlar()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            if(m.Rol == "Y") { 

            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetbyTur, new { Id = m.Id }).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
                ViewBag.dgr = degerler;
            }
            if (m.Rol == "A")
            {

                List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Turnuva>(Queries.Turnuva.GetAll).ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.Adi,
                                                     Value = i.Id.ToString()
                                                 }).ToList();
                ViewBag.dgr = degerler;
            }




            var model = MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetbyId, new { Id = m.SeciliTurnuva }).FirstOrDefault();
           


            return View(model);

        }

        [HttpPost]
        public ActionResult Ayarlar(Kullanicilar model)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            Kullanicilar KulModel = new Kullanicilar();
            KulModel.SeciliTurnuva = model.Id;
            KulModel.Id = m.Id;




            MvcDbHelper.Repository.Update(Queries.Kullanicilar.SecTurUpdate, KulModel);

            if (m.Rol == "Y")
            {

                List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetbyTur, new { Id = m.Id }).ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.Adi,
                                                     Value = i.Id.ToString()
                                                 }).ToList();
                ViewBag.dgr = degerler;
            }
            if (m.Rol == "A")
            {

                List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Turnuva>(Queries.Turnuva.GetAll).ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.Adi,
                                                     Value = i.Id.ToString()
                                                 }).ToList();
                ViewBag.dgr = degerler;
            }

     
            return View();
        }





        public ActionResult Profilim()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            var model = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyId, new { Id = m.Id }).FirstOrDefault();
  
            return View(model);

        }


        [HttpPost]
        public ActionResult ProfilDuzenle(Kullanicilar model, HttpPostedFileBase file)
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

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            model.Id = m.Id;

            ViewBag.Basari = 1;

            MvcDbHelper.Repository.Update(Queries.Kullanicilar.ProfilUpdate, model);

            return RedirectToAction("Profilim");
        }

































    }
}