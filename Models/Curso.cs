using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cursoASP.Models
{
    public class Curso:ObjetoEscuelaBase
    {

        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

        //data anotations, sirven para validar los valores de los datos del modelo
        [Required(ErrorMessage = "nombre requerido")]
        [StringLength(10)]
        public override string Nombre { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Prompt = "Direccion correspondencia", Name = "Addres")]
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }
    }
}