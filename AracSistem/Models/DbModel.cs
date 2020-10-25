namespace AracSistem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
          
        }

        public virtual DbSet<Arac> Arac { get; set; }
        public virtual DbSet<Arac_Islem> Arac_Islem { get; set; }
        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<IslemTur> IslemTur { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Musteri_Islem> Musteri_Islem { get; set; }
        public virtual DbSet<OdemeSekli> OdemeSekli { get; set; }
        public virtual DbSet<Ruhsat> Ruhsat { get; set; }
        public virtual DbSet<Stok> Stok { get; set; }
        public virtual DbSet<Stok_Islem> Stok_Islem { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arac>()
                .Property(e => e.Arac_Plaka)
                .IsFixedLength();

            modelBuilder.Entity<Arac>()
                .Property(e => e.Arac_Sase)
                .IsUnicode(false);

            modelBuilder.Entity<Arac>()
                .HasMany(e => e.Arac_Islem)
                .WithRequired(e => e.Arac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Arac_Islem>()
                .Property(e => e.AracIslem_Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Arac_Islem>()
                .HasMany(e => e.Fatura)
                .WithRequired(e => e.Arac_Islem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Birim>()
                .Property(e => e.Birim_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Birim>()
                .HasMany(e => e.Stok)
                .WithRequired(e => e.Birim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fatura>()
                .Property(e => e.Fatura_Tutar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Fatura>()
                .Property(e => e.Fatura_Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<IslemTur>()
                .Property(e => e.IslemTur_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<IslemTur>()
                .HasMany(e => e.Fatura)
                .WithRequired(e => e.IslemTur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>()
                .Property(e => e.Kategori_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Stok)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Musteri_AdSoyad)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Musteri_Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Musteri_Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Musteri_CepTelefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Musteri_Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Musteri_Islem)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Ruhsat)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OdemeSekli>()
                .Property(e => e.OdemeSekli_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<OdemeSekli>()
                .HasMany(e => e.Fatura)
                .WithRequired(e => e.OdemeSekli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ruhsat>()
                .Property(e => e.Ruhsat_No)
                .IsUnicode(false);

            modelBuilder.Entity<Ruhsat>()
                .HasMany(e => e.Arac)
                .WithRequired(e => e.Ruhsat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stok>()
                .Property(e => e.Stok_Barkod)
                .IsUnicode(false);

            modelBuilder.Entity<Stok>()
                .Property(e => e.Stok_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Stok>()
                .Property(e => e.Stok_AlisFiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stok>()
                .Property(e => e.Stok_SatisFiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stok>()
                .HasMany(e => e.Stok_Islem)
                .WithRequired(e => e.Stok)
                .WillCascadeOnDelete(false);
        }
    }
}
