using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Gruplar : IDbModel
    {
        public int Id { get; set; }
        public string GrupId { get; set; }
        public int TakimId { get; set; }
        public int TurnuvaId { get; set; }
        public int OynadigiMac { get; set; }
        public int Galibiyet { get; set; }
        public int Maglubiyet { get; set; }
        public int Beraberlik { get; set; }
        public int AttigiGol { get; set; }
        public int YedigiGol { get; set; }
        public int Puan { get; set; }
        public string TakimAdi { get; set; }

        public int MaxGrup { get; set; }

        public int Averaj
        {
            get {
                return AttigiGol - YedigiGol;
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
