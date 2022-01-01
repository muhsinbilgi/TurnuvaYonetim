using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Evrak : IDbModel
    {
        public int Id { get; set; }
        public int SporcuId { get; set; }
        public int EvrakTuru { get; set; }
        public string EvrakAdi { get; set; }
        public string EvrakTuruAdi { get; set; }
        public string DosyaUzanti { get; set; }

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
