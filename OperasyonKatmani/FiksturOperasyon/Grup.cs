using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeritabaniKatmani;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.Helper;

namespace OperasyonKatmani.FiksturOperasyon
{
    public class Grup
    {

        public static int PuanHesapla(int TurnuvaId)
        {
           

           List<Gruplar> Grp = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetPuanDurumu, new { TurnuvaId = TurnuvaId }).ToList();

            foreach(var item in Grp)
            {
                MvcDbHelper.Repository.Update(Queries.Gruplar.Update, item);
            }


            return 1;
        }
       
        public static string GrupAdiGetir(int i, int Tur)
        {
            String GrupId = null;
            if(Tur == 2)
            {
                if(i == 1)
                {
                    GrupId = "A";
                }
                if (i == 2)
                {
                    GrupId = "B";
                }
                if (i == 3)
                {
                    GrupId = "C";
                }
                if (i == 4)
                {
                    GrupId = "D";
                }
            }
            if(Tur == 3)
            {
                if (i == 1)
                {
                    GrupId = "Kırmızı";
                }
                if (i == 2)
                {
                    GrupId = "Mavi";
                }
                if (i == 3)
                {
                    GrupId = "Sarı";
                }
                if (i == 4)
                {
                    GrupId = "Yeşil";
                }
                if (i == 3)
                {
                    GrupId = "Siyah";
                }
                if (i == 3)
                {
                    GrupId = "Beyaz";
                }
            }

            return GrupId;
        }


        public static List<Takimlar> GrupsuzTakimGetir(int TurnuvaId)
        {

            List<Takimlar> Tkm = (from i in MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyGrp, new { TurnuvaId = TurnuvaId }).ToList()
            select new Takimlar
            {
                                            Adi = i.Adi,
                                            Id = i.Id
                                        }).ToList();

          

            return Tkm;
        }


        public static GrupListele GrupOlustur(FiksturMotoru model)
        {
            List<Takimlar> TakimListesi = MvcDbHelper.Repository.GetById<Takimlar>(Queries.Takimlar.GetbyY, new { TurnuvaId = model.TurnuvaId }).ToList();
            List<Gruplar> GrupListesi = new List<Gruplar>();
            List<GrupAdlari> GrupAdlariListesi = new List<GrupAdlari>();


            if (model.TurnuvaTuru == 2)
            {

                var TakimSayisi = MvcDbHelper.Repository.GetById<Turnuva>(Queries.Turnuva.GetByTakimSayisi, new { Id = model.TurnuvaId }).FirstOrDefault();
                int GrupTakimAdeti = (TakimSayisi.TakimSayisi / model.GrupSayisi);
                int mod = (TakimSayisi.TakimSayisi % model.GrupSayisi);
            

                for (int i = 1; i <= model.GrupSayisi; i++)
                {
                    GrupAdlari GrpAd = new GrupAdlari();
                    if(model.GrupAdiTuru == 1)
                    {
                        GrpAd.GrupId = i.ToString();
                    } else
                    {
                        GrpAd.GrupId = GrupAdiGetir(i, model.GrupAdiTuru);
                    }

                    if(mod != 0)
                    {
                        GrupTakimAdeti = GrupTakimAdeti + 1;
                    } 

                    for (int t=1; t <= GrupTakimAdeti; t++)
                    {


                        Random RSayi = new Random();
                        int Sayi = RSayi.Next(0, TakimListesi.Count);

                        
                                                                                                                                                                                     
                        GrupListesi.Add(new Gruplar() 
                        {
                            TakimId = TakimListesi[Sayi].Id,
                            GrupId = GrpAd.GrupId,
                            TurnuvaId = model.TurnuvaId,
                            TakimAdi = TakimListesi[Sayi].Adi,
                        });



                        if (GrupAdlariListesi.Find(x => x.GrupId.Contains(GrpAd.GrupId)) == null)
                        {
                            GrupAdlariListesi.Add(new GrupAdlari()
                            {
                                GrupId = GrpAd.GrupId
                            });
                        }

                        




                        TakimListesi.RemoveAt(Sayi);

                                               
                    }

                    GrupTakimAdeti = GrupTakimAdeti - 1;
                    mod = mod - 1;




                }
              

            }

            GrupListele Grplst = new GrupListele();
            Grplst.Gruplar = GrupListesi;
            Grplst.GrupAdlari = GrupAdlariListesi; 






            return Grplst;



        }










    }
}
