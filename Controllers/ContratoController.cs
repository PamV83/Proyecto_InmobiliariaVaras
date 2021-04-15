using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto_InmobiliariaVaras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Controllers
{
    public class ContratoController : Controller
    {
        private readonly RepositorioContrato repositorioContrato;
        private readonly RepositorioInquilino repositorioInquilino;
        private readonly RepositorioInmueble repositorioInmueble;

        private readonly IConfiguration configuration;

        public ContratoController(IConfiguration configuration)
        {
            this.repositorioContrato = new RepositorioContrato(configuration);
            this.repositorioInmueble = new RepositorioInmueble(configuration);
            this.repositorioInquilino = new RepositorioInquilino(configuration);
            this.configuration = configuration;
        }


        // GET: ContratoController
        public ActionResult Index()
        {
            IList<Contrato> lista = repositorioContrato.ObtenerTodos();
            ViewBag.Id = TempData["Id"];
            ViewData["Error"] = TempData["Error"];
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            return View(lista);
        }

        // GET: ContratoController/Details/5
        public ActionResult Details(int id)
        {
            var c = repositorioContrato.ObtenerPorId(id);
            return View(c);
        }

        // GET: ContratoController/Create
        public ActionResult Create()
        {
            ViewBag.Inquilino = repositorioInquilino.ObtenerTodos();
            ViewBag.Inmueble = repositorioInmueble.ObtenerTodos();
            return View();
        }

        // POST: ContratoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorioContrato.Alta(c);
                    TempData["Id"] = c.IdContrato;
                    TempData["Mensaje"] = "Contrato creado";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Inquilino = repositorioInquilino.ObtenerTodos();
                    ViewBag.Inmueble = repositorioInmueble.ObtenerTodos();
                    return View(c);
                }
            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(c);
            }
        }

        // GET: ContratoController/Edit/5
        public ActionResult Edit(int id)
        {
            var c = repositorioContrato.ObtenerPorId(id);
            ViewBag.Inquilino = repositorioInquilino.ObtenerTodos();
            ViewBag.Inmueble = repositorioInmueble.ObtenerTodos();
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(c);
        }

        // POST: ContratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato c)
        {
            try
            {
                c.IdContrato = id;
                repositorioContrato.Modificar(c);
                TempData["Mensaje"] = "Los datos han sido modificados";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Inquilino = repositorioInquilino.ObtenerTodos();
                ViewBag.Inmueble = repositorioInmueble.ObtenerTodos();
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(c);
            }
        }

        // GET: ContratoController/Delete/5
        public ActionResult Delete(int id)
        {
            var c = repositorioContrato.ObtenerPorId(id);

            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(c);
        }

        // POST: ContratoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contrato c)
        {
            try
            {
                repositorioContrato.Baja(id);
                TempData["Mensaje"] = "El contrato ha sido eliminado";
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(c);
            }
        }
    }
}