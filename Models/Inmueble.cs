using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public class Inmueble
    {
        [Display(Name = "Código")]
        public int IdInmueble { get; set; }
        [Required]
        public string DireccionInmueble { get; set; }
        [Required]
        public int Ambientes { get; set; }
        [Required]
        public int Superficie { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int Precio { get; set; }
        [Display(Name = "Dueño")]
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietario Duenio { get; set; }

    }
}

