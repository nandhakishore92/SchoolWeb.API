using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialAfterWebApi : Migration
    {
        /// <summary>
        /// The models are already up to date with DB schema and hence skipping the migration.
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditorExpenses");

            migrationBuilder.DropTable(
                name: "AuxiloExpenses");

            migrationBuilder.DropTable(
                name: "BillPaymentHistory");

            migrationBuilder.DropTable(
                name: "BooksAndNotesExpenses");

            migrationBuilder.DropTable(
                name: "BuildingMaterialExpenses");

            migrationBuilder.DropTable(
                name: "BusFeesArchives");

            migrationBuilder.DropTable(
                name: "CableExpenses");

            migrationBuilder.DropTable(
                name: "CerimonyExpenses");

            migrationBuilder.DropTable(
                name: "ClassFeesArchives");

            migrationBuilder.DropTable(
                name: "ConstructionLabourExpenses");

            migrationBuilder.DropTable(
                name: "DonationExpenses");

            migrationBuilder.DropTable(
                name: "ElectricityBoardExpenses");

            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "FeesHistories");

            migrationBuilder.DropTable(
                name: "FeesHistoryArchives");

            migrationBuilder.DropTable(
                name: "FuelExpenses");

            migrationBuilder.DropTable(
                name: "GeneralExpenses");

            migrationBuilder.DropTable(
                name: "HomeExpenses");

            migrationBuilder.DropTable(
                name: "InternetExpenses");

            migrationBuilder.DropTable(
                name: "NonEmiLoanPrincipalExpenses");

            migrationBuilder.DropTable(
                name: "OtherIncomes");

            migrationBuilder.DropTable(
                name: "OutsideLoanExpenses");

            migrationBuilder.DropTable(
                name: "RenewalAndLicenseExpenses");

            migrationBuilder.DropTable(
                name: "RteIncomes");

            migrationBuilder.DropTable(
                name: "SalaryExpenses");

            migrationBuilder.DropTable(
                name: "StationaryExpenses");

            migrationBuilder.DropTable(
                name: "StudentArchives");

            migrationBuilder.DropTable(
                name: "StudentPhotos");

            migrationBuilder.DropTable(
                name: "StudentRegistrationHistories");

            migrationBuilder.DropTable(
                name: "TelephoneExpenses");

            migrationBuilder.DropTable(
                name: "TravelAllowanceExpenses");

            migrationBuilder.DropTable(
                name: "UniformExpenses");

            migrationBuilder.DropTable(
                name: "UserRolesMappings");

            migrationBuilder.DropTable(
                name: "VehicleFeesExpenses");

            migrationBuilder.DropTable(
                name: "VehicleMaintenanceExpenses");

            migrationBuilder.DropTable(
                name: "VehiclePurchaseExpenses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AcademicYear");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "RouteBusStops");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "ExpenseVendorMappers");

            migrationBuilder.DropTable(
                name: "BusStops");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Localities");
        }
    }
}
