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
        public IActionResult crearArdilla(Ardilla ardilla)
        {
            if (!ModelState.IsValid)
            {
                return View(ardilla);
            }

            if (mamiferos.Count == 0)
            {
                ardilla.Id = 1;
            }
            else
            {
                ardilla.Id = mamiferos.Max(o => o.Id) + 1;
            }
            mamiferos.Add(ardilla);
            return RedirectToAction("listaMamiferos");
        }

        public IActionResult crearMono()
        {
            return View();
        }

        [HttpPost]
        public IActionResult crearMono(Mono mono)
        {
            if (!ModelState.IsValid)
            {
                return View(mono);
            }

            if (mamiferos.Count == 0)
            {
                mono.Id = 1;
            }
            else
            {
                mono.Id = mamiferos.Max(o => o.Id) + 1;
            }
            mamiferos.Add(mono);
            return RedirectToAction("listaMamiferos");
        }

        public IActionResult listaMamiferos()
        {

            return View(mamiferos);
        }

        public IActionResult VerDetalle(int Id)
        {
            if (Id == null)
            {
                return RedirectToAction("listaMamiferos");
            }
            ViewData["mamifero"] = mamiferos.FirstOrDefault(o => o.Id == Id);
            return View();
        }

        public IActionResult HacerAccion(int Id, string Accion)
        {
            if (Id == null || Accion == null)
            {
                return RedirectToAction("listaMamiferos");
            }
            Mamifero mamifero = mamiferos.FirstOrDefault(o => o.Id == Id);
            if (Accion == "respirar")
            {
                mamifero.respirar();
            }

            if (Accion == "caminar")
            {
                mamifero.caminar();
            }

            if (Accion == "pensar")
            {
                mamifero.pensar();
            }
            ViewData["mamifero"] = mamifero;
            return View("VerDetalle");
        }

    }
}
