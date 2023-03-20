using Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Telefono: IID, ICloneable
    {
        public int Id { get; set; }
        public string Numero { get; set; }

        public Telefono()
        {
        }
        public Telefono(int QueId, string QueNumero)
        {
            Id = QueId;
            Numero = QueNumero;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }



        public int RetornaId()
        {
            return Id;
        }
    }
}
