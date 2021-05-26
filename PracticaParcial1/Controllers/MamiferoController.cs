using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaParcial1.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PracticaParcial1.Controllers
{
    public class MamiferoController : Controller
    {
        public static List<Mamifero> mamiferos= new List<Mamifero>();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Nombre)
        {
            HttpContext.Session.SetString("nombre",JsonConvert.SerializeObject(Nombre));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult cerrarSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult crearHumano()
        {
            return View();
        }
        [HttpPost]
        public IActionResult crearHumano(Humano humano)
        {
            if (!ModelState.IsValid)
            {
                return View(humano);
            }

            if (mamiferos.Count == 0)
            {
                humano.Id = 1;
            }
            else
            {
                humano.Id = mamiferos.Max(o => o.Id) + 1;
            }
            mamiferos.Add(humano);
            return RedirectToAction("listaMamiferos");
        }

        public IActionResult crearArdilla()
        {
            return View();
        }

        [HttpPost]
        public IActionResult crearArdilla(Ardilla humano)
        {
            return View();
        }

        public IActionResult crearMono()
        {
            return View();
        }

        [HttpPost]
        public IActionResult crearMono(Mono humano)
        {
            return View();
        }

        public IActionResult listaMamiferos()
        {
            return View();
        }

    }
}
