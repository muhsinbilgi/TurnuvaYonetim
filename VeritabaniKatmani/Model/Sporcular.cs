using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Sporcular : IDbModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int Statu { get; set; }
        public string Resim { get; set; }
        public int KullaniciId { get; set; }
        public string LisansNo { get; set; }
        public string Mevki { get; set; }
        public int TakimId { get; set; }
        public int TurnuvaId { get; set; }
        public string TakimAdi { get; set; }
        public int Onay { get; set; }
       public string StatuAdi { get; set; }
   
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

