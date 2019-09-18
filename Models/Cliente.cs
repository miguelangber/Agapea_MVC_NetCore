using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Cliente
    {
        #region "...propiedades de la clase..."

        public string sUsuario { get; set; }
        public string sEmail { get; set; }
        public string sContrasena { get; set; }
        public string sNombre { get; set; }
        public string sApellidos { get; set; }
        public int iIentificador { get; set; }
        public int iTelefono { get; set; }
        public String sOtrosDatos { get; set; }
        public int iNumeroDeTarjeta { get; set; }
        public DateTime dCaducidadTarjeta { get; set; }

        Dictionary<String, Direccion> dictDirecciones { get; set; } = new Dictionary<string, Direccion>();

        // crear un dictionary para pedidos y una clase pedido

        // Crear un dictionary para teléfonos


        public void borrarDireccion(String tipo)
        {
         
        }

        #endregion
        #region "...métodos de la clase..."
            #region Metodos publicos
                #region Constructores

                #endregion
                #region Metodos publicos de clase

                #endregion
            #endregion
            #region metodos privados

            #endregion
        #endregion
    }
}
