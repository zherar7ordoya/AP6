using DomainLayer.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Services.DepartmentServices
{
    public interface IDepartmentRepository
    {
        void Add    (DepartmentModel departmentModel);
        void Update (DepartmentModel departmentModel);
        void Delete (DepartmentModel departmentModel);
        IEnumerable<DepartmentModel> GetAll();
        DepartmentModel GetByID(int id);

    }
}
