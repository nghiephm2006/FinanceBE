

using AutoMapper;
using Finance.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Finance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public partial class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        public StudentsController(IStudentService studentService, IMapper mapper, IConfiguration configuration)
        {
            _studentService = studentService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
        }
    }
}
