using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using cursoASP.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;

namespace cursoASP.Controllers
{
    public class AsignaturaController : Controller
    {

        //permite declarar una ruta para el metodo del controlador
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                                 where asig.Id == asignaturaId
                                 select asig;
                return asignatura.Any() ? View(asignatura.SingleOrDefault()) : View("MultiAsignatura", _context.Asignaturas.ToList());
            }
            else
                return View("MultiAsignatura", _context.Asignaturas.ToList());

        }

        public IActionResult MultiAsignatura()
        {
            // var asignatura = new Asignatura()
            // {
            //     Id = Guid.NewGuid().ToString(),
            //     Nombre = "Programacion"
            // };

            // var listaAsignaturas = new List<Asignatura>(){
            //             new Asignatura{Nombre="Matemáticas",
            //                 Id = Guid.NewGuid().ToString()
            //             } ,
            //             new Asignatura{Nombre="Educación Física",
            //                 Id = Guid.NewGuid().ToString()
            //             },
            //             new Asignatura{Nombre="Castellano",
            //                 Id = Guid.NewGuid().ToString()
            //             },
            //             new Asignatura{Nombre="Ciencias Naturales",
            //                 Id = Guid.NewGuid().ToString()
            //             },
            //             new Asignatura{Nombre="Programacion",
            //                 Id = Guid.NewGuid().ToString()
            //             }
            // };

            //bolsa dinamica de variables o datos dinamicos
            //ViewBag.Cosadinamica = "La Monja";
            //ViewBag.Fecha = DateTime.Now;
            //si no se especifica la vista, este regresa Index,
            //el parametro es un modelo de datos que se usa en la vista
            return View("MultiAsignatura", _context.Asignaturas.ToList());
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}