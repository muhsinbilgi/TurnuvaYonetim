using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Istatistikler : IDbModel
    {
        public int Id { get; set; }
        public int SporcuSayisi { get; set; }
        public int TakimSayisi { get; set; }
        public int AtilanGol { get; set; }
        public int SarikartSayisi { get; set; }
        public int KirmiziSarikartSayisi { get; set; }

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
