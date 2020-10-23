namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            Musteri_Islem = new HashSet<Musteri_Islem>();
            Ruhsat = new HashSet<Ruhsat>();
        }

        [Key]
        public int Musteri_Id { get; set; }

        [StringLength(100)]
        public string Musteri_AdSoyad { get; set; }

        [StringLength(10)]
        public string Musteri_Telefon { get; set; }

      

        [StringLength(250)]
        public string Musteri_Adres { get; set; }

        [StringLength(10)]
        public string Musteri_CepTelefon { get; set; }

        [StringLength(100)]
        public string Musteri_Mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri_Islem> Musteri_Islem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ruhsat> Ruhsat { get; set; }
    }
}
