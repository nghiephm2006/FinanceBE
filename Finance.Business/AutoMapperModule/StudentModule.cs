using AutoMapper;
using Finance.Business.ViewModels;
using Finance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.AutoMapperModule
{
    public static class StudentModule
    {
        public static void ConfigStudentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Student, StudentViewModel>().ReverseMap();
        }
    }
}
