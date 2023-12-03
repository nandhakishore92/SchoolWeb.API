using Microsoft.EntityFrameworkCore;
using SchoolWeb.API.Models;
using SchoolWeb.API.Models.Expenses;
using SchoolWeb.API.Models.Expenses.Building;
using SchoolWeb.API.Models.Expenses.Inventory;
using SchoolWeb.API.Models.Expenses.Loan;
using SchoolWeb.API.Models.Expenses.Miscellaneous;
using SchoolWeb.API.Models.Expenses.Salary;
using SchoolWeb.API.Models.Expenses.Telecom;
using SchoolWeb.API.Models.Expenses.VehicleExpense;
using System.Data;
using System.Numerics;
using System.Security.Claims;

namespace SchoolWeb.API.DataAccessLayer
{
	public class SchoolDbContext : DbContext
	{
		public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
		: base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRolesMapping> UserRolesMappings { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<Section> Sections { get; set; }
		public DbSet<BusStop> BusStops { get; set; }
		public DbSet<Models.Route> Routes { get; set; }
		public DbSet<RouteBusStop> RouteBusStops { get; set; }
		public DbSet<FeesHistory> FeesHistories { get; set; }
		public DbSet<Locality> Localities { get; set; }
		public DbSet<ExceptionLog> ExceptionLogs { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<BuildingMaterialExpense> BuildingMaterialExpenses { get; set; }
		public DbSet<ConstructionLabourExpense> ConstructionLabourExpenses { get; set; }
		public DbSet<ElectricityBoardExpense> ElectricityBoardExpenses { get; set; }
		public DbSet<RenewalAndLicenseExpense> RenewalAndLicenseExpenses { get; set; }
		public DbSet<BooksAndNotesExpense> BooksAndNotesExpenses { get; set; }
		public DbSet<StationaryExpense> StationaryExpenses { get; set; }
		public DbSet<UniformExpense> UniformExpenses { get; set; }
		public DbSet<AuxiloExpense> AuxiloExpenses { get; set; }
		public DbSet<OutsideLoanExpense> OutsideLoanExpenses { get; set; }
		public DbSet<NonEmiLoanPrincipalExpense> NonEmiLoanPrincipalExpenses { get; set; }
		public DbSet<AuditorExpense> AuditorExpenses { get; set; }
		public DbSet<CerimonyExpense> CerimonyExpenses { get; set; }
		public DbSet<DonationExpense> DonationExpenses { get; set; }
		public DbSet<GeneralExpense> GeneralExpenses { get; set; }
		public DbSet<HomeExpense> HomeExpenses { get; set; }
		public DbSet<SalaryExpense> SalaryExpenses { get; set; }
		public DbSet<TravelAllowanceExpense> TravelAllowanceExpenses { get; set; }
		public DbSet<TelephoneExpense> TelephoneExpenses { get; set; }
		public DbSet<InternetExpense> InternetExpenses { get; set; }
		public DbSet<CableExpense> CableExpenses { get; set; }
		public DbSet<FuelExpense> FuelExpenses { get; set; }
		public DbSet<VehicleFeesExpense> VehicleFeesExpenses { get; set; }
		public DbSet<VehiclePurchaseExpense> VehiclePurchaseExpenses { get; set; }
		public DbSet<VehicleMaintenanceExpense> VehicleMaintenanceExpenses { get; set; }
		public DbSet<BusFeesArchive> BusFeesArchives { get; set; }
		public DbSet<ClassFeesArchive> ClassFeesArchives { get; set; }
		public DbSet<FeesHistoryArchive> FeesHistoryArchives { get; set; }
		public DbSet<StudentArchive> StudentArchives { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<ExpenseVendorMapper> ExpenseVendorMappers { get; set; }
		public DbSet<RteIncome> RteIncomes { get; set; }
		public DbSet<OtherIncome> OtherIncomes { get; set; }
		public DbSet<StudentRegistrationHistory> StudentRegistrationHistories { get; set; }
	}
}
