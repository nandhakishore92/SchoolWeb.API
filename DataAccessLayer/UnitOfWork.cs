using SchoolWeb.API.Models;
using SchoolWeb.API.Models.Expenses;
using SchoolWeb.API.Models.Expenses.Building;
using SchoolWeb.API.Models.Expenses.Inventory;
using SchoolWeb.API.Models.Expenses.Loan;
using SchoolWeb.API.Models.Expenses.Miscellaneous;
using SchoolWeb.API.Models.Expenses.Salary;
using SchoolWeb.API.Models.Expenses.Telecom;
using SchoolWeb.API.Models.Expenses.VehicleExpense;

namespace SchoolWeb.API.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
	{
        private SchoolDbContext m_DbContext;
        private IRepository<AcademicYear> m_AcademicYearRepository;
        private IRepository<User> m_UserRepository;
        private IRepository<Role> m_RoleRepository;
        private IRepository<UserRolesMapping> m_UserRolesMappingRepository;
        private IRepository<Student> m_StudentRepository;
        private IRepository<StudentArchive> m_StudentArchiveRepository;
        private IRepository<Class> m_ClassRepository;
        private IRepository<ClassFeesArchive> m_ClassFeesArchiveRepository;
        private IRepository<Section> m_SectionRepository;
        private IRepository<BusStop> m_BusStopRepository;
        private IRepository<BusFeesArchive> m_BusFeesArchiveRepository;
        private IRepository<Locality> m_LocalityRepository;
        private IRepository<FeesHistory> m_FeesHistoryRepository;
        private IRepository<FeesHistoryArchive> m_FeesHistoryArchiveRepository;
        private IRepository<RouteBusStop> m_RouteBusStopRepository;
        private IRepository<Vehicle> m_VehicleRepository; 
        private IRepository<Expense> m_ExpenseRepository;
        private IRepository<Vendor> m_VendorRepository;
        private IRepository<ExpenseVendorMapper> m_ExpenseVendorMapperRepository;
        private IRepository<Bill> m_BillRepository;
        private IRepository<BillPaymentHistory> m_BillPaymentHistoryRepository;
        private IRepository<BuildingMaterialExpense> m_BuildingMaterialExpenseRepository;
        private IRepository<ConstructionLabourExpense> m_ConstructionLabourExpenseRepository;
        private IRepository<ElectricityBoardExpense> m_ElectricityBoardExpenseRepository;
        private IRepository<RenewalAndLicenseExpense> m_RenewalAndLicenseExpenseRepository;
        private IRepository<BooksAndNotesExpense> m_BooksAndNotesExpenseRepository;
        private IRepository<StationaryExpense> m_StationaryExpenseRepository;
        private IRepository<UniformExpense> m_UniformExpenseRepository;
        private IRepository<AuxiloExpense> m_AuxiloExpenseRepository;
        private IRepository<OutsideLoanExpense> m_OutsideLoanExpenseRepository;
        private IRepository<NonEmiLoanPrincipalExpense> m_NonEmiLoanPrincipalRepository;
        private IRepository<AuditorExpense> m_AuditorExpenseRepository;
        private IRepository<CerimonyExpense> m_CerimonyExpenseRepository;
        private IRepository<DonationExpense> m_DonationExpenseRepository;
        private IRepository<GeneralExpense> m_GeneralExpenseRepository;
        private IRepository<HomeExpense> m_HomeExpenseRepository;
        private IRepository<SalaryExpense> m_SalaryExpenseRepository;
        private IRepository<TravelAllowanceExpense> m_TravelAllowanceExpenseRepository;
        private IRepository<TelephoneExpense> m_TelephoneExpenseRepository;
        private IRepository<InternetExpense> m_InternetExpenseRepository;
        private IRepository<CableExpense> m_CableExpenseRepository;
        private IRepository<FuelExpense> m_FuelExpenseRepository;
        private IRepository<VehicleFeesExpense> m_VehicleFeesExpenseRepository;
        private IRepository<VehiclePurchaseExpense> m_VehiclePurchaseExpenseRepository;
        private IRepository<VehicleMaintenanceExpense> m_VehicleMaintenanceExpenseRepository;
        private IRepository<RteIncome> m_RteIncomeRepository;
        private IRepository<OtherIncome> m_OtherIncomeRepository;
        private IRepository<StudentRegistrationHistory> m_StudentRegistrationHistoryRepository;
        private IRepository<ExceptionLog> m_LogRepository = null;

        public int CurrentAcademicYearId => AcademicYearRepository.GetFirstOrDefault(filter: ay => ay.IsCurrentAcademicYear)?.AcademicYearId ?? -1;

        public UnitOfWork(SchoolDbContext context)
        {
            m_DbContext = context;
        }
        
        public IRepository<AcademicYear> AcademicYearRepository
        {
            get
            {
                if (m_AcademicYearRepository == null)
                    m_AcademicYearRepository = new Repository<AcademicYear>(m_DbContext);
                return m_AcademicYearRepository;
            }
        }
        
        public IRepository<User> UserRepository
        {
            get
            {
                if (m_UserRepository == null)
                    m_UserRepository = new Repository<User>(m_DbContext);
                return m_UserRepository;
            }
        }

        public IRepository<Role> RoleRepository
        {
            get
            {
                if (m_RoleRepository == null)
                    m_RoleRepository = new Repository<Role>(m_DbContext);
                return m_RoleRepository;
            }
        }

        public IRepository<UserRolesMapping> UserRolesMappingRepository
        {
            get
            {
                if (m_UserRolesMappingRepository == null)
                    m_UserRolesMappingRepository = new Repository<UserRolesMapping>(m_DbContext);
                return m_UserRolesMappingRepository;
            }
        }

        public IRepository<Student> StudentRepository
        {
            get
            {
                if (m_StudentRepository == null)
                    m_StudentRepository = new Repository<Student>(m_DbContext);
                return m_StudentRepository;
            }
        }

        public IRepository<StudentArchive> StudentArchiveRepository
        {
            get
            {
                if (m_StudentArchiveRepository == null)
                    m_StudentArchiveRepository = new Repository<StudentArchive>(m_DbContext);
                return m_StudentArchiveRepository;
            }
        }

        public IRepository<Class> ClassRepository
        {
            get
            {
                if (m_ClassRepository == null)
                    m_ClassRepository = new Repository<Class>(m_DbContext);
                return m_ClassRepository;
            }
        }

        public IRepository<ClassFeesArchive> ClassFeesArchiveRepository
        {
            get
            {
                if (m_ClassFeesArchiveRepository == null)
                    m_ClassFeesArchiveRepository = new Repository<ClassFeesArchive>(m_DbContext);
                return m_ClassFeesArchiveRepository;
            }
        }

        public IRepository<Section> SectionRepository
        {
            get
            {
                if (m_SectionRepository == null)
                    m_SectionRepository = new Repository<Section>(m_DbContext);
                return m_SectionRepository;
            }
        }

        public IRepository<BusStop> BusStopRepository
        {
            get
            {
                if (m_BusStopRepository == null)
                    m_BusStopRepository = new Repository<BusStop>(m_DbContext);
                return m_BusStopRepository;
            }
        }

        public IRepository<Locality> LocalityRepository
        {
            get
            {
                if (m_LocalityRepository == null)
                    m_LocalityRepository = new Repository<Locality>(m_DbContext);
                return m_LocalityRepository;
            }
        }

        public IRepository<BusFeesArchive> BusFeesArchiveRepository
        {
            get
            {
                if (m_BusFeesArchiveRepository == null)
                    m_BusFeesArchiveRepository = new Repository<BusFeesArchive>(m_DbContext);
                return m_BusFeesArchiveRepository;
            }
        }

        public IRepository<FeesHistory> FeesHistoryRepository
        {
            get
            {
                if (m_FeesHistoryRepository == null)
                    m_FeesHistoryRepository = new Repository<FeesHistory>(m_DbContext);
                return m_FeesHistoryRepository;
            }
        }

        public IRepository<FeesHistoryArchive> FeesHistoryArchiveRepository
        {
            get
            {
                if (m_FeesHistoryArchiveRepository == null)
                    m_FeesHistoryArchiveRepository = new Repository<FeesHistoryArchive>(m_DbContext);
                return m_FeesHistoryArchiveRepository;
            }
        }

        public IRepository<RouteBusStop> RouteBusStopRepository
        {
            get
            {
                if (m_RouteBusStopRepository == null)
                    m_RouteBusStopRepository = new Repository<RouteBusStop>(m_DbContext);
                return m_RouteBusStopRepository;
            }
        }

        public IRepository<Vehicle> VehicleRepository
        {
            get
            {
                if (m_VehicleRepository == null)
                    m_VehicleRepository = new Repository<Vehicle>(m_DbContext);
                return m_VehicleRepository;
            }
        }

        public IRepository<Expense> ExpenseRepository
        {
            get
            {
                if (m_ExpenseRepository == null)
                    m_ExpenseRepository = new Repository<Expense>(m_DbContext);
                return m_ExpenseRepository;
            }
        }

        public IRepository<Vendor> VendorRepository
        {
            get
            {
                if (m_VendorRepository == null)
                    m_VendorRepository = new Repository<Vendor>(m_DbContext);
                return m_VendorRepository;
            }
        }

        public IRepository<ExpenseVendorMapper> ExpenseVendorMapperRepository
        {
            get
            {
                if (m_ExpenseVendorMapperRepository == null)
                    m_ExpenseVendorMapperRepository = new Repository<ExpenseVendorMapper>(m_DbContext);
                return m_ExpenseVendorMapperRepository;
            }
        }

        public IRepository<Bill> BillRepository
        {
            get
            {
                if (m_BillRepository == null)
                    m_BillRepository = new Repository<Bill>(m_DbContext);
                return m_BillRepository;
            }
        }

        public IRepository<BillPaymentHistory> BillPaymentHistoryRepository
        {
            get
            {
                if (m_BillPaymentHistoryRepository == null)
                    m_BillPaymentHistoryRepository = new Repository<BillPaymentHistory>(m_DbContext);
                return m_BillPaymentHistoryRepository;
            }
        }

        public IRepository<BuildingMaterialExpense> BuildingMaterialRepository
        {
            get
            {
                if (m_BuildingMaterialExpenseRepository == null)
                    m_BuildingMaterialExpenseRepository = new Repository<BuildingMaterialExpense>(m_DbContext);
                return m_BuildingMaterialExpenseRepository;
            }
        }

        public IRepository<ConstructionLabourExpense> ConstructionLabourRepository
        {
            get
            {
                if (m_ConstructionLabourExpenseRepository == null)
                    m_ConstructionLabourExpenseRepository = new Repository<ConstructionLabourExpense>(m_DbContext);
                return m_ConstructionLabourExpenseRepository;
            }
        }

        public IRepository<ElectricityBoardExpense> ElectricityBoardRepository
        {
            get
            {
                if (m_ElectricityBoardExpenseRepository == null)
                    m_ElectricityBoardExpenseRepository = new Repository<ElectricityBoardExpense>(m_DbContext);
                return m_ElectricityBoardExpenseRepository;
            }
        }

        public IRepository<RenewalAndLicenseExpense> RenewalAndLicenseRepository
        {
            get
            {
                if (m_RenewalAndLicenseExpenseRepository == null)
                    m_RenewalAndLicenseExpenseRepository = new Repository<RenewalAndLicenseExpense>(m_DbContext);
                return m_RenewalAndLicenseExpenseRepository;
            }
        }

        public IRepository<BooksAndNotesExpense> BooksAndNotesRepository
        {
            get
            {
                if (m_BooksAndNotesExpenseRepository == null)
                    m_BooksAndNotesExpenseRepository = new Repository<BooksAndNotesExpense>(m_DbContext);
                return m_BooksAndNotesExpenseRepository;
            }
        }

        public IRepository<StationaryExpense> StationaryRepository
        {
            get
            {
                if (m_StationaryExpenseRepository == null)
                    m_StationaryExpenseRepository = new Repository<StationaryExpense>(m_DbContext);
                return m_StationaryExpenseRepository;
            }
        }

        public IRepository<UniformExpense> UniformRepository
        {
            get
            {
                if (m_UniformExpenseRepository == null)
                    m_UniformExpenseRepository = new Repository<UniformExpense>(m_DbContext);
                return m_UniformExpenseRepository;
            }
        }

        public IRepository<AuxiloExpense> AuxiloRepository
        {
            get
            {
                if (m_AuxiloExpenseRepository == null)
                    m_AuxiloExpenseRepository = new Repository<AuxiloExpense>(m_DbContext);
                return m_AuxiloExpenseRepository;
            }
        }

        public IRepository<OutsideLoanExpense> OutsideLoanRepository
        {
            get
            {
                if (m_OutsideLoanExpenseRepository == null)
                    m_OutsideLoanExpenseRepository = new Repository<OutsideLoanExpense>(m_DbContext);
                return m_OutsideLoanExpenseRepository;
            }
        }

        public IRepository<NonEmiLoanPrincipalExpense> NonEmiLoanPrincipalRepository
        {
            get
            {
                if (m_NonEmiLoanPrincipalRepository == null)
                    m_NonEmiLoanPrincipalRepository = new Repository<NonEmiLoanPrincipalExpense>(m_DbContext);
                return m_NonEmiLoanPrincipalRepository;
            }
        }

        public IRepository<AuditorExpense> AuditorRepository
        {
            get
            {
                if (m_AuditorExpenseRepository == null)
                    m_AuditorExpenseRepository = new Repository<AuditorExpense>(m_DbContext);
                return m_AuditorExpenseRepository;
            }
        }

        public IRepository<CerimonyExpense> CerimonyRepository
        {
            get
            {
                if (m_CerimonyExpenseRepository == null)
                    m_CerimonyExpenseRepository = new Repository<CerimonyExpense>(m_DbContext);
                return m_CerimonyExpenseRepository;
            }
        }

        public IRepository<DonationExpense> DonationRepository
        {
            get
            {
                if (m_DonationExpenseRepository == null)
                    m_DonationExpenseRepository = new Repository<DonationExpense>(m_DbContext);
                return m_DonationExpenseRepository;
            }
        }

        public IRepository<GeneralExpense> GeneralRepository
        {
            get
            {
                if (m_GeneralExpenseRepository == null)
                    m_GeneralExpenseRepository = new Repository<GeneralExpense>(m_DbContext);
                return m_GeneralExpenseRepository;
            }
        }

        public IRepository<HomeExpense> HomeRepository
        {
            get
            {
                if (m_HomeExpenseRepository == null)
                    m_HomeExpenseRepository = new Repository<HomeExpense>(m_DbContext);
                return m_HomeExpenseRepository;
            }
        }
        
        public IRepository<SalaryExpense> SalaryRepository
        {
            get
            {
                if (m_SalaryExpenseRepository == null)
                    m_SalaryExpenseRepository = new Repository<SalaryExpense>(m_DbContext);
                return m_SalaryExpenseRepository;
            }
        }

        public IRepository<TravelAllowanceExpense> TravelAllowanceRepository
        {
            get
            {
                if (m_TravelAllowanceExpenseRepository == null)
                    m_TravelAllowanceExpenseRepository = new Repository<TravelAllowanceExpense>(m_DbContext);
                return m_TravelAllowanceExpenseRepository;
            }
        }

        public IRepository<TelephoneExpense> TelephoneRepository
        {
            get
            {
                if (m_TelephoneExpenseRepository == null)
                    m_TelephoneExpenseRepository = new Repository<TelephoneExpense>(m_DbContext);
                return m_TelephoneExpenseRepository;
            }
        }

        public IRepository<InternetExpense> InternetRepository
        {
            get
            {
                if (m_InternetExpenseRepository == null)
                    m_InternetExpenseRepository = new Repository<InternetExpense>(m_DbContext);
                return m_InternetExpenseRepository;
            }
        }

        public IRepository<CableExpense> CableRepository
        {
            get
            {
                if (m_CableExpenseRepository == null)
                    m_CableExpenseRepository = new Repository<CableExpense>(m_DbContext);
                return m_CableExpenseRepository;
            }
        }

        public IRepository<FuelExpense> FuelRepository
        {
            get
            {
                if (m_FuelExpenseRepository == null)
                    m_FuelExpenseRepository = new Repository<FuelExpense>(m_DbContext);
                return m_FuelExpenseRepository;
            }
        }

        public IRepository<VehicleFeesExpense> VehicleFeesRepository
        {
            get
            {
                if (m_VehicleFeesExpenseRepository == null)
                    m_VehicleFeesExpenseRepository = new Repository<VehicleFeesExpense>(m_DbContext);
                return m_VehicleFeesExpenseRepository;
            }
        }

        public IRepository<VehiclePurchaseExpense> VehiclePurchaseRepository
        {
            get
            {
                if (m_VehiclePurchaseExpenseRepository == null)
                    m_VehiclePurchaseExpenseRepository = new Repository<VehiclePurchaseExpense>(m_DbContext);
                return m_VehiclePurchaseExpenseRepository;
            }
        }

        public IRepository<VehicleMaintenanceExpense> VehicleMaintenanceRepository
        {
            get
            {
                if (m_VehicleMaintenanceExpenseRepository == null)
                    m_VehicleMaintenanceExpenseRepository = new Repository<VehicleMaintenanceExpense>(m_DbContext);
                return m_VehicleMaintenanceExpenseRepository;
            }
        }

        public IRepository<RteIncome> RteIncomeRepository
        {
            get
            {
                if (m_RteIncomeRepository == null)
                    m_RteIncomeRepository = new Repository<RteIncome>(m_DbContext);
                return m_RteIncomeRepository;
            }
        }

        public IRepository<OtherIncome> OtherIncomeRepository
        {
            get
            {
                if (m_OtherIncomeRepository == null)
                    m_OtherIncomeRepository = new Repository<OtherIncome>(m_DbContext);
                return m_OtherIncomeRepository;
            }
        }

        public IRepository<StudentRegistrationHistory> StudentRegistrationHistoryRepository
        {
            get
            {
                if (m_StudentRegistrationHistoryRepository == null)
                    m_StudentRegistrationHistoryRepository = new Repository<StudentRegistrationHistory>(m_DbContext);
                return m_StudentRegistrationHistoryRepository;
            }
        }

        public IRepository<ExceptionLog> LogRepository
        {
            get
            {
                if (m_LogRepository == null)
                    m_LogRepository = new Repository<ExceptionLog>(m_DbContext);
                return m_LogRepository;
            }
        }

		public void Commit()
			=> m_DbContext.SaveChanges();

        public async Task CommitAsync()
			=> await m_DbContext.SaveChangesAsync();

		public void Rollback()
			=> m_DbContext.Dispose();

        public async Task RollbackAsync()
			=> await m_DbContext.DisposeAsync();
    }
}