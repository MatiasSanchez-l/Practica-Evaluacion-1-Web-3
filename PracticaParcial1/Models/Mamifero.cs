using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PracticaParcial1.Models
{
    public class Mamifero
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Se debe completar la raza.")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "Se debe completar el color.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Se debe completar el numero.")]
        [CustomNumero(ErrorMessage = "peso debe solo tener numeros")]
        public string Peso { get; set; }

        public string mensajeMetodo { get; set; }

        public void respirar()
        {
            this.mensajeMetodo = "Puedo respirar";
        }

        public void caminar()
        {
            this.mensajeMetodo = "Puedo caminar";
        }

        public virtual void pensar()
        {
            this.mensajeMetodo = "Tengo un pensamiento basico instintivo";
        }


    }

    public class CustomNumero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }
            string campoDeTexto = value.ToString();
            string noCaracteresEspeciales = @"^(0|[1-9]\d*)(,\d+)?$";

            return Regex.IsMatch(campoDeTexto, noCaracteresEspeciales);

        }
    }
}
