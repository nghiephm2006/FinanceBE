using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class CreditPackageItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public int? IdCreditPackage { get; set; }

        public virtual CreditPackage IdCreditPackageNavigation { get; set; }
    }
}
