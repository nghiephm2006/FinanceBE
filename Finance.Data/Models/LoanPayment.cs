using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class LoanPayment
    {
        public LoanPayment()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public double? AmountPayed { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
