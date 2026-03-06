using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.Models.ViewModels
{
    public class DeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}