using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class EslesmeMotoru : IDbModel
    {
        public int Id { get; set; }
        public DateTime TurnuvaBaslamaTarihi { get; set; }
        public DateTime IlkMacSaati { get; set; }
        public int GundeKacMac { get; set; }
        public int TurnuvaId {get; set;}

        public int GrupTakimSayisi { get; set; }
        public int HaftaSayisi { get; set; }
        public int ToplamMacSayisi { get; set; }

        public bool ManuelTarih { get; set; }

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


