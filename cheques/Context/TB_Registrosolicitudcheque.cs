namespace cheques.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Registrosolicitudcheque
    {
        [Key]
        public int id_solicitud { get; set; }
        [Display(Name = "Proveedor")]

        
        public int id_proveedor { get; set; }

        [Display(Name = "Concepto Cheque")]
        public int id_identificador { get; set; }

        [Display(Name = "Monto")]
        public int monto { get; set; }

        [Display(Name = "Fecha")]
        [Column(TypeName = "date")]
        public DateTime fecha_registro { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Estatus de la solicitud")]

        public string estado_estatus { get; set; }

        [Display(Name = "Cuenta Proveedor", Prompt = "ingrese numero de ceunta bancario", Description = "Cuenta bancaria")]
        public int cuenta_contable_proveedor { get; set; }

        [Display(Name = "Cuenta empresa")]
        public int cuenta_empresa { get; set; }

        public int? id_asiento { get; set; }

        public virtual TB_Conceptos TB_Conceptos { get; set; }

        public virtual TB_Proveedores TB_Proveedores { get; set; }
    }
}
