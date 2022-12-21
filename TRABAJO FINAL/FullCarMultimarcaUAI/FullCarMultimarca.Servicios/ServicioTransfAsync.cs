using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios
{
    //Servicio para llamar un método asincrónico desde uno sincrónico
    public class ServicioTransfAsync : IServicioTransfAsync
    {

        public ServicioTransfAsync()
        {

        }

        public void EjectutarAsincronico(Func<Task> delegado)
        {
            try
            {
                delegado();
            }
            catch
            {
                //Consumimos error
            }
        }
        public Task<T> EjectutarAsincronico<T>(Func<Task<T>> delegado)
        {
            try
            {
                return delegado();
            }
            catch
            {
                return default(Task<T>);
                //Consumimos error
            }
        }
    }
}
