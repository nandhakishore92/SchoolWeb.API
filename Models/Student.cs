using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SchoolWeb.API.Models
{
    public class Student
    {
        private int m_SubsequentDiscount = 0;
        private int? m_TuitionFeesBalance;
        private int? m_SchoolManagementFeesBalance;
        private int? m_ExamFeesBalance;
        private int? m_BookFeesBalance;
        private int? m_BusFeesBalance;
        private int? m_SpecialClassFeesBalance;

        #region ORM
        public string EmisNumber { get; set; }
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        public int? SectionId { get; set; }
        [Required]
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string AadharNumber { get; set; }
        [Required]
        public long ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int AdmissionNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string Community { get; set; }
        public string Caste { get; set; }
        public string Religion { get; set; }
        public string Disability { get; set; }
        public string MotherTongue { get; set; }
        public int LocalityId { get; set; }
        public int RouteBusStopId { get; set; }
        public int PreviousYearFees { get; set; }
        public bool IsActive { get; set; }
        public bool IsRte { get; set; }
        public DateTime? DateOfRelieving { get; set; }
        public bool HasGraduated { get; set; }
        [ForeignKey("AcademicYear")]
        public int? GraduatedYearId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Section Section { get; set; }
        public virtual RouteBusStop RouteBusStop { get; set; }
        public virtual ICollection<FeesHistory> FeesHistories { get; set; }
        public virtual ICollection<FeesHistoryArchive> FeesHistoryArchives { get; set; }
        public virtual Locality Locality { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        #endregion

        public string FullClassName => Class.ClassName + "-" + Section.Name;
        public int Discount => FeesHistories.Sum(feesHistory => feesHistory.Discount);

        #region TuitionFees
        public int TuitionFeesTotal => IsRte ? 0 : Class.TuitionFees;
        public int TuitionFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.TuitionFees);
        public int TuitionFeesBalance
        {
            get
            {
                if (m_TuitionFeesBalance.HasValue)
                    return m_TuitionFeesBalance.Value;

                m_TuitionFeesBalance = GetBalance(TuitionFeesTotal, TuitionFeesPaid);
                return m_TuitionFeesBalance.Value;
            }
        }
        #endregion

        #region SchoolManagementFees
        public int SchoolManagementFeesTotal => Class.SchoolManagementFees;
        public int SchoolManagementFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.SchoolManagementFees);
        public int SchoolManagementFeesBalance
        {
            get
            {
                if (m_SchoolManagementFeesBalance.HasValue)
                    return m_SchoolManagementFeesBalance.Value;

                m_SchoolManagementFeesBalance = GetBalance(SchoolManagementFeesTotal, SchoolManagementFeesPaid);
                return m_SchoolManagementFeesBalance.Value;
            }
        }
        #endregion

        #region ExamFees
        public int ExamFeesTotal => Class.ExamFees;
        public int ExamFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.ExamFees);
        public int ExamFeesBalance
        {
            get
            {
                if (m_ExamFeesBalance.HasValue)
                    return m_ExamFeesBalance.Value;

                m_ExamFeesBalance = GetBalance(ExamFeesTotal, ExamFeesPaid);
                return m_ExamFeesBalance.Value;
            }
        }
        #endregion

        #region BookFees
        public int BookFeesTotal => Class.BookFees;
        public int BookFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.BookFees);
        public int BookFeesBalance
        {
            get
            {
                if (m_BookFeesBalance.HasValue)
                    return m_BookFeesBalance.Value;

                m_BookFeesBalance = GetBalance(BookFeesTotal, BookFeesPaid);
                return m_BookFeesBalance.Value;
            }
        }
        #endregion

        #region BusFees
        public int BusFeesTotal => Class.ClassId < 15 ? RouteBusStop.BusFees : 0;
        public int BusFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.BusFees);
        public int BusFeesBalance
        {
            get
            {
                if (m_BusFeesBalance.HasValue)
                    return m_BusFeesBalance.Value;

                m_BusFeesBalance = GetBalance(BusFeesTotal, BusFeesPaid);
                return m_BusFeesBalance.Value;
            }
        }
        #endregion

        #region SpecialClassFees
        public int SpecialClassFeesTotal => Class.HasSpecialClass ? RouteBusStop.SpecialClassFees : 0;
        public int SpecialClassFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.SpecialClassFees);
        public int SpecialClassFeesBalance
        {
            get
            {
                if (m_SpecialClassFeesBalance.HasValue)
                    return m_SpecialClassFeesBalance.Value;

                m_SpecialClassFeesBalance = GetBalance(SpecialClassFeesTotal, SpecialClassFeesPaid);
                return m_SpecialClassFeesBalance.Value;
            }
        }
        #endregion

        #region NonStandardFees
        public int UniformFeesPaid => FeesHistories.Sum(fee => fee.UniformFees);
        public int MiscellaneousFeesPaid => FeesHistories.Sum(fee => fee.MiscellaneousFees);
        #endregion

        #region PreviousYearFees
        public int PreviousYearFeesTotal => PreviousYearFees;
        public int PreviousYearFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.PreviousYearFees);
        public int PreviousYearFeesBalance
        {
            get
            {
                m_SubsequentDiscount = Discount;
                return GetBalance(PreviousYearFeesTotal, PreviousYearFeesPaid);
            }
        }
        #endregion

        #region CurrentYearFees
        public int CurrentYearFeesTotal => TuitionFeesTotal + SchoolManagementFeesTotal + ExamFeesTotal + BookFeesTotal + BusFeesTotal + SpecialClassFeesTotal + UniformFeesPaid + MiscellaneousFeesPaid;
        public int CurrentYearFeesPaid => FeesHistories.Sum(feesHistory => feesHistory.TuitionFees + feesHistory.SchoolManagementFees + feesHistory.ExamFees + feesHistory.BookFees + feesHistory.BusFees + feesHistory.SpecialClassFees + feesHistory.UniformFees + feesHistory.MiscellaneousFees);
        public int CurrentYearFeesBalance => TuitionFeesBalance + ExamFeesBalance + BookFeesBalance + BusFeesBalance + SpecialClassFeesBalance + SchoolManagementFeesBalance;
        #endregion

        #region FeesTotal
        public int FeesTotal => CurrentYearFeesTotal + PreviousYearFeesTotal;
        public int FeesPaid => FeesHistories.Sum(feesHistory => feesHistory.TotalFeesPaid - feesHistory.Discount);
        public int FeesBalance => FeesTotal - (FeesPaid + Discount);
        #endregion

        private int GetBalance(int total, int paid)
        {
            int actualBalance = total - paid;
            if (m_SubsequentDiscount == 0)
                return actualBalance;

            if (actualBalance == 0)
                return 0;

            if (actualBalance >= m_SubsequentDiscount)
            {
                int balance = actualBalance - m_SubsequentDiscount;
                m_SubsequentDiscount = 0;
                return balance; 
            }

            m_SubsequentDiscount = m_SubsequentDiscount - actualBalance;
            return 0;
        }
    }
}