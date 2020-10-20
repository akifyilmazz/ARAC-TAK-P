namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Arac_Islem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arac_Islem()
        {
            Fatura = new HashSet<Fatura>();
        }

        [Key]
        public int AracIslem_Id { get; set; }

        public int Arac_Id { get; set; }

        public int AracIslem_Km { get; set; }

        [Column(TypeName = "text")]
        public string AracIslem_Aciklama { get; set; }

        public virtual Arac Arac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
