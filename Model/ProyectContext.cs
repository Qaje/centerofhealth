namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProyectoContext : DbContext
    {
        public ProyectoContext()
            : base("name=ProyectoContext")
        {
        }

        public virtual DbSet<Centro> Centro { get; set; }
        public virtual DbSet<Nino> Nino { get; set; }
        public virtual DbSet<Titular> Titular { get; set; }
        public virtual DbSet<Vacuna> Vacuna { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centro>()
                .Property(e => e.departamento_c)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.provincia_c)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.municipio)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.est_salud_c)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.mes_c)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Nro_dec_jur)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Primer_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Segundo_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Primer_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Segundo_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Tercer_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Libro)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Nino>()
                .Property(e => e.Numero_control)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Ap_pat_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Ap_mat_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Ap_casad_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Pri_nom_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Seg_nom_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Ter_nom_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Ci_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Expedido_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Parentesco_t)
                .IsUnicode(false);

            modelBuilder.Entity<Titular>()
                .Property(e => e.Cel_t)
                .IsUnicode(false);
        }
    }
}
