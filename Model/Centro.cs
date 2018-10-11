namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Centro")]
    public partial class Centro
    {
        public int id { get; set; }

        [StringLength(30)]
        public string departamento_c { get; set; }

        [StringLength(30)]
        public string provincia_c { get; set; }

        [StringLength(30)]
        public string municipio { get; set; }

        [StringLength(35)]
        public string est_salud_c { get; set; }

        [StringLength(35)]
        public string mes_c { get; set; }

        public int Conteo()
        {
            using (var ctx = new ProyectoContext())
            {
                return ctx.Centro.Count();
            }
        }
    }
}
