using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Models
{
    public class Pedido
    {
        private String _id;
        private String _nic;
        private DateTime _fecha;
        private int _precioTotal;
        private Dictionary<Libro,int> _libros;


        public String id { get; set; }
        public String nic { get; set; }
        public DateTime fecha { get; set; }
        public int precioTotal { get; set; }
        public Dictionary<Libro,int> libros { get; set; }

        #region Metodos de clase

        #region Constructores
        public Pedido() {}
        public Pedido(String id, String nic, DateTime fecha, int precioTotal,Dictionary<Libro,int> libros) { }
        #endregion

        #endregion
    }
}
