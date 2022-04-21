using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Loans = new HashSet<Loan>();
            TuitionBills = new HashSet<TuitionBill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? Status { get; set; }
        public int? IdCampus { get; set; }
        public int? IdCreditSegment { get; set; }

        public virtual Campus IdCampusNavigation { get; set; }
        public virtual CreditSegment IdCreditSegmentNavigation { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<TuitionBill> TuitionBills { get; set; }
    }
}
