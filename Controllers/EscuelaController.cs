using System;
using Microsoft.AspNetCore.Mvc;
using cursoASP.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace cursoASP.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            // var escuela = new Escuela();
            // escuela.AñoDeCreación = 2005;
            // escuela.UniqueId = Guid.NewGuid().ToString();
            // escuela.Nombre = "Platzi School";
            // escuela.Ciudad = "Bogota";
            // escuela.Pais = "Colombia";
            // escuela.Dirección = "av. siempre viva";
            // escuela.TipoEscuela = TiposEscuela.Secundaria;
            // //bolsa dinamica de variables o datos dinamicos
             ViewBag.Cosadinamica = "La Monja";

            var escuela = _context.Escuelas.FirstOrDefault();
            //si no se especifica la vista, este regresa Index,
            //el parametro es un modelo de datos que se usa en la vista
            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}