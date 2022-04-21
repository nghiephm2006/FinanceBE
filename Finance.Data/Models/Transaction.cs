using System;
using System.Collections.Generic;

#nullable disable

namespace Finance.Data.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        public int? Status { get; set; }
        public int? IdDisbursement { get; set; }
        public int? IdCampusWallet { get; set; }
        public int? IdTransferMoney { get; set; }
        public int? IdStudentWallet { get; set; }
        public int? IdLoanPayment { get; set; }

        public virtual CampusWallet IdCampusWalletNavigation { get; set; }
        public virtual Disbursement IdDisbursementNavigation { get; set; }
        public virtual LoanPayment IdLoanPaymentNavigation { get; set; }
        public virtual StudentWallet IdStudentWalletNavigation { get; set; }
        public virtual TransferMoney IdTransferMoneyNavigation { get; set; }
    }
}
