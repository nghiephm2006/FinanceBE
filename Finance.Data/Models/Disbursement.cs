using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class Disbursement
    {
        public Disbursement()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Interest { get; set; }
        public string Date { get; set; }
        public int? Status { get; set; }
        public int? IdLoan { get; set; }

        public virtual Loan IdLoanNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
