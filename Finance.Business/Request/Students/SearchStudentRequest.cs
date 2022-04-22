using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Students.Request
{
    public class SearchStudentRequest
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int? Status { get; set; }
    }
}
