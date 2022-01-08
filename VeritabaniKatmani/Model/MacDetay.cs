using System;
using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;

namespace VeritabaniKatmani
{
    public class MacDetay : IDbModel
    {
        public int Id { get; set; }
        public int MacId { get; set; }
        public String BirinciTakimAdi { get; set; }
        public String IkinciTakimAdi { get; set; }
        public int SporcuAdi { get; set; }
        public int Detayadi { get; set; }
        public string DetayDakika { get; set; }
        public int BirinciTakimSkor { get; set; }
        public int IkinciTakimSkor { get; set; }
        public string BirinciTakimLogo { get; set; }
        public string IkinciTakimLogo { get; set; }
        public DateTime MacTarihSaat { get; set; }
        public int Hafta { get; set; }








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
