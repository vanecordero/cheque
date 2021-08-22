namespace cheques.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Conceptos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Conceptos()
        {
            TB_Registrosolicitudcheque = new HashSet<TB_Registrosolicitudcheque>();
        }

        [Key]
        public int id_Identificador { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Registrosolicitudcheque> TB_Registrosolicitudcheque { get; set; }
    }
}
