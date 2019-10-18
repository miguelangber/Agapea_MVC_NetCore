using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing; // namespace para implementar IRouteConstraint
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agapea_MVC_NetCore.Infraestructura
{
    /* CLASE MATCH
     * para crear una restriccion personalizada sobre un segmento de una ruta, creas una clase que implemente
     * interface:
     *  IRouteContraint
     *  
     * para implementar esta interface tienes que generar el metodo Match(...) que devuelve un booleano como 
     * resultado de la restriccion del segmento que quieres hacer, si es "true" el segmento cumple con la restriccion,
     * si es "false" no cumple con la restriccion
     * 
     *   el método Match tiene 5 parametros:
     *      - objeto de la clase HttpContext <--- accesoa todo el contexto de la peticion, respuesta,...
     *      - objeto que implementa interface IRoute, donde se mapea la ruta que estas validando
     *      - objeto String que es el nombre de esa ruta dentro de la tabla de enrutamiento
     *      - objeto de tipo RouteValueDictionary, que es un diccionario clave.valor con los segmentos y valores de los
     *        mismos de la ruta que se esta valorando
     *      - enumeracion RouteDirection que define si se está procesando una URL que viene del cliente ("IncomingRequest)
     *        o una URL procedentede una redireccion ("UrlGeneration")
     *  */
    public class OpcionesMateriaRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext,
                          IRouter route,
                          string routeKey,
                          RouteValueDictionary values,
                          RouteDirection routeDirection)
        {
            List<String> valoresOpcion = new List<String>() { "Titulo",
                                                            "Autor",
                                                            "Editorial",
                                                            "ISBN"
                                                           };
            foreach (String unValor in valoresOpcion)
            {
                if (String.Compare(unValor,values["opcion"].ToString())==0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
