using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class InvcociesDetail
    {
        public Fatura Faturas { get; set; }

        public List<Stok_Islem> Stok_Islems { get; set; }
    }
}