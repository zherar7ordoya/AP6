using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción para el servicio de correo
    /// </summary>
    public interface IServicioCorreo
    {


        string SMTP { get; set; }
        int Puerto { get; set; }
        string Usuario { get; set; }
        string Password { get; set; }


        void EnviarEmail(string mailTo, string mailSubject, string mailBody, string pathAdjunto = null);
        Task EnviarEmailAsync(string mailTo, string mailSubject, string mailBody, string pathAdjunto = null);
        

    }
}
