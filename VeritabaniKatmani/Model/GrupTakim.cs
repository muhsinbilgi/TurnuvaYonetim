using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class GrupTakim
    {


        public Gruplar Gruplar { get; set; }

        public List<Takimlar> Takimlar { get; set; }

        public List<Gruplar> GrupListe { get; set; }

        public List<GrupAdlari> GrupAdlari { get; set; }
    }
}

