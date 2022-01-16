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
    public class PuanHesapla
    {

        public static int Hesapla(int TurnuvaId)
        {
           

           List<Gruplar> Grp = MvcDbHelper.Repository.GetById<Gruplar>(Queries.Gruplar.GetPuanDurumu, new { TurnuvaId = TurnuvaId }).ToList();

            foreach(var item in Grp)
            {
                MvcDbHelper.Repository.Update(Queries.Gruplar.Update, item);
            }


            return 1;
        }

    }
}
