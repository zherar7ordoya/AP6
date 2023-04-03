using Abstract;

using Mapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ClienteLogica : ICRUD<IClienteModelo>
    {
        readonly ClienteMapeador _mapeador = new ClienteMapeador();
        

        public DataTable GetAll()
        {
            return _mapeador.GetAll();
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
