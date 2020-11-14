using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class NewInvociesSales
    {
        public List<Fatura> Fatura { get; set; }

        public List<Arac_Islem> Arac_Islems { get; set; }

        public List<Musteri> Musteri { get; set; }

        public List<Stok> Stoks { get; set; }

        public List<Stok_Islem> Stok_Islems { get; set; }
        
        public Musteri_Islem Musteri_Islems { get; set; }
    }
}