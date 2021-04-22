using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public class Pago
    {
        [Key]
        [Display(Name = "Código")]
        public int IdPago { get; set; }
        [Display(Name = "Numero de Pago")]
        [Required]
        public int NumeroPago { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        [Required]
        public decimal Importe { get; set; }
       
        [Display(Name = "Numero de Contrato")]
        public int IdContrato { get; set; }
        [ForeignKey("ContratoId")]
        public Contrato Contrato { get; set; }
    }
}
