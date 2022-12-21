using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Parametros
{
    /// <summary>
    /// Parametros de seguridad del sistema
    /// </summary>
    public class FlagsSeguridad
    {
        public FlagsSeguridad()
        {

        }

        public int MinimoCaracteresPassword { get; set; }
        public int IntentosBloqueoPassword { get; set; }
        public int DiasVigenciaPassword { get; set; }
        public bool DebeContenerNumero { get; set; }
        public bool DebeContenerMayuscula { get; set; }
        public bool DebeContenerMinuscula { get; set; }
        public bool DebeContenerCaracterEspecial { get; set; }

        public override string ToString()
        {
            return "Parámetros Seguridad";
        }

    }
}
