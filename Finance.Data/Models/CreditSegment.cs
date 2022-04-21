using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class CreditSegment
    {
        public CreditSegment()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Note { get; set; }
        public int? IdLoanPeriod { get; set; }
        public int? IdCreditType { get; set; }

        public virtual CreditType IdCreditTypeNavigation { get; set; }
        public virtual LoanPeriod IdLoanPeriodNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
