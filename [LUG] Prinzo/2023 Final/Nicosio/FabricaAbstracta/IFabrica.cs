using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabricaAbstracta
{
    public interface IFabrica
    {
        void crearProductos();
        IProductoLeche ObtenProductoLeche { get; }
        IProductoSaborizante ObtenSabor { get; }
    }
}