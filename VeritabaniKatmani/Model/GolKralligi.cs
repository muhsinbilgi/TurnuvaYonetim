using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class GolKralligi : IDbModel
    {
        public int Id { get; set; }
        public string Resim { get; set; }

        public string TakimAdi { get; set; }
        public string AdiSoyadi { get; set; }
        public int GolSayisi { get; set; }







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
