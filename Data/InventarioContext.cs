using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventario.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext() : base("InventarioContext")
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }
}