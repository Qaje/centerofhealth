namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Titular")]
    public partial class Titular
    {
        [Key]
        public int Idt { get; set; }

        [StringLength(50)]
        public string Ap_pat_t { get; set; }

        [StringLength(50)]
        public string Ap_mat_t { get; set; }

        [StringLength(50)]
        public string Ap_casad_t { get; set; }

        [StringLength(50)]
        public string Pri_nom_t { get; set; }

        [StringLength(50)]
        public string Seg_nom_t { get; set; }

        [StringLength(50)]
        public string Ter_nom_t { get; set; }

        [StringLength(20)]
        public string Ci_t { get; set; }

        [StringLength(20)]
        public string Expedido_t { get; set; }

        [Display(Name = "Fecha de NAcimiento")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? Fec_nac_t { get; set; }

        public int? Edad_t { get; set; }

        [Required]
        [StringLength(30)]
        public string Parentesco_t { get; set; }

        [StringLength(50)]
        public string Cel_t { get; set; }

        public int? NinoId { get; set; }

        public virtual Nino Nino { get; set; }
        //metodos
        public List<Titular> Listar()
        {
            var titulares = new List<Titular>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    titulares = ctx.Titular.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return titulares;
        }
        public List<Titular> Todos(int Nino_id=0)
        {
            var titulares = new List<Titular>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    titulares = ctx.Titular.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return titulares;
        }
        //obtener
        public Titular Obtener(int id)
        {
            var titular = new Titular();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    titular = ctx.Titular.Where(x => x.Idt == id)
                                  .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return titular;
        }
        public void Guardar()
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.Idt > 0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Entry(this).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
