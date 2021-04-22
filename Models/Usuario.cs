using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public enum enRoles
    {
        Administrador = 1,
        Empleado = 2,

    }
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int Rol { get; set; }
        public string Avatar { get; set; }
        public IFormFile AvatarFile { get; set; }
        [NotMapped]
        public string RolNombre => Rol > 0 ? ((enRoles)Rol).ToString() : "";
        public static IDictionary<int, string> ObtenerRoles()
        {
            SortedDictionary<int, string> roles = new SortedDictionary<int, string>();
            Type tipoEnumRol = typeof(enRoles);
            foreach (var valor in Enum.GetValues(tipoEnumRol))
            {
                roles.Add((int)valor, Enum.GetName(tipoEnumRol, valor));
            }
            return roles;
        }

    }
}
