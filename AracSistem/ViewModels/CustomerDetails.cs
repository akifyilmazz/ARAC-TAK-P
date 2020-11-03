using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class CustomerDetails
    {

        public Musteri Musteris { get; set; }

        public List<Ruhsat> Ruhsats {get; set;}

    }
}