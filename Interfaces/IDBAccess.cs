using Agapea_MVC_NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Interfaces
{
    public interface IDBAccess
    {




        List<String> DevolverMaterias(int id);







        Dictionary<String, Libro> DevolverLibros(int id);

        Libro DevolverLibroPorISBN(String ISBN);
        Dictionary<String, Libro> DevolverLibros(string materia);
        Dictionary<String, Libro> DevolverLibros(string opcion, string valor);
    }
}
