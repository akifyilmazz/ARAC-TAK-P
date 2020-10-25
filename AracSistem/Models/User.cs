namespace AracSistem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int User_Id { get; set; }

        [StringLength(100)]
        public string User_Mail { get; set; }

        [StringLength(100)]
        public string User_UserAd { get; set; }

        [StringLength(10)]
        public string User_telefon { get; set; }

        [StringLength(100)]
        public string User_Sifre{ get; set; }

    }
}
