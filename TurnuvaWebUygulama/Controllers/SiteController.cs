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
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {



            return View();
        }



        [HttpPost]
        public ActionResult Index(SiteKayit model)
        {
    

            /* site kayıt insert  */
            SiteKayit Site = new SiteKayit();
            Site.email = model.email;
            Site.adsoyad = model.adsoyad;
            Site.mesaj = model.mesaj;
            Site.KayitZamani = DateTime.Now;


            MvcDbHelper.Repository.Insert(Queries.SiteKayit.Insert, Site);


            ViewBag.Basari = 1;
            ViewBag.KullaniciAdi = Site.adsoyad;
            ViewBag.dgr = Site;
             return View();

        }
























    }
}