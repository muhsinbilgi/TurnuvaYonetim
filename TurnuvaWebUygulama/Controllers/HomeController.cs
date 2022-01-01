using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeritabaniKatmani;
using TurnuvaWebUygulama.Helper;
using VeritabaniKatmani.SqlQuery;

namespace TurnuvaWebUygulama.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Test()
        {
            return View();

        }

        public ActionResult Ayarlar()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            if(m.Rol == "Y") { 

            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetbyUser, new { Id = m.Id }).ToList()
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
        public ActionResult Ayarlar(Turnuva model)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            Kullanicilar KulModel = new Kullanicilar();
            KulModel.SeciliTurnuva = model.Id;
            KulModel.Id = m.Id;

            MvcDbHelper.Repository.Update(Queries.Kullanicilar.SecTurUpdate, KulModel);

            if (m.Rol == "Y")
            {

                List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetbyUser, new { Id = m.Id }).ToList()
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
    }
}