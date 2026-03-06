using Inventario.Data;
using Inventario.Models;
using Inventario.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            try
            {
                using (var db = new InventarioContext())
                {
                    var productos = db.Productos.Select(p => new Models.ViewModels.IndexViewModel
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                        Stock = p.Stock
                    }).ToList();

                    return View(productos);
                }
            }
            catch (Exception)
            {
                return View(new List<Models.ViewModels.IndexViewModel>());
            }
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Producto producto = new Producto();

                using (var db = new InventarioContext())
                {
                    var productoDB = db.Productos.FirstOrDefault(p => p.Id == id);

                    if (productoDB != null)
                    {
                        producto.Id = productoDB.Id;
                        producto.Nombre = productoDB.Nombre;
                        producto.Descripcion = productoDB.Descripcion;
                        producto.Precio = productoDB.Precio;
                        producto.Stock = productoDB.Stock;
                    }

                    return View(producto);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Producto", "Details"));
            }
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(CreateViewModel producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(producto);
                }

                using (var db = new InventarioContext())
                {
                    var nuevoProducto = new Producto
                    {
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Precio = producto.Precio,
                        Stock = producto.Stock
                    };

                    db.Productos.Add(nuevoProducto);
                    db.SaveChanges();

                    ViewBag.MensajeProceso = "Producto agregado exitosamente";
                    ViewBag.ValorMensaje = 1;
                }

                return View(producto);
            }
            catch
            {
                ViewBag.MensajeProceso = "Error al crear el producto";
                ViewBag.ValorMensaje = 0;

                return View(producto);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Producto producto = new Producto();

                using (var db = new InventarioContext())
                {
                    var productoDB = db.Productos.FirstOrDefault(p => p.Id == id);

                    if (productoDB != null)
                    {
                        producto.Id = productoDB.Id;
                        producto.Nombre = productoDB.Nombre;
                        producto.Descripcion = productoDB.Descripcion;
                        producto.Precio = productoDB.Precio;
                        producto.Stock = productoDB.Stock;
                    }

                    return View(producto);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Producto", "Edit"));
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditViewModel producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(producto);
                }

                using (var db = new InventarioContext())
                {
                    var productoDB = db.Productos.FirstOrDefault(p => p.Id == producto.Id);

                    if (productoDB != null)
                    {
                        productoDB.Nombre = producto.Nombre;
                        productoDB.Descripcion = producto.Descripcion;
                        productoDB.Precio = producto.Precio;
                        productoDB.Stock = producto.Stock;

                        db.Entry(productoDB).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        ViewBag.MensajeProceso = "Producto editado exitosamente";
                        ViewBag.ValorMensaje = 1;
                    }

                    return View(producto);
                }
            }
            catch
            {
                ViewBag.MensajeProceso = "Error al editar el producto";
                ViewBag.ValorMensaje = 0;

                return View(producto);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new InventarioContext())
                {
                    var producto = db.Productos.FirstOrDefault(p => p.Id == id);

                    if (producto != null)
                    {
                        db.Productos.Remove(producto);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
