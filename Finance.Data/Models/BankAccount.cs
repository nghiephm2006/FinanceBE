using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            TransferMoneys = new HashSet<TransferMoney>();
        }

        public int Id { get; set; }
        public string BankNumber { get; set; }
        public string Name { get; set; }
        public int? IdCampus { get; set; }

        public virtual Campus IdCampusNavigation { get; set; }
        public virtual ICollection<TransferMoney> TransferMoneys { get; set; }
    }
}
