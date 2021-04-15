using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Proyecto_InmobiliariaVaras.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly RepositorioInmueble repositorioInmueble;
        private readonly RepositorioPropietario repositorioPropietario;
        private readonly IConfiguration configuration;

        public InmuebleController(IConfiguration configuration)
        {
            this.repositorioInmueble = new RepositorioInmueble(configuration);
            this.repositorioPropietario = new RepositorioPropietario(configuration);
            this.configuration = configuration;


        }
        // GET: InmuebleController
        public ActionResult Index()
        {
            try
            {
                IList<Inmueble> lista = repositorioInmueble.ObtenerTodos();
                ViewBag.Id = TempData["Id"];
                ViewData["Error"] = TempData["Error"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                return View(lista);
            }
            catch 
            {
                throw;
            }
        }

        // GET: InmuebleController/Details/5
        public ActionResult Details(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            return View(i);
        }

        // GET: InmuebleController/Create
        public ActionResult Create()
        {

            ViewBag.Propietario = repositorioPropietario.ObtenerTodos();
            return View();
        }

        // POST: InmuebleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble i)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    repositorioInmueble.Alta(i);
                    TempData["Id"] = i.IdInmueble;
                    TempData["Mensaje"] = "Alta de inmueble";

                    return RedirectToAction(nameof(Index));
            }
       
                else
            {
                ViewBag.Propietario = repositorioPropietario.ObtenerTodos();
                return View(i);
            }
        }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrace = ex.StackTrace;
                return View(i);
    }
}
// GET: InmuebleController/Edit/5
public ActionResult Edit(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            ViewBag.Propietario = repositorioPropietario.ObtenerTodos();
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: InmuebleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble i)
        {
            try
            {
                i.IdInmueble = id;
                repositorioInmueble.Modificar(i);
                TempData["Mensaje"] = "Los datos han sido modificados";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Propietario = repositorioPropietario.ObtenerTodos();
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(i);
            }
        }
        // GET: InmuebleController/Delete/5
        public ActionResult Delete(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            ViewBag.Error = TempData["Error"];
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: InmuebleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble i)
        {
            try
            {
                repositorioInmueble.Baja(id);
                TempData["Mensaje"] = "Inmueble eliminado";
                return RedirectToAction(nameof(Index));
            }
            catch (SqlException ex)
            {
                TempData["Error"] = ex.Number == 547 ? "No es posible eliminar este inmueble" : " Error";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(i);
            }
        }
    }
}
