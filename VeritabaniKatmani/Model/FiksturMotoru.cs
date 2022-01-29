using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class FiksturMotoru : IDbModel
    {
        public int Id { get; set; }
        public int TurnuvaTuru { get; set; }
        public int ElemeSistemi { get; set; }
        public int GrupSayisi { get; set; }
        public int GrupAdiTuru { get; set; }
        public bool MacSistemi { get; set; }
        public int TurnuvaId {get; set;}


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


