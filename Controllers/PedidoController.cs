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

        #region Metodos de accion

        public IActionResult Carrito(String id)
        {
            try
            {
                //id contiene el isbn del libro ademas de la accion a realizar en el pedido
                String isbn = id.Split("_")[0];
                String accion = id.Split("_")[1].ToLower();

                // aquí está la chicha, Se reciben las cookies, se cargan en una lista, se actualiza y se devuelve al contexto
                List<Libro> listLibros = this.actualizarPedido(isbn, accion);

                // aqui se carga la lista en un diccionario
                Dictionary<Libro, int> dicLibro = this.cargarDiccionario(listLibros);

                // variable para recibir en la view el precio total del pedido
                ViewBag.precioTotal = calcularPrecio(listLibros);

                // si la lista esta vacia se envia al usuario a la página inicial
                if (listLibros.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Carrito", dicLibro);
                }
            }
            catch (Exception e)
            {
                // si en algun momento salta una expción, no se carga nada y se envía al usuario a la página inicial
                return RedirectToAction("Index", "Home");
            }
        }


        #endregion


        #region Metodos privados

        private List<Libro> actualizarPedido(String isbn, String accion)
        {
            Dictionary<Libro, int> dicLibros = new Dictionary<Libro, int>();
            List<Libro> listLibros;
            Libro libro = __accesoDB.DevolverLibroPorISBN(isbn);
            String cookieLibros = HttpContext.Session.GetString("Libros");

            if (cookieLibros == null)
            {

                // aún no hay libros en las cookies
                dicLibros.Add(libro, 1);
                listLibros = new List<Libro>(dicLibros.Keys);

                HttpContext.Session.SetString("Libros", JsonConvert.SerializeObject(listLibros));

            }
            else
            {
                // ya hay libros en las cookies
                listLibros = JsonConvert.DeserializeObject<List<Libro>>(cookieLibros);

                switch (accion)
                {
                    case "add":

                        listLibros.Add(libro);

                        break;

                    case "dec":

                        // esto borra solo al ultimo de la lista, para no alterar el orden de los libros en el carrito
                        listLibros.Reverse();
                        listLibros.Remove(libro);
                        listLibros.Reverse();

                        break;

                    case "drop":

                        // hago un bucle por que no he encontrado otra forma de borrar de la lista todas las instancias de un libro
                        while (listLibros.Remove(libro))
                        {
                            listLibros.Remove(libro);
                        }

                        break;
                }
                HttpContext.Session.SetString("Libros", JsonConvert.SerializeObject(listLibros));
            }

            return listLibros;

        }


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