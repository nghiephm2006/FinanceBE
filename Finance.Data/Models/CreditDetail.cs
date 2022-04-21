using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class CreditDetail
    {
        public int Id { get; set; }
        public int? IdCreditPackage { get; set; }
        public int? IdCreditType { get; set; }

        public virtual CreditPackage IdCreditPackageNavigation { get; set; }
        public virtual CreditType IdCreditTypeNavigation { get; set; }
    }
}
