﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemOneCoreCF.Models;

namespace SystemOneCoreCF.Migrations
{
    [DbContext(typeof(DBContexto))]
    [Migration("20200909235817_SystemOneCoreCF-Migration1")]
    partial class SystemOneCoreCFMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SystemOneCoreCF.Models.Categoria", b =>
                {
                    b.Property<int>("Idcategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idcategoria")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnName("descripcion")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<bool?>("Estado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Idcategoria");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("SystemOneCoreCF.Models.Producto", b =>
                {
                    b.Property<int>("Idproducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idproducto")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("codigo")
                        .HasColumnType("varchar(105)")
                        .HasMaxLength(105)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasColumnName("descripcion")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<bool?>("Estado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Idcategoria")
                        .HasColumnName("idcategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnName("precio_venta")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int>("Stock")
                        .HasColumnName("stock")
                        .HasColumnType("int");

                    b.HasKey("Idproducto");

                    b.HasIndex("Idcategoria");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("producto");
                });

            modelBuilder.Entity("SystemOneCoreCF.Models.Producto", b =>
                {
                    b.HasOne("SystemOneCoreCF.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("Idcategoria")
                        .HasConstraintName("FK_producto_categoria")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}