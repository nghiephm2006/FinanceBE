using Finance.Business.Students.Request;
using Finance.Data.Models;
using Reso.Core.BaseConnect;
using System.Threading.Tasks;
using VuonDau.Data.Repositories;

namespace Finance.Business.Services
{
    public partial interface IStudentService : IBaseService<Student>
    {
    }
    public partial class StudentService:BaseService<Student>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository repository) : base(unitOfWork, repository) { }
    }
}
