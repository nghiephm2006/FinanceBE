using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Finance.Data.Models
{
    public partial class financeFPTContext : DbContext
    {
        public financeFPTContext()
        {
        }

        public financeFPTContext(DbContextOptions<financeFPTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<CampusWallet> CampusWallets { get; set; }
        public virtual DbSet<CreditDetail> CreditDetails { get; set; }
        public virtual DbSet<CreditPackage> CreditPackages { get; set; }
        public virtual DbSet<CreditPackageItem> CreditPackageItems { get; set; }
        public virtual DbSet<CreditSegment> CreditSegments { get; set; }
        public virtual DbSet<CreditType> CreditTypes { get; set; }
        public virtual DbSet<Disbursement> Disbursements { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanChange> LoanChanges { get; set; }
        public virtual DbSet<LoanPayment> LoanPayments { get; set; }
        public virtual DbSet<LoanPeriod> LoanPeriods { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Semmeter> Semmeters { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentWallet> StudentWallets { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransferMoney> TransferMoneys { get; set; }
        public virtual DbSet<TuitionBill> TuitionBills { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SE140337\\SQLEXPRESS;Initial Catalog=financeFPT; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");

                entity.Property(e => e.BankNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.IdCampus)
                    .HasConstraintName("FK_BankAccount_Campus");
            });

            modelBuilder.Entity<Campus>(entity =>
            {
                entity.ToTable("Campus");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CampusWallet>(entity =>
            {
                entity.ToTable("CampusWallet");

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.CampusWallets)
                    .HasForeignKey(d => d.IdCampus)
                    .HasConstraintName("FK_CampusWallet_Campus");
            });

            modelBuilder.Entity<CreditDetail>(entity =>
            {
                entity.ToTable("CreditDetail");

                entity.HasOne(d => d.IdCreditPackageNavigation)
                    .WithMany(p => p.CreditDetails)
                    .HasForeignKey(d => d.IdCreditPackage)
                    .HasConstraintName("FK_CreditDetail_CreditPackage");

                entity.HasOne(d => d.IdCreditTypeNavigation)
                    .WithMany(p => p.CreditDetails)
                    .HasForeignKey(d => d.IdCreditType)
                    .HasConstraintName("FK_CreditDetail_CreditType");
            });

            modelBuilder.Entity<CreditPackage>(entity =>
            {
                entity.ToTable("CreditPackage");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.CreditPackages)
                    .HasForeignKey(d => d.IdCampus)
                    .HasConstraintName("FK_CreditPackage_Campus");
            });

            modelBuilder.Entity<CreditPackageItem>(entity =>
            {
                entity.ToTable("CreditPackageItem");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdCreditPackageNavigation)
                    .WithMany(p => p.CreditPackageItems)
                    .HasForeignKey(d => d.IdCreditPackage)
                    .HasConstraintName("FK_CreditPackageItem_CreditPackage");
            });

            modelBuilder.Entity<CreditSegment>(entity =>
            {
                entity.ToTable("CreditSegment");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCreditTypeNavigation)
                    .WithMany(p => p.CreditSegments)
                    .HasForeignKey(d => d.IdCreditType)
                    .HasConstraintName("FK_CreditSegment_CreditType");

                entity.HasOne(d => d.IdLoanPeriodNavigation)
                    .WithMany(p => p.CreditSegments)
                    .HasForeignKey(d => d.IdLoanPeriod)
                    .HasConstraintName("FK_CreditSegment_LoanPeriod");
            });

            modelBuilder.Entity<CreditType>(entity =>
            {
                entity.ToTable("CreditType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Disbursement>(entity =>
            {
                entity.ToTable("Disbursement");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Interest)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLoanNavigation)
                    .WithMany(p => p.Disbursements)
                    .HasForeignKey(d => d.IdLoan)
                    .HasConstraintName("FK_Disbursement_Loan");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCreditPackageNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdCreditPackage)
                    .HasConstraintName("FK_Loan_CreditPackage");

                entity.HasOne(d => d.IdLoanChangeNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdLoanChange)
                    .HasConstraintName("FK_Loan_LoanChange");

                entity.HasOne(d => d.IdLoanPeriodNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdLoanPeriod)
                    .HasConstraintName("FK_Loan_LoanPeriod");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_Loan_Student");
            });

            modelBuilder.Entity<LoanChange>(entity =>
            {
                entity.ToTable("LoanChange");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdLoan).HasColumnName("idLoan");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<LoanPayment>(entity =>
            {
                entity.ToTable("LoanPayment");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LoanPeriod>(entity =>
            {
                entity.ToTable("LoanPeriod");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.LoanPeriods)
                    .HasForeignKey(d => d.IdCampus)
                    .HasConstraintName("FK_LoanPeriod_Campus");

                entity.HasOne(d => d.IdSemeterNavigation)
                    .WithMany(p => p.LoanPeriods)
                    .HasForeignKey(d => d.IdSemeter)
                    .HasConstraintName("FK_LoanPeriod_Semmeter");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semmeter>(entity =>
            {
                entity.ToTable("Semmeter");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnType("text");

                entity.HasOne(d => d.IdCampusNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdCampus)
                    .HasConstraintName("FK_Student_Campus");

                entity.HasOne(d => d.IdCreditSegmentNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdCreditSegment)
                    .HasConstraintName("FK_Student_CreditSegment");
            });

            modelBuilder.Entity<StudentWallet>(entity =>
            {
                entity.ToTable("StudentWallet");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCampusWalletNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdCampusWallet)
                    .HasConstraintName("FK_Transaction_CampusWallet");

                entity.HasOne(d => d.IdDisbursementNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdDisbursement)
                    .HasConstraintName("FK_Transaction_Disbursement");

                entity.HasOne(d => d.IdLoanPaymentNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdLoanPayment)
                    .HasConstraintName("FK_Transaction_LoanPayment");

                entity.HasOne(d => d.IdStudentWalletNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdStudentWallet)
                    .HasConstraintName("FK_Transaction_StudentWallet");

                entity.HasOne(d => d.IdTransferMoneyNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdTransferMoney)
                    .HasConstraintName("FK_Transaction_TransferMoney");
            });

            modelBuilder.Entity<TransferMoney>(entity =>
            {
                entity.ToTable("TransferMoney");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdBankAccountNavigation)
                    .WithMany(p => p.TransferMoneys)
                    .HasForeignKey(d => d.IdBankAccount)
                    .HasConstraintName("FK_TransferMoney_BankAccount");

                entity.HasOne(d => d.IdStudentWalletNavigation)
                    .WithMany(p => p.TransferMoneys)
                    .HasForeignKey(d => d.IdStudentWallet)
                    .HasConstraintName("FK_TransferMoney_StudentWallet");
            });

            modelBuilder.Entity<TuitionBill>(entity =>
            {
                entity.ToTable("TuitionBill");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdSemesterNavigation)
                    .WithMany(p => p.TuitionBills)
                    .HasForeignKey(d => d.IdSemester)
                    .HasConstraintName("FK_TuitionBill_Semmeter");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.TuitionBills)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_TuitionBill_Student");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnType("text");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
