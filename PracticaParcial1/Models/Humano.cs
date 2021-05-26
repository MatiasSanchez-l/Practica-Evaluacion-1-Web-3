using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticaParcial1.Models
{
    public class Humano: Mamifero
    {
        [EmailAddress(ErrorMessage = "Formato de email incorrecto")]
        public string Email { get; set; }
        public override void pensar()
        {
            this.mensajeMetodo = "Tengo un pensamiento avanzado instintivo";
        }
    }
}
