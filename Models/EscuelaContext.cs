using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace cursoASP.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas {get; set;}

        public DbSet<Asignatura> Asignaturas {get; set;}

        public DbSet<Curso> Cursos {get; set;}

        public DbSet<Alumno> Alumnos {get; set;}

        public DbSet<Evaluación> Evaluaciones {get; set;}

        public EscuelaContext (DbContextOptions<EscuelaContext> options): base(options)  
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "av. siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;


            //cargar cursos de la escuela
            var cursos = CargarCursos(escuela);

            //xcada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            // modelBuilder.Entity<Asignatura>().HasData(
            //       new Asignatura{Nombre="Matemáticas",
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
            //);
            //hasdata pide si o si un array
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad, Curso curso)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno 
                               { 
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id =Guid.NewGuid().ToString()
                                };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso{
                            EscuelaId = escuela.Id,
                            Nombre = "101",
                            Jornada = TiposJornada.Mañana,
                            Dirección = "avenida cienfuegos" },
                        new Curso{EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana, Dirección = "avenida cienfuegos"},
                        new Curso{EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana, Dirección = "avenida cienfuegos"},
                        new Curso{EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde, Dirección = "avenida cienfuegos"},
                        new Curso{EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde, Dirección = "avenida cienfuegos"},
            };
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura> ();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> {
                            new Asignatura{
                                CursoId = curso.Id,
                                Nombre="Matemáticas"} ,
                            new Asignatura{ CursoId = curso.Id, Nombre="Educación Física"},
                            new Asignatura{ CursoId = curso.Id, Nombre="Castellano"},
                            new Asignatura{ CursoId = curso.Id, Nombre="Ciencias Naturales"},
                            new Asignatura{ CursoId = curso.Id, Nombre="Programación"}

                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(cantRandom, curso);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

    }
}