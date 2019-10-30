using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agapea_MVC_NetCore.Interfaces;
using Agapea_MVC_NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Agapea_MVC_NetCore.Controllers
{
    public class PedidoController : Controller
    {
        private IDBAccess __accesoDB;

        //private IHttpContextAccessor __httpContext; // <---- se recibe la inyección por parte del DI

        public PedidoController(/*IHttpContextAccessor _httpContext,*/ IDBAccess objetoAccesoDB)
        {
            //this.__httpContext = _httpContext;

            this.__accesoDB = objetoAccesoDB;
        }


        public IActionResult Add(String id)
        {
            /*
                si necesitara pasar algo por QueryString utilizaría:
             String valor = HttpContext.Request.Query["_clave"].ToString;
             */


            Dictionary<Libro, int> dicLibros = new Dictionary<Libro, int>();
            List<Libro> listLibros;
            Libro libroNuevo = __accesoDB.DevolverLibroPorISBN(id);
            String cookieLibros = HttpContext.Session.GetString("Libros");

            if (cookieLibros == null)
            {
                //no hay pedido
                
                dicLibros.Add(libroNuevo, 1);
                listLibros = new List<Libro>(dicLibros.Keys);

                HttpContext.Session.SetString("Libros", JsonConvert.SerializeObject(listLibros));
            }
            else
            {

                listLibros = JsonConvert.DeserializeObject<List<Libro>>(cookieLibros);
                listLibros.Add(libroNuevo);

                //cargar diccionario
                dicLibros = this.cargarDiccionario(listLibros);

                HttpContext.Session.SetString("Libros", JsonConvert.SerializeObject(listLibros));

            }

            ViewBag.precioTotal = calcularPrecio(listLibros);
            return View("Carrito", dicLibros);
        }

        public IActionResult Decrease(String id)
        {
            Dictionary<Libro, int> dicLibros = new Dictionary<Libro, int>();
            List<Libro> listLibros;
            Libro libroABorrar = __accesoDB.DevolverLibroPorISBN(id);
            String cookieLibros = HttpContext.Session.GetString("Libros");

            if (cookieLibros!=null)
            {
                listLibros = JsonConvert.DeserializeObject<List<Libro>>(cookieLibros);

                listLibros.Reverse();
                listLibros.Remove(libroABorrar);
                listLibros.Reverse();

                //cargar diccionario
                dicLibros = this.cargarDiccionario(listLibros);

                ViewBag.precioTotal = calcularPrecio(listLibros);
                HttpContext.Session.SetString("Libros", JsonConvert.SerializeObject(listLibros));
                if (listLibros.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View("Carrito",dicLibros);
        }

        public IActionResult Drop(String id)
        {
            Dictionary<Libro, int> dicLibros = new Dictionary<Libro, int>();
            List<Libro> listLibros;
            Libro libroABorrar = __accesoDB.DevolverLibroPorISBN(id);
            String cookieLibros = HttpContext.Session.GetString("Libros");

            if (cookieLibros != null)
            {
                listLibros = JsonConvert.DeserializeObject<List<Libro>>(cookieLibros);
                
                while (listLibros.Remove(libroABorrar))
                {
                    listLibros.Remove(libroABorrar);
                }

                //cargar diccionario
                dicLibros = this.cargarDiccionario(listLibros);

                ViewBag.precioTotal = calcularPrecio(listLibros);
                HttpContext.Session.SetString("Libros", JsonConvert.SerializeObject(listLibros));
                if (listLibros.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Carrito", dicLibros);
        }


        #region "--- Metodos privados ---"

        private Dictionary<Libro,int> cargarDiccionario(List<Libro> listLibros)
        {

            Dictionary<Libro, int> dicLibros = new Dictionary<Libro, int>();

            foreach (Libro libro in listLibros)
            {
                if (dicLibros.ContainsKey(libro))
                {
                    dicLibros[libro] += 1;
                }
                else
                {
                    dicLibros.Add(libro, 1);
                }
            }

            return dicLibros;
        }


        private decimal calcularPrecio(List<Libro> listLibros)
        {
            decimal precio = 0;
            foreach (Libro libro in listLibros)
            {
                precio += libro.precio;
            }
            return precio;
        }


        #endregion
    }
}