using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class LoanPeriod
    {
        public LoanPeriod()
        {
            CreditSegments = new HashSet<CreditSegment>();
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? InterestRate { get; set; }
        public int? Status { get; set; }
        public int? IdCampus { get; set; }
        public int? IdSemeter { get; set; }

        public virtual Campus IdCampusNavigation { get; set; }
        public virtual Semmeter IdSemeterNavigation { get; set; }
        public virtual ICollection<CreditSegment> CreditSegments { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
