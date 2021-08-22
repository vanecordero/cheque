namespace cheques.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Proveedores()
        {
            TB_Registrosolicitudcheque = new HashSet<TB_Registrosolicitudcheque>();
        }

        [Key]
        public int id_proveedor { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo_Persona { get; set; }

        [Required]
        [StringLength(50)]
        public string Cedula_or_RNC { get; set; }

        public int Balance { get; set; }

        public int Cuenta_contable_proveedor { get; set; }

        public bool Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Registrosolicitudcheque> TB_Registrosolicitudcheque { get; set; }
    }
}
