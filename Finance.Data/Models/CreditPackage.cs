using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class CreditPackage
    {
        public CreditPackage()
        {
            CreditDetails = new HashSet<CreditDetail>();
            CreditPackageItems = new HashSet<CreditPackageItem>();
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? IdCampus { get; set; }

        public virtual Campus IdCampusNavigation { get; set; }
        public virtual ICollection<CreditDetail> CreditDetails { get; set; }
        public virtual ICollection<CreditPackageItem> CreditPackageItems { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
