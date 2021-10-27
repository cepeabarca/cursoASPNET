using System;
using Microsoft.AspNetCore.Mvc;
using cursoASP.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;

namespace cursoASP.Controllers
{
    public class AsignaturaController : Controller
    {

        public IActionResult Index()
        {
            return View(new Asignatura{Nombre="Programacion",
                            UniqueId = Guid.NewGuid().ToString()});
        }

        public IActionResult MultiAsignatura()
        {
            var asignatura = new Asignatura()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Programacion"
            };

            var listaAsignaturas = new List<Asignatura>(){
                        new Asignatura{Nombre="Matemáticas",
                            UniqueId = Guid.NewGuid().ToString()
                        } ,
                        new Asignatura{Nombre="Educación Física",
                            UniqueId = Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Castellano",
                            UniqueId = Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Ciencias Naturales",
                            UniqueId = Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Programacion",
                            UniqueId = Guid.NewGuid().ToString()
                        }
            };

            //bolsa dinamica de variables o datos dinamicos
            //ViewBag.Cosadinamica = "La Monja";
            //ViewBag.Fecha = DateTime.Now;
            //si no se especifica la vista, este regresa Index,
            //el parametro es un modelo de datos que se usa en la vista
            return View("MultiAsignatura",listaAsignaturas);
        }
    }
}