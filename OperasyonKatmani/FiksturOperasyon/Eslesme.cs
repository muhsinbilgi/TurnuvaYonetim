using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeritabaniKatmani;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.Helper;
using System.Globalization;

namespace OperasyonKatmani.FiksturOperasyon
{
    public class Eslesme
    {


        public static List<Maclar> MacOlustur(GrupListele model)
        {
            
                 
            //model.Gunler[0].Adi = "Pazartesi";
            //model.Gunler[1].Adi = "Salı";
            //model.Gunler[2].Adi = "Çarşamba";
            //model.Gunler[3].Adi = "Perşembe";
            //model.Gunler[4].Adi = "Cuma";
            //model.Gunler[5].Adi = "Cumartesi";
            //model.Gunler[6].Adi = "Pazar";
                                  

           
            //var SeciliGunler = model.Gunler.Where(x => x.Secim == true).ToList<Gunler>();


            //DateTime MacGunu = new DateTime();
            //MacGunu = model.EslesmeMotoru.TurnuvaBaslamaTarihi.Date + model.EslesmeMotoru.IlkMacSaati.TimeOfDay;


            //var GrupTakimSayisi = (from gs in model.KayitliGruplar
            //                       group gs by gs.GrupId into grs
            //                       select new
            //                       {
            //                           Count = grs.Count()
            //                       }
            //                      ).OrderByDescending(x => x.Count).ToList();

            //int TurnuvaMacSayisi = 0;

            //// Turnuva bitiş tarihi hesapla
            //foreach(var item in GrupTakimSayisi)
            //{
            //    var GrupMacSayi = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.MacSablonu.GetCount, new { Sayi = item.Count }).FirstOrDefault();

            //    TurnuvaMacSayisi = TurnuvaMacSayisi + GrupMacSayi.GrupMacSayisi;
            //}

            //int MacYapilacakGunSayisi = (TurnuvaMacSayisi / model.EslesmeMotoru.GundeKacMac);  //+1 eklenemesi incelenecek

            //int TurnuvaBitisGun = (MacYapilacakGunSayisi / SeciliGunler.Count)*7;


            // // Maç Slotları Oluştur.                                     
            //List<Maclar> Maclar = new List<Maclar>();
            //for (int i = 1; i <= TurnuvaBitisGun; i++)
            //{
            //    String MacGunYazi = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)MacGunu.DayOfWeek].ToString();

            //    foreach (var item in SeciliGunler)
            //    {
            //        if (MacGunYazi == item.Adi)
            //        {

            //            for(int k= 1; k <= model.EslesmeMotoru.GundeKacMac; k++)
            //            { 

            //            Maclar.Add(new Maclar()
            //            {
            //                TarihSaat = MacGunu,
            //                TurnuvaId = model.EslesmeMotoru.TurnuvaId
            //            });
            //                // Maçlar arası 2 saat belirlendi bu arayüz parametredende alınabilir.
            //                MacGunu = MacGunu.AddHours(2);


            //            }
            //        }
            //    }
            // MacGunu = MacGunu.AddDays(1);
            // MacGunu = MacGunu.Date + model.EslesmeMotoru.IlkMacSaati.TimeOfDay;
            //}



            // Takımların Eslesma Sayısını Rasgele ata
            List<GrupTakimEslesme> GrpTkmEslm = new List<GrupTakimEslesme>();
            List<Gruplar> Grup = new List<Gruplar>();
            List<Sayi> Sayilar = new List<Sayi>();


            model.GrupAdlari = MvcDbHelper.Repository.GetById<GrupAdlari>(Queries.GrupAdlari.GetbyId, new { TurnuvaId = model.EslesmeMotoru.TurnuvaId }).ToList();
            model.Gruplar = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetAll, new { Id = model.EslesmeMotoru.TurnuvaId }).ToList();

      
            foreach(var item in model.GrupAdlari)
            {
                 Grup = model.Gruplar.Where(x => x.GrupId == item.GrupId).ToList();

                for(int i = 1; i <= Grup.Count; i++)
                {

                    Sayilar.Add(new Sayi()
                    {
                        Deger = i
                    }); ;
                }

                foreach (var g in Grup)
                {
                  

                    Random Sayi = new Random();
                    int Sayi1 = Sayi.Next(0, Sayilar.Count);


                    GrpTkmEslm.Add(new GrupTakimEslesme()
                    {
                        GrupId = g.GrupId,
                        TakimId = g.TakimId,
                        EslesmeSirasi = Sayilar[Sayi1].Deger 
                    });

                    Sayilar.RemoveAt(Sayi1);


                }

            }

            // Macların Oluşturulması
            var MacSablonu = MvcDbHelper.Repository.GetAll<MacSablonu>(Queries.MacSablonu.GetAll).ToList();
            List<Maclar> MacEslesme = new List<Maclar>();


            foreach (var item in model.GrupAdlari)
            {
                Grup = model.Gruplar.Where(x => x.GrupId == item.GrupId).ToList();
                var GrupMacSablonu = MacSablonu.Where(x => x.GrupTakimSayisi == Grup.Count).ToList();

                foreach(var dgr in GrupMacSablonu)
                {

                    var BirTakim = GrpTkmEslm.Where(x => x.EslesmeSirasi == dgr.BirinciTakim && x.GrupId == item.GrupId).FirstOrDefault();
                    var IkiTakim = GrpTkmEslm.Where(x => x.EslesmeSirasi == dgr.IkinciTakim && x.GrupId == item.GrupId).FirstOrDefault();


                    int IkinciTakim;
                    

                    if (IkiTakim == null)
                    {
                        IkinciTakim = 0;
                    }else
                    {
                         IkinciTakim = IkiTakim.TakimId;
                    }

                    var Hafta = MvcDbHelper.Repository.GetById<Hafta>(Queries.Hafta.GetbyAd, new { Adi = dgr.Tur }).FirstOrDefault();

                    

                    MacEslesme.Add(new Maclar()
                    {

                        BirinciTakimId = BirTakim.TakimId,
                        IkinciTakimId = IkinciTakim,
                        Hafta = Hafta.Id.ToString(),
                        TurnuvaId = model.EslesmeMotoru.TurnuvaId
                    });

                }
            }


            



            return MacEslesme;

        }










    }
}
