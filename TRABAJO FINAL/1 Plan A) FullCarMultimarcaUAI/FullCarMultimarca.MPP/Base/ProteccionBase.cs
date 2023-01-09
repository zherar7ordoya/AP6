using System.Data;

namespace FullCarMultimarca.MPP.Base
{
    /// <summary>
    /// Clase abstracta que deben implementar aquellas entidades para tener proteccion
    /// </summary>
    public abstract class ProteccionBase
    {

        internal abstract string CrearHashRegistro(DataRow dr);
        internal abstract string CrearHashTabla(DataTable dt);

        protected abstract void IncluirProteccionTabla(DataTable dtAProteger, DataTable dtProteccion);
        protected abstract void IncluirProteccionRegistro(DataRow dRow);        

    }
}
