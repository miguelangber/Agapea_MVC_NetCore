using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agapea_MVC_NetCore.Models;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Agapea_MVC_NetCore.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Agapea_MVC_NetCore.Controllers
{
    public class HomeController : Controller
    {
        // inyecto en el contructor un objeto que implemente interface IDBAccess: objetoAccesoBD
        //ese objeto va a ser acesivle a todos los metodos de accion de mi controlador por variavle privada: __accesoDB

        private IDBAccess __accesoDB;
        public HomeController(IDBAccess objetoAccesoDB) 
        {
            this.__accesoDB = objetoAccesoDB;
        }

        public IActionResult Prueba()
        {
            
            //ViewData["fecha"] = DateTime.Now;
            //ViewData["libro"] = new Libro() { titulo="vamos ya", autor="yo mismo"};
            //ViewData["promocion"] = "rebajas de navidad";
            return View();
            
            /*
            ViewBag.fecha = DateTime.Now;
            ViewBag.libro = new Libro() { titulo = "vamosya", autor = "puesyo" };
            ViewBag.promocion = "rebajas de navidad";

            return View();
            */
        }



        #region "metodos de accion del controlador"





        public IActionResult Index()
        {
            int id = System.Convert.ToInt16(RouteData.Values["id"]);
            //ViewData["materias"] = this.__accesoDB.DevolverMaterias(0);

            IQueryCollection parametros = HttpContext.Request.Query;
            if (parametros.Count != 0)
            {
                String materia = parametros["materia"].ToString();
                return View(this.__accesoDB.DevolverLibros(materia));

            }
            else
            {
                return View(this.__accesoDB.DevolverLibros(id));
            }
        }

        public IActionResult MuestraLibro (String id)
        {
            //recuperar de la BD el objeto libro con ese id... y pasarselo a la vista
            //Libro LibroEncontrado = from unlibro in List

            //ViewData["materias"] = this.__accesoDB.DevolverMaterias(0);
            Libro _libro = __accesoDB.DevolverLibroPorISBN(id);
            return View("MuestraLibro",_libro);
        }


        public IActionResult Buscar(/*String opcion, String valor */)
        {
            /*  //si paso valores por queryString sin tener ruta definida
                String opcion = this.HttpContext.Request.Query["opcion"].ToString();
                String valor = this.HttpContext.Request.Query["valor"].ToString();
            */


            //paso valores por segmentos en rta defnida... 
            String opcion = RouteData.Values["opcion"].ToString();
            String valor = RouteData.Values["valor"].ToString();
            return View("Index", this.__accesoDB.DevolverLibros(opcion, valor));


        }



        #endregion
    }
}



