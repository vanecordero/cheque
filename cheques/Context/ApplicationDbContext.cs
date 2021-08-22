using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cheques.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<TB_Conceptos> TB_Conceptos { get; set; }
        public virtual DbSet<TB_Proveedores> TB_Proveedores { get; set; }
        public virtual DbSet<TB_Registrosolicitudcheque> TB_Registrosolicitudcheque { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_Conceptos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Conceptos>()
                .HasMany(e => e.TB_Registrosolicitudcheque)
                .WithRequired(e => e.TB_Conceptos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Proveedores>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Proveedores>()
                .Property(e => e.Tipo_Persona)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Proveedores>()
                .Property(e => e.Cedula_or_RNC)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Proveedores>()
                .HasMany(e => e.TB_Registrosolicitudcheque)
                .WithRequired(e => e.TB_Proveedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Registrosolicitudcheque>()
                .Property(e => e.estado_estatus)
                .IsUnicode(false);
        }
    }
}
