using DomainLayer.Models.Department;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DepartmentServices
{
    public class DepartmentServices : IDepartmentService, IDepartmentRepository
    {
        private IDepartmentRepository _departmentRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DepartmentServices(IDepartmentRepository departmentRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _departmentRepository = departmentRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(DepartmentModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(DepartmentModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DepartmentModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmentModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(DepartmentModel departmentModel)
        {
            throw new NotImplementedException();
        }
    }
}
