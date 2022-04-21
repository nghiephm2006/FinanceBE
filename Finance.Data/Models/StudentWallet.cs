using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class StudentWallet
    {
        public StudentWallet()
        {
            Transactions = new HashSet<Transaction>();
            TransferMoneys = new HashSet<TransferMoney>();
        }

        public int Id { get; set; }
        public double? OverBlance { get; set; }
        public int? Status { get; set; }
        public int? IdStudent { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<TransferMoney> TransferMoneys { get; set; }
    }
}
