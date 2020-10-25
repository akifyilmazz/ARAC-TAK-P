using AracSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracSistem.ViewModels
{
    public class FaturaCreat
    {
        public List<IslemTur> IslemTurs { get; set; }

        public List<OdemeSekli> OdemeSeklis { get; set; }

    }
}