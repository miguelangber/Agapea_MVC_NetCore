using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Libro
    {
        #region "...propiedades de la clase..."
        private String _titulo;
        private String _autor;
        private String _editorial;
        private String _imagen;
        private int _numeroDePaginas;
        private int _isbn;
        private int _isbn13;
        private DateTime _fechaDeEdicion;
        private int _precio;


        public String titulo { get { return _titulo; } set { this._titulo = value; } }
        public String autor { get { return _autor; } set { this._autor = value; } }
        public String editorial  { get { return _editorial; } set { this._editorial = value; } }
        public String imagen  { get { return _imagen; } set { this._imagen = value; } }
        public int numeroDePaginas  { get { return _numeroDePaginas; } set { this._numeroDePaginas = value; } }
        public int isbn  { get { return _isbn; } set { this._isbn = value; } }
        public int isbn13  { get { return _isbn13; } set { this._isbn13 = value; } }
        public DateTime fechaDeEdicion  { get { return _fechaDeEdicion; } set { this._fechaDeEdicion = value; } }
        public int precio  { get { return _precio; } set { this._precio = value; } }


        #endregion

        #region "...métodos de la clase..."
        #region "...Métodos privados..."
        #endregion

        #region "...Métodos públicos..."
        #region "...Contrusctores..."
        public Libro()
        {

        }
        public Libro(String sTitulo, 
                     String sAutor, 
                     String sEditorial , 
                     int iIsbn, 
                     int iIsbn13, 
                     int iPrecio, 
                     DateTime dFechaDeEdicion, 
                     String sImagen, 
                     int iNumeroDePaginas
                     )
        {
            this.titulo = sTitulo;
            this.autor = sAutor;
            this.editorial = sEditorial;
            this.isbn = iIsbn;
            this.isbn13 = iIsbn13;
            this.precio = iPrecio;
            this.fechaDeEdicion = dFechaDeEdicion;
            this.imagen = sImagen;
            this.numeroDePaginas = iNumeroDePaginas;
        }
        #endregion
        #region "...Métodos publicos de clase..."

        #endregion
        #endregion
        #endregion
    }
}
