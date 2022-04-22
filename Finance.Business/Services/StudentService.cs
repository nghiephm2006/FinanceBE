using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Reso.Core.BaseConnect;
using Microsoft.Extensions.Configuration;
using Finance.Business.Request.Students;
using Finance.Business.Students.Request;
using Finance.Business.ViewModels;
using VuonDau.Data.Repositories;
namespace Finance.Business.Services
{
    public partial interface IStudentService
    {
        Task<List<StudentViewModel>> GetAllStudents(SearchStudentRequest filter);
        Task<StudentViewModel> GetStudentById(Guid id);
        Task<StudentViewModel> CreateStudent(CreateStudentRequest request, IConfiguration configuration);
        Task<StudentViewModel> UpdateStudent(Guid id, UpdateStudentRequest request);
        Task<StudentViewModel> GetByMail(string mail);
        Task<int> DeleteStudent(Guid id);
    }


    public partial class StudentService
    {
        private readonly AutoMapper.IConfigurationProvider _mapper;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<StudentViewModel>> GetAllStudents(SearchStudentRequest request)
        {
            request.Email = request.Email == null ? "" : request.Email;
            request.FullName = request.FullName == null ? "" : request.FullName;
            if (request.Status == null)
            {
                return await Get(f => f.Email.Contains(request.Email) && f.Name.Contains(request.FullName))
                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<StudentViewModel>(_mapper).ToListAsync();
            }
            return await Get(f => f.Email.Contains(request.Email) && f.Name.Contains(request.FullName) && f.Status == request.Status)
                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<StudentViewModel>(_mapper).ToListAsync();
        }

        public async Task<StudentViewModel> GetStudentById(Guid id)
        {
            //return await Get(p => p.Id == id).ProjectTo<StudentViewModel>(_mapper).FirstOrDefaultAsync();
            return null;
        }
        public async Task<StudentViewModel> GetByMail(string mail)
        {
            return null;
            //return await Get(c => c.Email.Equals(mail)).ProjectTo<StudentViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<StudentViewModel> CreateStudent(CreateStudentRequest request, IConfiguration configuration)
        {
            //var mapper = _mapper.CreateMapper();
            //var student = mapper.Map<Student>(request);
            //student.Status = (int)Status.NotApprove;
            //student.DateOfCreate = DateTime.UtcNow;
            //await CreateAsyn(student);
            //var studentViewModel = mapper.Map<StudentViewModel>(student);
            //studentViewModel.jwtToken = TokenService.GenerateStudentJWTWebToken(studentViewModel, configuration);
            //return studentViewModel;
            return null;
        }

        public async Task<StudentViewModel> UpdateStudent(Guid id, UpdateStudentRequest request)
        {
            //var mapper = _mapper.CreateMapper();
            //var studentInRequest = mapper.Map<Student>(request);
            //var student = await Get(p => p.Id == id).FirstOrDefaultAsync();
            //if (student == null)
            //{
            //    return null;
            //}
            //student.FullName = studentInRequest.FullName;
            //student.Password = studentInRequest.Password;
            //student.Phone = studentInRequest.Phone;
            //student.BirthDay = studentInRequest.BirthDay;
            //student.Gender = studentInRequest.Gender;
            //student.Status = studentInRequest.Status;
            //await UpdateAsyn(student);
            //return mapper.Map<StudentViewModel>(student);
            return null;
        }

        public async Task<int> DeleteStudent(Guid id)
        {
            //var student = await Get(p => p.Id == id).FirstOrDefaultAsync();

            //if (student == null)
            //{
            //    return 0;
            //}

            //student.Status = (int)Status.Inactive;
            //await UpdateAsyn(student);

            //return 1;
            return 1;
        }
    }
}
