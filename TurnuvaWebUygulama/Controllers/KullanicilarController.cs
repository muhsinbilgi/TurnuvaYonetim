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
    public class KullanicilarController : Controller
    {
        // GET: Takimlar
        public ActionResult Index()
        {

            return View(GetKullanicilar());
        }


        public ActionResult Ekle()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            List<SelectListItem> Rol = (from i in MvcDbHelper.Repository.GetAll<Rol>(Queries.Rol.GetAll).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.RolAciklama,
                                                 Value = i.RolAdi.ToString()
                                             }).ToList();
            List<SelectListItem> Tkm = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new {TurnuvaId = m.SeciliTurnuva}).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();

            Tkm.Add(new SelectListItem() { Text = "Takımsız", Value = "0" });


            ViewBag.Rol = Rol;
            ViewBag.Tkm = Tkm;
            return View();
        }



        [HttpPost]
        public ActionResult Ekle(Kullanicilar model, HttpPostedFileBase file)
        {

            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            List<SelectListItem> Rol = (from i in MvcDbHelper.Repository.GetAll<Rol>(Queries.Rol.GetAll).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.RolAciklama,
                                            Value = i.RolAdi.ToString()
                                        }).ToList();
            List<SelectListItem> Tkm = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList()
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
            if(model.Rol == "Y")
            {
                model.TurnuvaId = 0;
                MvcDbHelper.Repository.Insert(Queries.Kullanicilar.Insert, model);
            }else
            {
                model.TurnuvaId = m.SeciliTurnuva;
                model.SeciliTurnuva = m.SeciliTurnuva;
                MvcDbHelper.Repository.Insert(Queries.Kullanicilar.Insert, model);
            }
            
            ViewBag.Basari = 1;
            ViewBag.Rol = Rol;
            ViewBag.Tkm = Tkm;
            return View();
        }




        public ActionResult Duzenle(int Id)
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

            List<SelectListItem> Rol = (from i in MvcDbHelper.Repository.GetAll<Rol>(Queries.Rol.GetAll).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.RolAciklama,
                                            Value = i.RolAdi.ToString()
                                        }).ToList();
            List<SelectListItem> Tkm = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Adi,
                                            Value = i.Id.ToString()
                                        }).ToList();

            ViewBag.Rol = Rol;
            ViewBag.Tkm = Tkm;

            var model = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyId, new { Id = Id }).FirstOrDefault();

            return View(model);
        }



        [HttpPost]
        public ActionResult Duzenle(Kullanicilar model, HttpPostedFileBase file)
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
            model.TurnuvaId = m.SeciliTurnuva;

            ViewBag.Basari = 1;


            MvcDbHelper.Repository.Update(Queries.Kullanicilar.Update, model);
            return RedirectToAction("Index");
        }





        public ActionResult Sil(int Id)
        {
            Kullanicilar model = new Kullanicilar() { Id = Id };
            MvcDbHelper.Repository.Delete<Kullanicilar>(Queries.Kullanicilar.Delete, model);
            return RedirectToAction("Index");
        }


        public List<Kullanicilar> GetKullanicilar()
        {
            var m = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyName, new { KullaniciAdi = User.Identity.Name }).FirstOrDefault();

          if(m.Rol == "A")
            { 
                var kullanicilarResultA = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyA, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                return kullanicilarResultA;
            } else
            {
                var kullanicilarResultY = MvcDbHelper.Repository.GetById<Kullanicilar>(Queries.Kullanicilar.GetbyY, new { TurnuvaId = m.SeciliTurnuva }).ToList();
                return kullanicilarResultY;
            }
       


        }


    }
}