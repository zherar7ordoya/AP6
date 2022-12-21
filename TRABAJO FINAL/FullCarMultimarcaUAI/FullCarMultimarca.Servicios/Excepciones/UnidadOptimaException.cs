using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class UnidadOptimaException<T> : NegocioException
    {
        public UnidadOptimaException(string modelo, string color, string chasis, T unidadOptiona) : base("")
        {
            _modelo = modelo;
            _color = color;
            _chasis = chasis;
            _unidadOptima = unidadOptiona;
        }

        private string _modelo;
        private string _color;
        private string _chasis;

        private T _unidadOptima;
        public T UnidadOptima => _unidadOptima;

        public override string Message => $"La unidad seleccionada NO es la óptima por modelo y color." +
            $"\nModelo: {_modelo}" +
            $"\nColor: {_color}" +
            $"\nUnidad óptima: {_chasis}." +
            $"\n¿Desea continuar con la unidad sugerida?";

    }
}
