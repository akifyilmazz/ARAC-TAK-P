using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class ViewResult<T>
    {
        public List<T> Veri { get; set; }
        public decimal toplamKayit { get; set; }
        public int aktifSayfa { get; set; }
    }
}