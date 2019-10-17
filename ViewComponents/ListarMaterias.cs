using Agapea_MVC_NetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.ViewComponents
{
    public class ListarMaterias : ViewComponent
    {
        private IDBAccess _accesoDB;

        public ListarMaterias(IDBAccess accesoDBSqulServer) {
            this._accesoDB = accesoDBSqulServer;
        }
        public IViewComponentResult Invoke() {
            List<String> _listaDeNombresMaterias = this._accesoDB.DevolverMaterias(0);
            return View(_listaDeNombresMaterias);
        }
    }
}
