namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stok_Islem
    {
        [Key]
        public int StokIslem_Id { get; set; }

        public int Stok_Id { get; set; }

        public int? IslemTur_Id { get; set; }

        public double StokIslem_Miktar { get; set; }

        public DateTime? StokIslem_Tarih { get; set; }

        public int? Fatura_Id { get; set; }

        public virtual Fatura Fatura { get; set; }

        public virtual IslemTur IslemTur { get; set; }

        public virtual Stok Stok { get; set; }
    }
}
