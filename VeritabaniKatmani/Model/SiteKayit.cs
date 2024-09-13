using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class SiteKayit : IDbModel
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string adsoyad { get; set; }
        public string mesaj { get; set; }
        public DateTime KayitZamani { get; set; }
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
