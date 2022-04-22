using Finance.Data.Models;
using Reso.Core.BaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuonDau.Data.Repositories;

namespace Finance.Business.Gens.Services
{
    public partial interface IStudentService : IBaseService<Student>
    {
    }
    public partial class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository repository) : base(unitOfWork, repository) { }
    }
}
