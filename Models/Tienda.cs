using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Tienda
    {
        #region "...propiedades de la clase..."

        Dictionary<int, Libro> dictLibros { get; set; } = new Dictionary<int, Libro>();
        Dictionary<int, Cliente> dictClientes { get; set; } = new Dictionary<int, Cliente>();

        #endregion
        #region "...métodos de la clase..."
        #region "...Constructores..."
        #endregion
        #endregion
    }
}
