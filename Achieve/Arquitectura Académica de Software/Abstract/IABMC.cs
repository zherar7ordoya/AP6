﻿/** **************************** "DEFAULT" KEYWORD *****************************
 * 
 * In generic classes and methods, one issue that arises is how to assign a
 * default value to a parameterized type T when you do not know the following in
 * advance:
 * 
 *  => Whether T will be a reference type or a value type.
 *  => If T is a value type, whether it will be a numeric value or a struct.
 *  
 * Given a variable t of a parameterized type T, the statement t = null is only
 * valid if T is a reference type and t = 0 will only work for numeric value
 * types but not for structs.
 * 
 * The solution is to use the default keyword, which will return null for
 * reference types and zero for numeric value types. For structs, it will return
 * each member of the struct initialized to zero or null depending on whether
 * they are value or reference types.
 * 
 *                               https://stackoverflow.com/a/2432926/14009797 */

// TODO => La pregunta es: ¿para qué necesito aquí un valor en default?

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

        List<T> ConsultaObjeto(T QueObjeto = default);
        List<T> ConsultaRango(T QueObjeto1 = default, T QueObjeto2 = default);
    }
}
