using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Maclar : IDbModel
    {
        public int Id { get; set; }
        public DateTime TarihSaat { get; set; }
        public int BirinciTakimId { get; set; }
        public int IkinciTakimId { get; set; }
        public int Bay { get; set; }
        public string Hafta { get; set; }
        public int TurnuvaId { get; set; }
        public string BirinciTakimAdi { get; set; }
        public string IkinciTakimAdi { get; set; }

        public int MaxHafta { get; set; }


        public string Tarih
        {
            get
            {
                return TarihSaat.ToShortDateString();
            }

        }

        public string Saat
        {
            get
            {
                return TarihSaat.ToShortTimeString();
            }

        }



        public AbstractDapperRepository Repository { get; set; }

        public void SetId(object id)
        {
            Id = (int)Id;
        }

        public void SetRepository(AbstractDapperRepository DapperRepository)
        {
            Repository = DapperRepository;
        }
    }
}
