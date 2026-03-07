using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Models
{
    public class Producto
    {
        public int Id { get; set; } //Clave primaria
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public bool Activo { get; set; }
    }
}