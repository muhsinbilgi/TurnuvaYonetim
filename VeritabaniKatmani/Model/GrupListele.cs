using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class GrupListele
    {

        public FiksturMotoru FiksturMotoru { get; set; }

        public EslesmeMotoru EslesmeMotoru { get; set; }
        public List<GrupAdlari> GrupAdlari { get; set; }

        public List<Gruplar> Gruplar { get; set; }

        public List<Gruplar> KayitliGruplar { get; set; }

        public List<Gunler> Gunler { get; set; }
        public List<MacHaftalari> MacHaftalari { get; set; }
        public List<Maclar> Maclar { get; set; }

       


    }
}

