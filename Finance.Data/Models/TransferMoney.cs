using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class TransferMoney
    {
        public TransferMoney()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int? IdBankAccount { get; set; }
        public int? IdStudentWallet { get; set; }

        public virtual BankAccount IdBankAccountNavigation { get; set; }
        public virtual StudentWallet IdStudentWalletNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
