using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Kullanicilar : IDbModel
    {
        public int Id { get; set; }
        public string AdiSoyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string Rol { get; set; }
        public string RolAciklama { get; set; }
        public DateTime SonGirisZamani { get; set; }
        public int TakimId { get; set; }
        public int SeciliTurnuva { get; set; }

        public string Resim { get; set;}
       public int MaxId { get; set; }

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
