using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class CreditType
    {
        public CreditType()
        {
            CreditDetails = new HashSet<CreditDetail>();
            CreditSegments = new HashSet<CreditSegment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<CreditDetail> CreditDetails { get; set; }
        public virtual ICollection<CreditSegment> CreditSegments { get; set; }
    }
}
