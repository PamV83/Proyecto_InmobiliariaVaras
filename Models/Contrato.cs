using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public class Contrato
    {
        [Display(Name = "Código")]
        public int IdContrato { get; set; }
        [Required]
        public DateTime FechaIn { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public int Importe { get; set; }
        [Display(Name = "Inquilino")]
        public int IdInquilino { get; set; }

        public Inquilino Inquilino { get; set; }
        [Display(Name = "Inmueble")]
        public int IdInmueble { get; set; }

        public Inmueble Inmueble { get; set; }

    }
}
