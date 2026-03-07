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
            catch (Exception ex)
            {
                ViewBag.MensajeProceso = ex.InnerException?.InnerException?.Message ?? ex.Message;
                ViewBag.ValorMensaje = 0;

                return View(producto);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new InventarioContext())
            {
                var producto = db.Productos.Find(id);

                if (producto == null)
                {
                    return HttpNotFound();
                }

                var model = new EditViewModel
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock
                };

                return View(model);
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (var db = new InventarioContext())
                {
                    var producto = db.Productos.Find(model.Id);

                    if (producto == null)
                    {
                        return HttpNotFound();
                    }

                    producto.Nombre = model.Nombre;
                    producto.Descripcion = model.Descripcion;
                    producto.Precio = model.Precio;
                    producto.Stock = model.Stock;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeProceso = ex.Message;
                ViewBag.ValorMensaje = 0;

                return View(model);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new InventarioContext())
                {
                    var productoDB = db.Productos.FirstOrDefault(p => p.Id == id);

                    if (productoDB == null)
                        return HttpNotFound();

                    var producto = new Producto
                    {
                        Id = productoDB.Id,
                        Nombre = productoDB.Nombre,
                        Descripcion = productoDB.Descripcion,
                        Precio = productoDB.Precio,
                        Stock = productoDB.Stock
                    };

                    return View(producto);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Producto", "Delete"));
            }
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
