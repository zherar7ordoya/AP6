using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface ICRUD<T> where T : IId
    {
        //IEnumerable<T> GetAll();
        DataTable GetAll();
        T Get(int id);
        T Add(T item);
        void Remove(int id);
        bool Update(T item);
    }
}
