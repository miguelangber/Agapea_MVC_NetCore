using Agapea_MVC_NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Interfaces
{
    public interface IDBAccess
    {
        List<String> DevolverMaterias();
        Dictionary<String, Libro> DevolverLibros(int id);
    }
}
