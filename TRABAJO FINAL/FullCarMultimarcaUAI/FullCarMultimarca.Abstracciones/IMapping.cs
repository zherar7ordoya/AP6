using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{     
    /// <summary>
    /// Abstracción que implementan las clases de la capa mapping para brindar servicio ABMC
    /// </summary>
    /// <typeparam name="TIPO">Entidad del negocio que manipula la clase mapping</typeparam>
    public interface IMapping<TIPO>
    {
        void Agregar(TIPO objeto);
        void Modificar(TIPO objeto, string valorUnicoAnterior = null);
        void Eliminar(TIPO objeto);
        bool Existe(TIPO objeto);
        bool TieneObjetosDependientes(TIPO objeto);

        IList<TIPO> ObtenerTodos();
        IList<TIPO> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true);
        TIPO Leer(TIPO objeto);     
       
    }

}
