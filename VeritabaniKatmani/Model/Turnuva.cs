﻿using VeritabaniKatmani.Interface;
using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani
{
    public class Turnuva : IDbModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int KategoriId { get; set; }
        public int YoneticiKullaniciId { get; set; }
        public string Logo { get; set; }
        public string KategoriAdi { get; set; }
        public string YoneticiAdi { get; set; }
        public int TakimSayisi { get; set; }



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
