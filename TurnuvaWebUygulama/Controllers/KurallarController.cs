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
    public class KurallarController : Controller
    {
        // GET: Sporcu
        public ActionResult Index()
        {
            return View(GetKurallar());
        }

        public ActionResult Ekle()
        {
       
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Kurallar model)
        {
 

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();
            MvcDbHelper.Repository.Insert(Queries.Kurallar.Insert, model);
            ViewBag.Basari = 1;
            return View();

        }




        public ActionResult Duzenle(int Id)
        {


            var model = MvcDbHelper.Repository.GetById<Kurallar>(Queries.Kurallar.GetbyId, new { Id = Id }).FirstOrDefault();

            return View(model);
        }



        [HttpPost]
        public ActionResult Duzenle(Gorevliler model)
        {

            ViewBag.Basari = 1;


            MvcDbHelper.Repository.Update(Queries.Kurallar.Update, model);
            return RedirectToAction("Index");
        }




        public ActionResult Sil(int Id)
        {
            Kurallar model = new Kurallar() { Id = Id };
            MvcDbHelper.Repository.Delete<Kurallar>(Queries.Kurallar.Delete, model);
            return RedirectToAction("Index");
        }







        public List<Kurallar> GetKurallar()
        {
           
        var kurallarResult = MvcDbHelper.Repository.GetAll<Kurallar>(Queries.Kurallar.GetAll).ToList();
        return kurallarResult;

        }
    }
}