using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Ofrece métodos a las clases de la capa BLL para proveer sus servicios de ABMC
    /// </summary>
    /// <typeparam name="TIPO">Entidad del negocio que manipula la clase mapping</typeparam>    
    public interface IAbmc<TIPO>
    {
        void Agregar(TIPO objeto);
        void Modificar(TIPO objeto, string valorUnicoAnterior = null);
        void Eliminar(TIPO objeto);
        IList<TIPO> ObtenerTodos();        
        TIPO Leer(TIPO objeto);
    }

    /// <summary>
    /// Agrega a la abstracción ABMC para la BLL la búsqueda con vista asociada
    /// </summary>
    /// <typeparam name="TIPO">Entidad del negocio que manipula la clase mapping</typeparam>
    /// <typeparam name="TVISTA">Clase tipo vista asociada a la entidad para buscadores</typeparam>
    public interface IAbmc<TIPO, TVISTA> : IAbmc<TIPO>
    {
        IList<TVISTA> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true);
    }

    


}
