using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas.Atributos
{
    /// <summary>
    /// Atributo que permite personalizar el titulo de las propiedades que se bindean en la grilla.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NoVisibleEnGrillaAttribute : Attribute
    {
    }
}
