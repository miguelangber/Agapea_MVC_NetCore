using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Libro
    {
        #region "...propiedades de la clase..."

        public String sTitulo { get; set; }
        public String sAutor { get; set; }
        public String sEditorial { get; set; }
        public String sImagen { get; set; }
        public int iNumeroDePaginas { get; set; }
        public int iIsbn { get; set; }
        public int iIsbn13 { get; set; }
        public DateTime dFechaDeEdicion { get; set; }
        public int sPrecio { get; set; }
        public int MyProperty { get; set; }


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
            this.sTitulo = sTitulo;
            this.sAutor = sAutor;
            this.sEditorial = sEditorial;
            this.iIsbn = iIsbn;
            this.iIsbn13 = iIsbn13;
            this.sPrecio = iPrecio;
            this.dFechaDeEdicion = dFechaDeEdicion;
            this.sImagen = sImagen;
            this.iNumeroDePaginas = iNumeroDePaginas;
        }
        #endregion
        #region "...Métodos publicos de clase..."

        #endregion
        #endregion
        #endregion
    }
}
