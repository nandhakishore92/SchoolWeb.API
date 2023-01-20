using SchoolWeb.API.Models.Expenses.Building;
using SchoolWeb.API.Models.Expenses.Inventory;
using SchoolWeb.API.Models.Expenses.Loan;
using SchoolWeb.API.Models.Expenses.Miscellaneous;
using SchoolWeb.API.Models.Expenses.Salary;
using SchoolWeb.API.Models.Expenses.Telecom;
using SchoolWeb.API.Models.Expenses.VehicleExpense;
using SchoolWeb.API.Models.Expenses;
using SchoolWeb.API.Models;

namespace SchoolWeb.API.DataAccessLayer
{
	public interface IUnitOfWork
	{
		IRepository<AcademicYear> AcademicYearRepository { get; }
		IRepository<User> UserRepository { get; }
		IRepository<Role> RoleRepository { get; }
		IRepository<UserRolesMapping> UserRolesMappingRepository { get; }
		IRepository<Student> StudentRepository { get; }
		IRepository<StudentArchive> StudentArchiveRepository { get; }
		IRepository<Class> ClassRepository { get; }
		IRepository<ClassFeesArchive> ClassFeesArchiveRepository { get; }
		IRepository<Section> SectionRepository { get; }
		IRepository<BusStop> BusStopRepository { get; }
		IRepository<BusFeesArchive> BusFeesArchiveRepository { get; }
		IRepository<Locality> LocalityRepository { get; }
		IRepository<FeesHistory> FeesHistoryRepository { get; }
		IRepository<FeesHistoryArchive> FeesHistoryArchiveRepository { get; }
		IRepository<RouteBusStop> RouteBusStopRepository { get; }
		IRepository<Vehicle> VehicleRepository { get; }
		IRepository<Expense> ExpenseRepository { get; }
		IRepository<Vendor> VendorRepository { get; }
		IRepository<ExpenseVendorMapper> ExpenseVendorMapperRepository { get; }
		IRepository<Bill> BillRepository { get; }
		IRepository<BillPaymentHistory> BillPaymentHistoryRepository { get; }
		IRepository<BuildingMaterialExpense> BuildingMaterialRepository { get; }
		IRepository<ConstructionLabourExpense> ConstructionLabourRepository { get; }
		IRepository<ElectricityBoardExpense> ElectricityBoardRepository { get; }
		IRepository<RenewalAndLicenseExpense> RenewalAndLicenseRepository { get; }
		IRepository<BooksAndNotesExpense> BooksAndNotesRepository { get; }
		IRepository<StationaryExpense> StationaryRepository { get; }
		IRepository<UniformExpense> UniformRepository { get; }
		IRepository<AuxiloExpense> AuxiloRepository { get; }
		IRepository<OutsideLoanExpense> OutsideLoanRepository { get; }
		IRepository<NonEmiLoanPrincipalExpense> NonEmiLoanPrincipalRepository { get; }
		IRepository<AuditorExpense> AuditorRepository { get; }
		IRepository<CerimonyExpense> CerimonyRepository { get; }
		IRepository<DonationExpense> DonationRepository { get; }
		IRepository<GeneralExpense> GeneralRepository { get; }
		IRepository<HomeExpense> HomeRepository { get; }
		IRepository<SalaryExpense> SalaryRepository { get; }
		IRepository<TravelAllowanceExpense> TravelAllowanceRepository { get; }
		IRepository<TelephoneExpense> TelephoneRepository { get; }
		IRepository<InternetExpense> InternetRepository { get; }
		IRepository<CableExpense> CableRepository { get; }
		IRepository<FuelExpense> FuelRepository { get; }
		IRepository<VehicleFeesExpense> VehicleFeesRepository { get; }
		IRepository<VehiclePurchaseExpense> VehiclePurchaseRepository { get; }
		IRepository<VehicleMaintenanceExpense> VehicleMaintenanceRepository { get; }
		IRepository<RteIncome> RteIncomeRepository { get; }
		IRepository<OtherIncome> OtherIncomeRepository { get; }
		IRepository<StudentRegistrationHistory> StudentRegistrationHistoryRepository { get; }
		IRepository<ExceptionLog> LogRepository { get; }
		void Commit();
		void Rollback();
		Task CommitAsync();
		Task RollbackAsync();
	}

}
