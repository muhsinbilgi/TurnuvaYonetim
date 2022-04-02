using VeritabaniKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnuvaWebUygulama.Helper;
using System.Web.Security;
using VeritabaniKatmani.SqlQuery;

namespace TurnuvaWebUygulama.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Kullanicilar Kullanicilar)
        {

            var m = MvcDbHelper.Repository.GetAll<Kullanicilar>(Queries.Kullanicilar.GetAll).FirstOrDefault(X => X.KullaniciAdi == Kullanicilar.KullaniciAdi && X.Parola == Kullanicilar.Parola);

            if (m != null)
            {
               
                FormsAuthentication.SetAuthCookie(m.KullaniciAdi, false);
                Session["KullaniciId"] = m.Id;

                Kullanicilar.Id = m.Id;
                Kullanicilar.SonGirisZamani = DateTime.Now;
                MvcDbHelper.Repository.Update(Queries.Kullanicilar.SonGirisUpdate, Kullanicilar);
                return RedirectToAction("Index", "Home");
             }
            else
            {
                ViewBag.LoginError = "Hatalı Kullanıcı Adı veya Şifre";
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}