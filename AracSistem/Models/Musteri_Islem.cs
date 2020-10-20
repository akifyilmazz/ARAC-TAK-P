namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Musteri_Islem
    {
        [Key]
        public int MusteriIslem_Id { get; set; }

        public int Musteri_Id { get; set; }

        public int? MusteriIslem_Tutar { get; set; }

        public int? MusteriIslem_Kilometre { get; set; }

        public DateTime? MusteriIslem_Tarih { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
