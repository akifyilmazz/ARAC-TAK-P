namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IslemTur")]
    public partial class IslemTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IslemTur()
        {
            Fatura = new HashSet<Fatura>();
            Stok_Islem = new HashSet<Stok_Islem>();
        }

        [Key]
        public int IslemTur_Id { get; set; }

        public bool IslemTur_Tip { get; set; }

        [Required]
        [StringLength(100)]
        public string IslemTur_Ad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stok_Islem> Stok_Islem { get; set; }
    }
}
