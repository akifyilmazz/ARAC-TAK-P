using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class FaturaCreat
    {
      public List<Stok> Stoks { get; set; }

        public Musteri Musteris { get; set; }

        public List<Arac_Islem> Arac_Islems { get; set; }

        public List<IslemTur> IslemTurs { get; set; }

        public List<OdemeSekli> OdemeSeklis { get; set; }

        public List<Arac> Aracs { get; set; }

    }
}