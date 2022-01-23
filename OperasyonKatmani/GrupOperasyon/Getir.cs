using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeritabaniKatmani;
using VeritabaniKatmani.SqlQuery;
using OperasyonKatmani.Helper;

namespace OperasyonKatmani.GrupOperasyon
{
    public class Getir
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




















    }
}
