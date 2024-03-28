using System;
using System.Collections.Generic;
using Inventario_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Inventario_2.Migrations
{
    [DbContext(typeof(InventarioContext))]
    partial class InventarioContextModelSnapshot : ModelSnapshot
    {
        public ICollection<Articulo> Articulos { get; set; }

        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity<Almacene>(b =>
            {
                b.ToTable("Almacenes");
                b.Property<int>("IdAlmacenes")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", new object[] { 1, 1 });

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Estado")
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnType("varchar(8)");

                b.HasKey("IdAlmacenes")
                    .HasName("PK__Almacene__A56E336995113A9F");
            });

            modelBuilder.Entity<Articulo>(b =>
            {
                b.ToTable("Articulos");
                b.Property<int>("IdArticulos")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", new object[] { 1, 1 });

                b.Property<decimal>("CostoUnitario")
                    .HasColumnType("decimal(10, 2)");

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Estado")
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnType("varchar(8)");

                b.Property<int?>("IdInventario")
                    .HasColumnType("int");

                b.HasKey("IdArticulos")
                    .HasName("PK__Articulo__A1E947759EF05868");

                b.HasIndex("IdInventario");

                b.HasOne<TiposInventario>("IdInventarioNavigation")
                    .WithMany("Articulos")
                    .HasForeignKey("IdInventario")
                    .HasConstraintName("FK_TiposInventario");
            });

            modelBuilder.Entity<AsientoContable>(b =>
            {
                b.ToTable("AsientoContable");
                b.Property<int>("IdMovimiento")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", new object[] { 1, 1 });

                b.Property<int?>("Auxiliar")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasDefaultValueSql("((4))");

                b.Property<int>("CuentaCr")
                    .HasColumnType("int")
                    .HasColumnName("CuentaCR");

                b.Property<int>("CuentaDb")
                    .HasColumnType("int")
                    .HasColumnName("CuentaDB");

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<decimal?>("Monto")
                    .HasColumnType("decimal(10, 2)");

                b.HasKey("IdMovimiento")
                    .HasName("PK__AsientoC__881A6AE0DD6D7CF1");
            });

            modelBuilder.Entity<CuentaContable>(b =>
            {
                b.ToTable("CuentaContable");
                b.Property<int>("IdCuentaContable")
                    .HasColumnType("int");

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)");

                b.HasKey("IdCuentaContable")
                    .HasName("PK__CuentaCo__458CB9B223C1455F");
            });

            modelBuilder.Entity<TiposInventario>(b =>
            {
                b.ToTable("TiposInventario");
                b.Property<int>("IdInventario")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", new object[] { 1, 1 });

                b.Property<int>("CuentaContable")
                    .HasColumnType("int");

                b.Property<string>("Descripcion")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Estado")
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnType("varchar(8)");

                b.HasKey("IdInventario")
                    .HasName("PK__TiposInv__1927B20C54F04ACA");
            });

            modelBuilder.Entity<Transaccione>(b =>
            {
                b.ToTable("Transacciones");
                b.Property<int>("IdTransaccion")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", new object[] { 1, 1 });

                b.Property<int>("Cantidad")
                    .HasColumnType("int");

                b.Property<DateTime>("Fecha")
                    .HasColumnType("date");

                b.Property<int?>("IdArticulos")
                    .HasColumnType("int");

                b.Property<decimal?>("Monto")
                    .HasColumnType("decimal(10, 2)");

                b.Property<string>("TipoTransaccion")
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnType("varchar(7)");

                b.HasKey("IdTransaccion")
                    .HasName("PK__Transacc__334B1F77D762842D");

                b.HasIndex("IdArticulos");

                b.HasOne("Articulo", "IdArticulosNavigation")
                    .WithMany("Transacciones")
                    .HasForeignKey("IdArticulos")
                    .HasConstraintName("FK_Articulo");
            });

            modelBuilder.Entity<Articulo>(b =>
            {
                b.Navigation("Transacciones");
            });

            modelBuilder.Entity<TiposInventario>(b =>
            {
                b.Navigation("Articulos");
            });
        }
    }
}
