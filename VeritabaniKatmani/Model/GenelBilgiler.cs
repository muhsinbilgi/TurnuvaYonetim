using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace VeritabaniKatmani
{
    public class GenelBilgiler
    {

        public int Id { get; set; }
        public Istatistikler Istatistikler { get; set; }
        public List<GolKralligi> GolKralligi { get; set; }
        public List<Centilmenlik> Centilmenlik { get; set; }



    }
}

