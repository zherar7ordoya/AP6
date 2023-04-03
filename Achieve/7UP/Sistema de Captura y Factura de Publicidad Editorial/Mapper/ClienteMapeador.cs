using Abstract;

using DataAccess;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ClienteMapeador: ICRUD<IClienteModelo>
    {
        readonly Comando _comando = new Comando();


        public DataTable GetAll()
        {
            string sentencia = "SELECT * FROM Cliente";
            return _comando.RetornaTablaCompleta(sentencia);
        }

        public IClienteModelo Get(int id)
        {
            throw new NotImplementedException();
        }

        public IClienteModelo Add(IClienteModelo item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(IClienteModelo item)
        {
            throw new NotImplementedException();
        }
    }
}
