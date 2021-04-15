﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto_InmobiliariaVaras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Controllers
{
    public class InquilinoController : Controller
    {
        private readonly RepositorioInquilino repositorio;
        private readonly IConfiguration configuration;

        public InquilinoController(IConfiguration configuration)
        {
            this.repositorio = new RepositorioInquilino(configuration);
            this.configuration = configuration;
        }

        // GET: PropietarioController
        public ActionResult Index()
        {
            IList<Inquilino> lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: InquilinoController/Details/5
        public ActionResult Details(int id)
        {
            var i = repositorio.ObtenerPorId(id);
            return View(i);
        }

        // GET: InquilinoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InquilinoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino i)
        {
            try
            {
                int res = repositorio.Alta(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: InquilinoController/Edit/5
        public ActionResult Edit(int id)
        {
            var i = repositorio.ObtenerPorId(id);
            i.Id = id;
            return View(i);
        }

        // POST: PropietarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, IFormCollection collection)
        {
            Inquilino i = null;
            try
            {
                i = repositorio.ObtenerPorId(id);
                i.Dni = collection["Dni"];
                i.Nombre = collection["Nombre"];
                i.Apellido = collection["Apellido"];
                i.DomicilioLaboral = collection["DomicilioLaboral"];
                i.Email = collection["Email"];
                i.NombreGarante = collection["NombreGarante"];
                i.DniGarante = collection["DniGarante"];
                i.TelefonoInquilino = collection["TelefonoInquilino"];
                i.NombreGarante = collection["NombreGarante"];
                i.DniGarante = collection["DniGarante"];
                i.TelefonoGarante = collection["TelefonoGarante"];

                repositorio.Modificar(i);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(i);
            }
        }

        // GET: InquilinoController/Delete/5
        public ActionResult Delete(int id)
        {
            var i = repositorio.ObtenerPorId(id);
            return View(i);
        }

        // POST: InquilinoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repositorio.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}