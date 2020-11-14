using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class StokEdit
    {
        public Stok Stoks { get; set; }

        public List<Kategori> Kategoris { get; set; }

        public List<Birim> Birims { get; set; }
    }
}