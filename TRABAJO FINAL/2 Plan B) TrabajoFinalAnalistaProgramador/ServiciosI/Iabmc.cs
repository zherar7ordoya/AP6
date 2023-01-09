using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;

namespace ServiciosI
{
    public class Iabmc
    {

    }

    public interface Iabmc<T>
    {
        void Alta(T pObjeto);
        void Baja(T pObjeto);
        void Modificar(T pObjeto);
        List<T> Consultar(string pFiltro);
        List<T> Listar();
    }
}
