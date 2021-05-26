using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaParcial1.Models
{
    public class Mono: Mamifero
    {
        public override void pensar()
        {
            this.mensajeMetodo = "Tengo un pensamiento medio instintivo";
        }
    }
}
