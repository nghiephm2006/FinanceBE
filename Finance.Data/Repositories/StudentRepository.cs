/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////

using Finance.Data.Models;
using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
namespace VuonDau.Data.Repositories
{
    public partial interface IStudentRepository :IBaseRepository<Student>
    {
    }
    public partial class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
         public StudentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

