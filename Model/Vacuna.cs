namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Vacuna")]
    public partial class Vacuna
    {
        public int Id { get; set; }

        [Display(Name = "Pentavalente Primera")]
        public bool? Ppri { get; set; }

        [Display(Name = "Pentavalente Segunda")]
        public bool? Pseg { get; set; }

        [Display(Name = "Pentavalente Tercera")]
        public bool? Pter { get; set; }

        [Display(Name = "Neumococica Primera")]
        public bool? Npri { get; set; }

        [Display(Name = "Neumococica Segunda")]
        public bool? Nseg { get; set; }

        [Display(Name = "Neumococica Tercera")]
        public bool? Nter { get; set; }

        [Display(Name = "OPV Primera")]
        public bool? Opvpri { get; set; }

        [Display(Name = "OPV Segunda")]
        public bool? Opvseg { get; set; }

        [Display(Name = "OPV Tercera")]
        public bool? Opvter { get; set; }

        [Display(Name = "Rotavirus Primera")]
        public bool? Rtpri { get; set; }

        [Display(Name = "Rotavirus Segunda")]
        public bool? Rtseg { get; set; }

        [Display(Name = "Influencia Estacional Pediatrica Primera")]
        public bool? Infpri { get; set; }

        [Display(Name = "Influencia Estacional Pediatrica Segunda")]
        public bool? Infseg { get; set; }

        [Display(Name = "Influencia Estacional Pediatrica Un d")]
        public bool? Infund { get; set; }

        [Display(Name = "Penta A")]
        public bool? Pentaym { get; set; }

        [Display(Name = "OPV A")]
        public bool? Opvaym { get; set; }

        [Display(Name = "Penta B")]
        public bool? Pentca { get; set; }
        [Display(Name = "OPV B")]
        public bool? Opvca { get; set; }

        public int? NinoId { get; set; }

        public virtual Nino Nino { get; set; }

        public List<Vacuna> Todo(int Nino)
        {
            
            var vacuna = new List<Vacuna>();
            try
            {
                using (var context = new ProyectoContext())
                {
                    vacuna = context.Vacuna.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return vacuna;
        }
        public List<Vacuna> Listar()
        {
            var vacunas = new List<Vacuna>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    vacunas = ctx.Vacuna.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vacunas;
        }
        public Vacuna Obtener(int id)
        {
            var vacuna = new Vacuna();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    vacuna = ctx.Vacuna.Where(x => x.Id == id)
                                .Include("Nino")
                                .Where(x => x.Id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vacuna;
        }
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


    }
}
