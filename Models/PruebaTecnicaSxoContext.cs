using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaTecnicaSxo.Models
{
    public partial class PruebaTecnicaSxoContext : DbContext
    {
        public PruebaTecnicaSxoContext()
        {
        }

        public PruebaTecnicaSxoContext(DbContextOptions<PruebaTecnicaSxoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductosFactura> ProductosFacturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-087EM09\\SQLEXPRESS;Database=PruebaTecnicaSxo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("idFactura");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.DocumentoCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentoCliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Iva).HasColumnName("iva");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.NumeroFactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroFactura");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.TipoDePago)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipoDePago")
                    .IsFixedLength(true);

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TotalDescuento).HasColumnName("totalDescuento");

                entity.Property(e => e.TotalImpuesto).HasColumnName("totalImpuesto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("idProducto");

                entity.Property(e => e.Producto1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("producto");
            });

            modelBuilder.Entity<ProductosFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Productos_factura");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_Productos_factura_Facturas");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Productos_factura_Productos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
