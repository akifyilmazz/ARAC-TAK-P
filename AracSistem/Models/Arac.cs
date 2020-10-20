namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Arac")]
    public partial class Arac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arac()
        {
            Arac_Islem = new HashSet<Arac_Islem>();
        }

        [Key]
        public int Arac_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Arac_Plaka { get; set; }

        [StringLength(100)]
        public string Arac_Sase { get; set; }

        public int Ruhsat_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arac_Islem> Arac_Islem { get; set; }

        public virtual Ruhsat Ruhsat { get; set; }
    }
}
