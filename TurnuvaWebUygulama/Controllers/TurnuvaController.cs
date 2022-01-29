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
    public class TurnuvaController : Controller
    {
        public ActionResult Index()
        {

            return View(GetTurnuva());
        }

        // GET: Turnuva
        public ActionResult Ekle()
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Kategori>(Queries.Kategori.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            List<SelectListItem> Yon = (from i in MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyYon, new { Rol = 'Y' }).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AdiSoyadi,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
            ViewBag.Yon = Yon;
            return View();
        }



        [HttpPost]
        public ActionResult Ekle(Turnuva model, HttpPostedFileBase file)
        {

            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Kategori>(Queries.Kategori.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            List<SelectListItem> Yon = (from i in MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyYon, new { Rol = 'Y' }).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.AdiSoyadi,
                                            Value = i.Id.ToString()
                                        }).ToList();

          

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/")
                                                          + file.FileName);
                    model.Logo = file.FileName;

                }


            }


            MvcDbHelper.Repository.Insert(Queries.Turnuva.Insert, model);

            var MaxId = MvcDbHelper.Repository.GetAll<Turnuva>(Queries.Turnuva.GetByMaxId).FirstOrDefault();

            Kullanicilar Kul = new Kullanicilar();
            Kul.Id = model.YoneticiKullaniciId;
            Kul.SeciliTurnuva = MaxId.Id;

            KullaniciTurnuva KulTur = new KullaniciTurnuva();
            KulTur.TurnuvaId = MaxId.Id;
            KulTur.KullaniciId = model.YoneticiKullaniciId;

            MvcDbHelper.Repository.Update(Queries.Kullanicilar.SecTurUpdate, Kul);
            MvcDbHelper.Repository.Insert(Queries.KullaniciTurnuva.Insert, KulTur);

            ViewBag.Basari = 1;
            ViewBag.dgr = degerler;
            ViewBag.Yon = Yon;
            return View();

         }
        public ActionResult Duzenle(int Id)
        {
            List<SelectListItem> degerler = (from i in MvcDbHelper.Repository.GetAll<Kategori>(Queries.Kategori.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Adi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            List<SelectListItem> Yon = (from i in MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyYon, new { Rol = 'Y' }).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.AdiSoyadi,
                                            Value = i.Id.ToString()
                                        }).ToList();

            ViewBag.dgr = degerler;
            ViewBag.Yon = Yon;

            var model = MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetbyId, new { Id = Id }).FirstOrDefault();

            return View(model);
        }



        [HttpPost]
        public ActionResult Duzenle(Turnuva model, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Image/")
                                                          + file.FileName);
                    model.Logo = file.FileName;

                }


            }


            ViewBag.Basari = 1;


            MvcDbHelper.Repository.Update(Queries.Turnuva.Update, model);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int Id)
        {
            Turnuva model = new Turnuva() { Id = Id };
            MvcDbHelper.Repository.Delete<Turnuva>(Queries.Turnuva.Delete, model);
            return RedirectToAction("Index");
        }

        public List<Turnuva> GetTurnuva()
        {
           
                var turnuvaResult = MvcDbHelper.Repository.GetAll<Turnuva>(Queries.Turnuva.GetAll).ToList();
                return turnuvaResult;
            
        }


    }
}