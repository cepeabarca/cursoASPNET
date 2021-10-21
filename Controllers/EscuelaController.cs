using System;
using Microsoft.AspNetCore.Mvc;

namespace cursoASP.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoFundacion =2005;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            
            //si no se especifica la vista, este regresa Index,
            //el parametro es un modelo de datos que se usa en la vista
            return View(escuela);
        }
    }
}