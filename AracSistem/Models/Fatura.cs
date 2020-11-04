namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fatura")]
    public partial class Fatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fatura()
        {
            Stok_Islem = new HashSet<Stok_Islem>();
        }

        [Key]
        public int Fatura_Id { get; set; }

        public int IslemTur_Id { get; set; }

        public int OdemeSekli_Id { get; set; }

        public int AracIslem_Id { get; set; }

        public DateTime Fatura_Tarih { get; set; }

        [Column(TypeName = "money")]
        public decimal Fatura_Tutar { get; set; }

        [Column(TypeName = "text")]
        public string Fatura_Aciklama { get; set; }

        public virtual Arac_Islem Arac_Islem { get; set; }

        public virtual IslemTur IslemTur { get; set; }

        public virtual OdemeSekli OdemeSekli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stok_Islem> Stok_Islem { get; set; }
    }
}
