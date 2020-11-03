using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AracSistem.ViewModels
{
    public class HomeIndex
    {
        public List<Musteri> Musteris { get; set; }
        public List<Fatura> Faturas { get; set; }
        public List<Stok> Stoks { get; set; }
        public List<Arac> Aracs { get; set; }
    }
}