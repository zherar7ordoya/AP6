using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IABMC<T>
    {
        void Alta(T QueObjeto = default);
        void Baja(T QueObjeto = default);
        void Modificacion(T QueObjeto = default);
        List<T> Consulta(T QueObjeto = default);
        List<T> ConsultaRango(T QueObjeto1 = default, T QueObjeto2 = default);
    }
}
