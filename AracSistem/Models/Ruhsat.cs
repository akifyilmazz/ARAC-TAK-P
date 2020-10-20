namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ruhsat")]
    public partial class Ruhsat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ruhsat()
        {
            Arac = new HashSet<Arac>();
        }

        [Key]
        public int Ruhsat_Id { get; set; }

        public int Musteri_Id { get; set; }

        public DateTime Ruhsat_EklenmeTarih { get; set; }

        [Required]
        [StringLength(100)]
        public string Ruhsat_No { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arac> Arac { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
