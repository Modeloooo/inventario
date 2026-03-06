using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.Models.ViewModels
{
    public class EditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Range(0.01, 100000)]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, 10000)]
        [Display(Name = "Cantidad en Stock")]
        public int Stock { get; set; }
    }
}