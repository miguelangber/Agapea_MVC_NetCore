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

        private IHttpContextAccessor __httpContext; // <---- se recibe la inyección por parte del DI

        public PedidoController(IHttpContextAccessor _httpContext, IDBAccess objetoAccesoDB)
        {
            this.__httpContext = _httpContext;

            this.__accesoDB = objetoAccesoDB;
        }



        public IActionResult AddLibro(String id)
        {

            Dictionary<Libro, int> misLibros;
            Libro libroNuevo = __accesoDB.DevolverLibroPorISBN(id);
            String libros = __httpContext.HttpContext.Session.GetString("Libros");

            Pedido _pedido;
            if (libros==null)
            {
                //no hay pedido
                _pedido = new Pedido();
                _pedido.libros = new Dictionary<Libro, int>();
                _pedido.libros.Add(libroNuevo,1);

                this.__httpContext.HttpContext.Session.SetString("Libros",JsonConvert.SerializeObject(_pedido.libros));
            }
            else
            {

                misLibros = JsonConvert.DeserializeObject<Dictionary<Libro, int>>(libros);

                bool _encontrado = false;
                foreach (KeyValuePair<Libro,int> LibroGuardado in misLibros)
                {
                    if (LibroGuardado.Key == libroNuevo)
                    {
                        _encontrado = true;
                        misLibros.Add(libroNuevo,LibroGuardado.Value+1);
                        break;
                    }
                }
            }

            return View("Carrito");
        }
    }
}