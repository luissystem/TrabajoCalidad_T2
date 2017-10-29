using Entidades;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AutoController : Controller
    {
        private IAutoService service;
        public AutoController(IAutoService service)
        {
            this.service = service;
        }
      
        

        [HttpGet]
        public ActionResult Index(String Marca, String Color, Int32? Anio, String Estado, double? PrecioMinimo, double? PrecioMaximo)
        {
            var auto = service.getAuto(Marca, Color, Anio, Estado, PrecioMinimo, PrecioMaximo);



            // ViewBag.a= new SelectList(au, "Id", "Marca");
            return View(auto);
        }
        [HttpPost]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Auto autos)
        {
            EjecutarValidaciones(autos);
            if (ModelState.IsValid)
            {
                service.add(autos);
                
                return RedirectToAction("Index");
            }

            return View("crear", autos);
           
        }
        private void EjecutarValidaciones(Auto autos)
        {
            if (string.IsNullOrEmpty(autos.Marca))
                ModelState.AddModelError("Marca", "Marca es obligatorio");

            if (string.IsNullOrEmpty(autos.Color))
                ModelState.AddModelError("Color", "Color es obligatorio");

            if (autos.Año <= 1000)
                ModelState.AddModelError("Año", "Año es obligatorio");

            if (string.IsNullOrEmpty(autos.Estado))
                ModelState.AddModelError("Estado", "Estado es obligatorio");


            if (autos.Precio <= 0)
                ModelState.AddModelError("Precio", "Precio es obligatorio y debe ser mayor a 0");
        }
    }
}