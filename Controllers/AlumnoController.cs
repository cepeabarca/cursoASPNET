using System;
using Microsoft.AspNetCore.Mvc;
using cursoASP.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace cursoASP.Controllers
{
    public class AlumnoController : Controller
    {

        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos
                                 where alum.Id == id
                                 select alum;
                return alumno.Any() ? View(alumno.SingleOrDefault()) : View("MultiAlumno", _context.Alumnos.ToList());
            }
            else
                return View("MultiAlumno", _context.Alumnos.ToList());
        }

        public IActionResult MultiAlumno()
        {

            // var listaAlumno = GenerarAlumnosAlAzar();

            //bolsa dinamica de variables o datos dinamicos
            //ViewBag.Cosadinamica = "La Monja";
            //ViewBag.Fecha = DateTime.Now;
            //si no se especifica la vista, este regresa Index,
            //el parametro es un modelo de datos que se usa en la vista
            return View("MultiAlumno",_context.Alumnos);
        }

        // private List<Alumno> GenerarAlumnosAlAzar()
        // {
        //     string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        //     string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        //     string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        //     var listaAlumnos = from n1 in nombre1
        //                        from n2 in nombre2
        //                        from a1 in apellido1
        //                        select new Alumno { Nombre = $"{n1} {n2} {a1}" };

        //     return listaAlumnos.OrderBy((al) => al.Id).ToList();
        // }

        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}