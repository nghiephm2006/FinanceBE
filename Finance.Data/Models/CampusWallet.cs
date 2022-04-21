using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class CampusWallet
    {
        public CampusWallet()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public double? OverBlance { get; set; }
        public int? Status { get; set; }
        public int? IdCampus { get; set; }

        public virtual Campus IdCampusNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
