using System;

namespace FullCarMultimarca.Abstracciones
{

    /// <summary>
    /// Abstracción para la inversión de control del servicio de Correspondencia Polimórfica 
    /// </summary>    
    public interface IServicioCorrespondenciaPolimorfica<TBLL>
    {
        TBLL ObtenerCorrespondencia(Type tipo);
    }
}
