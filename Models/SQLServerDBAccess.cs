using Agapea_MVC_NetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class SQLServerDBAccess : IDBAccess
    {
        public Libro DevolverLibroPorISBN(string ISBN)
        {

            Libro libro = new Libro();
            try
            {
                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;
                __micomando.CommandText = "SELECT * FROM dbo.Libros WHERE ISBN=@isbn";
                __micomando.Parameters.Add("@isbn", SqlDbType.NChar);
                __micomando.Parameters["@isbn"].Value = ISBN;

                SqlDataReader __resultado = __micomando.ExecuteReader();


                while (__resultado.Read())
                {
                    libro.isbn = ((IDataRecord)__resultado)[0].ToString();
                    libro.isbn13 = ((IDataRecord)__resultado)[1].ToString();
                    libro.titulo = ((IDataRecord)__resultado)[2].ToString();
                    libro.editorial = ((IDataRecord)__resultado)[3].ToString();
                    libro.autor = ((IDataRecord)__resultado)[4].ToString();
                    libro.numeroDePaginas = System.Convert.ToInt32(((IDataRecord)__resultado)[5].ToString());
                    libro.precio = Convert.ToDecimal(((IDataRecord)__resultado)[6].ToString());
                    libro.imagen = ((IDataRecord)__resultado)[7].ToString();
                    libro.descripcion = ((IDataRecord)__resultado)[8].ToString();
                    libro.idMateria = System.Convert.ToInt32(((IDataRecord)__resultado)[9].ToString());
                    // ...
                }


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return libro;
        }

        public Dictionary<string, Libro> DevolverLibros(int id)
        {
            // manejando objetos de SQLClient, hacer select contra tabla Libros de DB-SqlServer

            // en el parámetro "id" se pasa el idMateria de los libros a mostrar....
            // http://localhost:xxx/home/LibrosDe/4
            // Que tengan como idMateria = 4 y pasarselos a la vista
            // Dictionary<String, Libro> _librosADevolver = new Dictionary<String, Libro>();
            try
            {
                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;
                __micomando.CommandText = "SELECT * FROM dbo.Libros WHERE IdMateria=@IdSub";
                __micomando.Parameters.Add("@IdSub", SqlDbType.Int);
                __micomando.Parameters["@IdSub"].Value = id;

                SqlDataReader __resultado = __micomando.ExecuteReader();

                // nos recorremos cursor para crearnos los libros
                Dictionary<String, Libro> __libros = new Dictionary<string, Libro>();
                /*hacer este bucle con LINQ*/

                while (__resultado.Read())
                {
                    Libro __filalibro = new Libro();
                    __filalibro.isbn = ((IDataRecord)__resultado)[0].ToString();
                    __filalibro.isbn13 = ((IDataRecord)__resultado)[1].ToString();
                    __filalibro.titulo = ((IDataRecord)__resultado)[2].ToString();
                    __filalibro.editorial = ((IDataRecord)__resultado)[3].ToString();
                    __filalibro.autor = ((IDataRecord)__resultado)[4].ToString();
                    __filalibro.numeroDePaginas = System.Convert.ToInt32(((IDataRecord)__resultado)[5].ToString());
                    __filalibro.precio = Convert.ToDecimal(((IDataRecord)__resultado)[6].ToString());
                    __filalibro.imagen = ((IDataRecord)__resultado)[7].ToString();
                    __filalibro.descripcion = ((IDataRecord)__resultado)[8].ToString();
                    __filalibro.idMateria = System.Convert.ToInt32(((IDataRecord)__resultado)[9].ToString());
                    // ...
                    __libros.Add(Convert.ToString(__filalibro.isbn), __filalibro);
                }


                __miconexion.Close();
                return __libros;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



        }

        public Dictionary<string, Libro> DevolverLibros(string materia)
        {

            try
            {

                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;
                __micomando.CommandText = "SELECT * FROM dbo.Libros where IdMateria = (select IdMateria from dbo.Materias where NombreMateria like '%;' + @Materia)";
                __micomando.Parameters.Add("@Materia", SqlDbType.NVarChar);
                __micomando.Parameters["@Materia"].Value = materia;

                SqlDataReader __resultado = __micomando.ExecuteReader();

                // nos recorremos cursor para crearnos los libros
                Dictionary<String, Libro> __libros = new Dictionary<string, Libro>();
                /*hacer este bucle con LINQ*/

                while (__resultado.Read())
                {
                    Libro __filalibro = new Libro();
                    __filalibro.isbn = ((IDataRecord)__resultado)[0].ToString();
                    __filalibro.isbn13 = ((IDataRecord)__resultado)[1].ToString();
                    __filalibro.titulo = ((IDataRecord)__resultado)[2].ToString();
                    __filalibro.editorial = ((IDataRecord)__resultado)[3].ToString();
                    __filalibro.autor = ((IDataRecord)__resultado)[4].ToString();
                    __filalibro.numeroDePaginas = System.Convert.ToInt32(((IDataRecord)__resultado)[5].ToString());
                    __filalibro.precio = Convert.ToDecimal(((IDataRecord)__resultado)[6].ToString());
                    __filalibro.imagen = ((IDataRecord)__resultado)[7].ToString();
                    __filalibro.descripcion = ((IDataRecord)__resultado)[8].ToString();
                    __filalibro.idMateria = System.Convert.ToInt32(((IDataRecord)__resultado)[9].ToString());
                    // ...
                    __libros.Add(Convert.ToString(__filalibro.isbn), __filalibro);
                }


                __miconexion.Close();
                return __libros;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public Dictionary<string, Libro> DevolverLibros(string opcion, string valor)
        {// manjenado objetos de SQLClient,  hacer SELECT contra
            // tabla Libros de BD-SqlServer

            try
            {
                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;

                if (opcion=="ISBN")
                {
                    __micomando.CommandText = "SELECT * FROM dbo.Libros WHERE " + opcion + "=@Isbn";
                    __micomando.Parameters.Add("@Isbn", SqlDbType.NChar);
                    __micomando.Parameters["@Isbn"].Value = valor;
                } else
                {
                    __micomando.CommandText = "SELECT * FROM dbo.Libros WHERE " + opcion + " LIKE '%' + @Valor + '%'";
                    __micomando.Parameters.Add("@Valor", SqlDbType.NVarChar);
                    __micomando.Parameters["@Valor"].Value = valor;
                }



                IEnumerable<KeyValuePair<String, Libro>> __libros = from fila in __micomando.ExecuteReader().Cast<IDataRecord>()
                                                                    let isbn = fila[0].ToString()
                                                                    let libro = new Libro()
                                                                    {
                                                                        isbn = fila[0].ToString(),
                                                                        isbn13 = fila[1].ToString(),
                                                                        titulo = fila[2].ToString(),
                                                                        editorial = fila[3].ToString(),
                                                                        autor = fila[4].ToString(),
                                                                        numeroDePaginas = System.Convert.ToInt16(fila[5]),
                                                                        precio = System.Convert.ToDecimal(fila[6]),
                                                                        descripcion = fila[8].ToString(),
                                                                        idMateria = System.Convert.ToInt16(fila[9])
                                                                    }
                                                                    select new KeyValuePair<String, Libro>(isbn, libro);

                Dictionary<String, Libro> __librosADevolver = __libros.ToDictionary(par => par.Key, par => par.Value);
                __miconexion.Close();

                return __librosADevolver;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /*public List<string> DevolverMaterias(int id = 0)
        {
            try
            {
                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;
                __micomando.CommandText = "select * from dbo.Materias where IdSubMateria = @Id";
                __micomando.Parameters.Add("@Id", SqlDbType.Int);
                __micomando.Parameters["@Id"].Value = id;

                SqlDataReader __resultado = __micomando.ExecuteReader();

                List<string> miList = new List<string>();
                //hacer este bucle con LINQ

                while (__resultado.Read())
                {
                    miList.Add(((IDataRecord)__resultado)[2].ToString());
                }

                __miconexion.Close();
                return miList;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        */


        public List<String> DevolverMaterias(int id)
        {
            try
            {
                SqlConnection __miconexion = new SqlConnection();
                __miconexion.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgapeaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                __miconexion.Open();

                SqlCommand __micomando = new SqlCommand();
                __micomando.Connection = __miconexion;
                __micomando.CommandType = CommandType.Text;
                __micomando.CommandText = "select * from dbo.Materias where IdMateriaPadre = @Id";
                __micomando.Parameters.Add("@Id", SqlDbType.Int);
                __micomando.Parameters["@Id"].Value = id;

                
                // sin LINQ
                SqlDataReader __resultado = __micomando.ExecuteReader();

                List<String> miList = new List<String>();

                while (__resultado.Read())
                {
                    String valor = ((IDataRecord)__resultado)[0].ToString() + ";" + ((IDataRecord)__resultado)[2].ToString();
                    miList.Add(valor);
                }

                
                // con LINQ
                /*
                List<String> miList = (from unafila in __micomando.ExecuteReader().Cast<IDataRecord>()
                                              let nombreMateria = ((IDataRecord)unafila)[2].ToString()
                                              select nombreMateria).ToList<String>();
                */

                __miconexion.Close();
                return miList;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
    
}
