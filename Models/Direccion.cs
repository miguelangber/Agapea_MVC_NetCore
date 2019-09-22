using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Direccion
    {
        #region propiedades de clase
        private int _pais;
        private int _provincia;
        private String _direccion;

        public int pais { get { return _pais; } set { this._pais = value; } }
        public int provincia { get { return _provincia; } set { this._provincia = value; } }
        public String direccion { get { return _direccion; } set { this._direccion = value; } }
        #endregion
        #region Metodos de clase
        #region Metodos publicos
        #region Constructores
        public Direccion() { }
        public Direccion(int pais, int provincia, String direccion)
        {
            this._pais = pais;
            this._provincia = provincia;
            this._direccion = direccion;
        }
        #endregion
        #region Metodos públicos de clase

        #endregion
        #endregion
        #region Métodos privados de clase

        #endregion
        #endregion
    }
}










/**/
#region propiedades de clase

#endregion
#region Metodos de clase
#region Metodos publicos
#region Constructores

#endregion
#region Metodos públicos de clase

#endregion
#endregion
#region Métodos privados de clase

#endregion
#endregion

