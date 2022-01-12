using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Centilmenlik : IDbModel
    {
        public int Id { get; set; }
        public string TakimAdi { get; set; }
        public int SarikartSayisi { get; set; }
        public int KirmiziKartSayisi { get; set; }







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
