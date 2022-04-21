using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class TuitionBill
    {
        public int Id { get; set; }
        public int? IdStudent { get; set; }
        public int? IdSemester { get; set; }

        public virtual Semmeter IdSemesterNavigation { get; set; }
        public virtual Student IdStudentNavigation { get; set; }
    }
}
