using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class LoanChange
    {
        public LoanChange()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public double? AmountInDept { get; set; }
        public double? AmountPayed { get; set; }
        public double? AmountLeft { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Status { get; set; }
        public int? IdLoan { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
