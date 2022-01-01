using VeritabaniKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;

namespace TurnuvaWebUygulama.Controllers
{
    public class GorevlilerController : Controller
    {
        // GET: Sporcu
        public ActionResult Index()
        {
            return View(GetGorevliler());
        }

        public ActionResult Ekle()
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<GorevTuru>(Queries.GorevTuru.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Gorevliler model, HttpPostedFileBase file)
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<GorevTuru>(Queries.GorevTuru.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();



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
            model.TurnuvaId = m.SeciliTurnuva;
            MvcDbHelper.Repository.Insert(Queries.Gorevliler.Insert, model);
            ViewBag.Basari = 1;
            ViewBag.dgr = degerler;
            return View();

        }




        public ActionResult Duzenle(int Id)
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<GorevTuru>(Queries.GorevTuru.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            var model = MvcDbHelper.Repository.GetById<Gorevliler>(Queries.Gorevliler.GetbyId, new { Id = Id }).FirstOrDefault();

            return View(model);
        }



        [HttpPost]
        public ActionResult Duzenle(Gorevliler model, HttpPostedFileBase file)
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


            model.TurnuvaId = 1;
            ViewBag.Basari = 1;


            MvcDbHelper.Repository.Update(Queries.Gorevliler.Update, model);
            return RedirectToAction("Index");
        }




        public ActionResult Sil(int Id)
        {
            Gorevliler model = new Gorevliler() { Id = Id };
            MvcDbHelper.Repository.Delete<Gorevliler>(Queries.Gorevliler.Delete, model);
            return RedirectToAction("Index");
        }







        public List<Gorevliler> GetGorevliler()
        {


            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            if (m.Rol == "Y" || m.Rol == "A")
            {
                var gorevlilerResultY = MvcDbHelper.Repository.GetById<Gorevliler>(Queries.Gorevliler.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                return gorevlilerResultY;
            }  
            else
            {
                var gorevlilerResult = MvcDbHelper.Repository.GetAll<Gorevliler>(Queries.Gorevliler.GetAll).ToList();
                return gorevlilerResult;
            }


           
        }
    }
}