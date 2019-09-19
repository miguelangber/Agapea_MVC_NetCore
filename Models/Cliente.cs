using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Cliente
    {

        #region "...propiedades de la clase..."

        private String _usuario;
        private String _email;
        private String _contrasena;
        private String _nombre;
        private String _apellidos;
        private String _otrosDatos;
        private int _identificador;
        private int _telefono;
        private int _numeroDeTarjeta;
        private DateTime _caducidadTarjeta;

        public String usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                this._usuario = value;
            }
        }

        public String email { get { return _email; } set { this._email = value; } }
        public String contrasena { get { return _contrasena; } set { this._contrasena = value; } }
        public String nombre { get {return _nombre;} set{this._nombre = value; }}
        public String apellidos { get {return _apellidos;} set{this._apellidos = value; }}
        public int identificador { get {return _identificador;} set{this._identificador = value; }}
        public int telefono { get {return _telefono;} set{this._telefono = value; }}
        public String otrosDatos { get {return _otrosDatos;} set{this._otrosDatos = value; }}
        public int numeroDeTarjeta { get {return _numeroDeTarjeta;} set{this._numeroDeTarjeta = value; }}
        public DateTime caducidadTarjeta { get {return _caducidadTarjeta; } set{this._caducidadTarjeta = value; }}

        Dictionary<String, Direccion> direcciones { get; set; } = new Dictionary<string, Direccion>();

        Dictionary<String, Pedido> pedidos { get; set; } = new Dictionary<string, Pedido>();

        Dictionary<String, String> telefonos { get; set; } = new Dictionary<string, string>();

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
