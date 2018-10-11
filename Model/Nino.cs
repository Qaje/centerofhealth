namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("Nino")]
    public partial class Nino
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nino()
        {
            Titular = new HashSet<Titular>();
            Vacuna = new HashSet<Vacuna>();
        }

        public int Id { get; set; }

        public int? Nro_formulario { get; set; }

        [StringLength(20)]
        public string Nro_dec_jur { get; set; }

        [StringLength(20)]
        public string Primer_apellido { get; set; }

        [StringLength(20)]
        public string Segundo_apellido { get; set; }

        [StringLength(20)]
        public string Primer_nombre { get; set; }

        [StringLength(20)]
        public string Segundo_nombre { get; set; }

        [StringLength(20)]
        public string Tercer_nombre { get; set; }


        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? Fec_nac { get; set; }

        public int? Oficialia { get; set; }

        [StringLength(10)]
        public string Libro { get; set; }

        public int? Año { get; set; }

        public int? Partida { get; set; }

        public int? Folio { get; set; }

        [StringLength(5)]
        public string Sexo { get; set; }

        [Display(Name = "Fecha_control")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? Fecha_control{ get; set; }

        [Display(Name = "Fecha_incripcion_sis")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? Fecha_inscripcion_sis {
            get { return DateTime.Now; }
            set { this.Fecha_control = value; }
        }

        [Display(Name = "Fecha_inscripcion_pro")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime? Fecha_inscripcion_pro {
            get { return DateTime.Now; }
            set { this.Fecha_control = value; }
        }

        public int? Edad { get; set; }

        [StringLength(50)]
        public string Numero_control { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Titular> Titular { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacuna> Vacuna { get; set; }
        //listar
        public List<Nino> Listar()
        {
            var ninos = new List<Nino>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ninos = ctx.Nino.ToList();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return ninos;
        }
        //obtener
        public Nino Obtener(int id)
        {
            var nino = new Nino();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    nino = ctx.Nino.Where(x => x.Id == id)
                                .Include("Titular")
                                .Where(x => x.Id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return nino;
        }
        /*
        public void Guardar()
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.Id > 0)
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
        */

        public void Guardar()
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.Id == 0)
                    {
                        ctx.Entry(this).State = EntityState.Added;
                    }
                    else
                    {
                        ctx.Database.ExecuteSqlCommand(
                            "Delete from Vacuna where NinoId=@id",
                            new SqlParameter("Id",this.Id)
                            );
                        var vacunaBK = this.Vacuna;

                        this.Vacuna = null;
                        ctx.Entry(this).State = EntityState.Modified;
                        this.Vacuna = vacunaBK;
                    }

                    foreach (var c in this.Vacuna)
                        ctx.Entry(c).State = EntityState.Unchanged;

                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
