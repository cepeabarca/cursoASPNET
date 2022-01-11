using System;

namespace cursoASP.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public string CursoId { get; set; }

        public Curso Curso { get; set; }
    }
}