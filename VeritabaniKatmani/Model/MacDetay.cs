using System;
using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;

namespace VeritabaniKatmani
{
    public class MacDetay : IDbModel
    {
        public int Id { get; set; }
        public int MacId { get; set; }
        public int TakimId { get; set; }
        public String BirinciTakimAdi { get; set; }
        public String IkinciTakimAdi { get; set; }
        public int BirinciTakimId { get; set; }
        public int IkinciTakimId { get; set; }
        public int SporcuId { get; set; }
        public String SporcuAdi { get; set; }
        public String Detayadi { get; set; }
        public int DetayId { get; set; }
        public int DetayDakika { get; set; }
        public int BirinciTakimSkor { get; set; }
        public int IkinciTakimSkor { get; set; }
        public string BirinciTakimLogo { get; set; }
        public string IkinciTakimLogo { get; set; }
        public DateTime MacTarihSaat { get; set; }
        public string Hafta { get; set; }








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
