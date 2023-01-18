using System;

namespace SchoolWeb.API.Models
{
    public class FeesHistoryArchive
    {
        #region ORM
        public int FeesHistoryArchiveId { get; set; }
        public int AcademicYearId { get; set; }
        public int BillNumber { get; set; }
        public int StudentId { get; set; }
        public int TuitionFees { get; set; }
        public int SchoolManagementFees { get; set; }
        public int BookFees { get; set; }
        public int ExamFees { get; set; }
        public int BusFees { get; set; }
        public int SpecialClassFees { get; set; }
        public int UniformFees { get; set; }
        public int PreviousYearFees { get; set; }
        public int MiscellaneousFees { get; set; }
        public string Comments { get; set; }
        public int Discount { get; set; }
        public int TotalFeesPaid { get; set; }
        public DateTime PaidOn { get; set; }
        public string ReceivedBy { get; set; }
        public virtual Student Student { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        #endregion

        public string FullBillNumber => AcademicYear.ShortYearString + "-" + (BillNumber > 99999 ? BillNumber.ToString("D6") : BillNumber.ToString("D5"));
        public int CurrentYearFees => TuitionFees + SchoolManagementFees + ExamFees + BusFees + SpecialClassFees + BookFees;
        public int FullCurrentYearFees => CurrentYearFees + UniformFees + MiscellaneousFees;

        #region Audit Fees
        public int AuditFeesDefault => TuitionFees + SchoolManagementFees + BusFees + BookFees;

        public int AuditFees2122 => TuitionFees + PreviousYearFees;
        #endregion
    }
}