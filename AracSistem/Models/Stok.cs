namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stok")]
    public partial class Stok
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stok()
        {
            Stok_Islem = new HashSet<Stok_Islem>();
        }

        [Key]
        public int Stok_Id { get; set; }

        public int Kategori_Id { get; set; }

        public int Birim_Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Stok_Barkod { get; set; }

        [Required]
        [StringLength(100)]
        public string Stok_Ad { get; set; }

        [Column(TypeName = "money")]
        public decimal Stok_AlisFiyat { get; set; }

        [Column(TypeName = "money")]
        public decimal Stok_SatisFiyat { get; set; }

        public int? Stok_KdvOran { get; set; }

        public int? Stok_OtvOran { get; set; }

        public virtual Birim Birim { get; set; }

        public virtual Kategori Kategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stok_Islem> Stok_Islem { get; set; }
    }
}
