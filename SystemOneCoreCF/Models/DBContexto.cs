using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOneCoreCF.Models
{
    public class DBContexto: DbContext
    {
        public DBContexto()
        {

        }

        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {

        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }


        //Este metodo nos ayudará a mapear las entidades de nuestra Base de Datos
        //Le mandamos un objeto que instancia la clase ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria> (entity => 
            {

                entity.ToTable("categoria");
                entity.HasKey(e => e.Idcategoria);
                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                //IsUnicode significa que el tipo de dato de almacenamiento será VARCHAR y no NVARCHAR
                .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(300)
                //IsUnicode significa que el tipo de dato de almacenamiento será VARCHAR y no NVARCHAR
                .IsUnicode(false);

                entity.Property(e => e.Estado)
                .HasColumnName("estado")
                .IsRequired()
                .HasDefaultValueSql("((1))");


                //----------------------------------------------------------------------------------

                modelBuilder.Entity<Producto>(entity =>
                {
                    entity.ToTable("producto");
                    entity.HasKey(e => e.Idproducto);
                    entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                    entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                    entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .IsRequired()
                    .HasMaxLength(105)
                    //IsUnicode significa que el tipo de dato de almacenamiento será VARCHAR y no NVARCHAR
                    .IsUnicode(false);

                    entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                    entity.HasIndex(e => e.Nombre)
                    .IsUnique();

                    entity.Property(e => e.PrecioVenta)
                    .HasColumnName("precio_venta")
                    .IsRequired()
                    .HasColumnType("decimal(12, 2)");

                    entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .IsRequired();

                    entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                    entity.Property(e => e.Estado)
                   .HasColumnName("estado")
                   .IsRequired()
                   .HasDefaultValueSql("((1))");

                    entity.HasOne(p => p.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(p => p.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_producto_categoria");
                });

            });
        }
    }
}
