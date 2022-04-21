using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class Semmeter
    {
        public Semmeter()
        {
            LoanPeriods = new HashSet<LoanPeriod>();
            TuitionBills = new HashSet<TuitionBill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<LoanPeriod> LoanPeriods { get; set; }
        public virtual ICollection<TuitionBill> TuitionBills { get; set; }
    }
}
