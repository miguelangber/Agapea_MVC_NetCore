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

namespace Agapea_MVC_NetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LibrosDe(int id)
        {
            // en el parámetro "id" se pasa el idMateria de los libros a mostrar....
            // http://localhost:xxx/home/LibrosDe/4
            // Que tengan como idMateria = 4 y pasarselos a la vista
            try
            {
                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;
                __micomando.CommandText = "SELECT * FROM dbo.Materias WHERE IdSubMateria=@IdSub";
                __micomando.Parameters.Add("@IdSub", SqlDbType.Int);
                __micomando.Parameters["@IdSub"].Value = id;

                SqlDataReader __resultado = __micomando.ExecuteReader();

                // nos recorremos cursor para crearnos los libros
                Dictionary<String, Libro> __libros = new Dictionary<string, Libro>();
                while (__resultado.Read())
                {
                    Libro __filalibro = new Libro();
                    __filalibro.sAutor = ((IDataRecord)__resultado)[0].ToString();
                    __filalibro.sTitulo = ((IDataRecord)__resultado)[1].ToString();
                    //__filalibro.iIsbn = ((IDataRecord)__resultado)[2].ToString();
                    // ...
                }

                __miconexion.Close();
                return View(__libros);
            }
            catch (Exception e)
            {

                throw;
            }


            return View();

        }
    }
}



