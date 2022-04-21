using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class Loan
    {
        public Loan()
        {
            Disbursements = new HashSet<Disbursement>();
        }

        public int Id { get; set; }
        public string Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? InterestRate { get; set; }
        public double? TotalPayment { get; set; }
        public int? Status { get; set; }
        public int? IdStudent { get; set; }
        public int? IdLoanPeriod { get; set; }
        public int? IdCreditPackage { get; set; }
        public int? IdLoanChange { get; set; }

        public virtual CreditPackage IdCreditPackageNavigation { get; set; }
        public virtual LoanChange IdLoanChangeNavigation { get; set; }
        public virtual LoanPeriod IdLoanPeriodNavigation { get; set; }
        public virtual Student IdStudentNavigation { get; set; }
        public virtual ICollection<Disbursement> Disbursements { get; set; }
    }
}
