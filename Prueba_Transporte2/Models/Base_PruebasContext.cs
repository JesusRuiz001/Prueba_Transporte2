using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba_Transporte2.Models
{
    public partial class Base_PruebasContext : DbContext
    {
        public Base_PruebasContext()
        {
        }

        public Base_PruebasContext(DbContextOptions<Base_PruebasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bodega> Bodegas { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Envio> Envios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
   //             optionsBuilder.UseSqlServer("Server=localhost; database=Base_Pruebas;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.ToTable("Bodega");

                entity.Property(e => e.BodegaId)
                    .ValueGeneratedNever()
                    .HasColumnName("BodegaID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClienteID");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.ToTable("Envio");

                entity.Property(e => e.EnvioId)
                    .ValueGeneratedNever()
                    .HasColumnName("EnvioID");

                entity.Property(e => e.BodegaId).HasColumnName("BodegaID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.NumeroGuia)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioEnvio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioEnvioNeto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.BodegaId)
                    .HasConstraintName("FK_Envio_Bodega");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Envio_Cliente");

                entity.HasOne(d => d.PlacaNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.Placa)
                    .HasConstraintName("FK_Envio_Vehiculo");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_Envio_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductoID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValorUnit).HasColumnName("valorUnit");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Placa)
                    .HasName("PK__Vehiculo__8310F99C52353BE1");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVehiculo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
