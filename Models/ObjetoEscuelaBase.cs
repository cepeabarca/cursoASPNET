using System;

namespace cursoASP.Models
{
    public abstract class ObjetoEscuelaBase
    {
        //todo objeto tiene que tener una llave primaria 
        public string Id { get;  set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}