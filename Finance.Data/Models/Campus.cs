using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class Campus
    {
        public Campus()
        {
            BankAccounts = new HashSet<BankAccount>();
            CampusWallets = new HashSet<CampusWallet>();
            CreditPackages = new HashSet<CreditPackage>();
            LoanPeriods = new HashSet<LoanPeriod>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<CampusWallet> CampusWallets { get; set; }
        public virtual ICollection<CreditPackage> CreditPackages { get; set; }
        public virtual ICollection<LoanPeriod> LoanPeriods { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
