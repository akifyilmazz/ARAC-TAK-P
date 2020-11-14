using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class InvociesEdit
    {
        public Fatura Fatura { get; set; }

        public Arac_Islem Arac_Islems { get; set; }

        public List<Arac> Aracs { get; set; }

        public Musteri Musteri { get; set; }

        public List<Stok_Islem> Stok_Islems{ get; set; }

        public List<Stok> Stoks { get; set; }

        public Musteri_Islem Musteri_Islems { get; set; }

        public List<OdemeSekli> OdemeSeklis { get; set; }

        public List<IslemTur> IslemTurs { get; set; }

    }
}