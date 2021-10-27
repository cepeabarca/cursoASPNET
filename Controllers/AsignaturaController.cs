using System;
using Microsoft.AspNetCore.Mvc;
using cursoASP.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace cursoASP.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura(){
                UniqueId =Guid.NewGuid().ToString(),
                Nombre = "Programacion"
            };

            //bolsa dinamica de variables o datos dinamicos
            ViewBag.Cosadinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            //si no se especifica la vista, este regresa Index,
            //el parametro es un modelo de datos que se usa en la vista
            return View(asignatura);
        }
    }
}