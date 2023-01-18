using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialAfterWebApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYear",
                columns: table => new
                {
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortYearString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrentAcademicYear = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.AcademicYearId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuitionFees = table.Column<int>(type: "int", nullable: false),
                    SchoolManagementFees = table.Column<int>(type: "int", nullable: false),
                    BookFees = table.Column<int>(type: "int", nullable: false),
                    ExamFees = table.Column<int>(type: "int", nullable: false),
                    HasSpecialClass = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    LocalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.LocalityId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conductor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturedYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ComparisonName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherIncomes_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RteIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedAmount = table.Column<int>(type: "int", nullable: false),
                    ReceivedAmount = table.Column<int>(type: "int", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RteIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RteIncomes_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFeesArchives",
                columns: table => new
                {
                    ClassFeesArchiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    TuitionFees = table.Column<int>(type: "int", nullable: false),
                    SchoolManagementFees = table.Column<int>(type: "int", nullable: false),
                    BookFees = table.Column<int>(type: "int", nullable: false),
                    ExamFees = table.Column<int>(type: "int", nullable: false),
                    HasSpecialClass = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeesArchives", x => x.ClassFeesArchiveId);
                    table.ForeignKey(
                        name: "FK_ClassFeesArchives_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassFeesArchives_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusStops",
                columns: table => new
                {
                    BusStopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusStopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStops", x => x.BusStopId);
                    table.ForeignKey(
                        name: "FK_BusStops_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "LocalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesMappings",
                columns: table => new
                {
                    UserRolesMappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesMappings", x => x.UserRolesMappingId);
                    table.ForeignKey(
                        name: "FK_UserRolesMappings_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolesMappings_Users_UserName1",
                        column: x => x.UserName1,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseVendorMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseVendorMappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseVendorMappers_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId");
                    table.ForeignKey(
                        name: "FK_ExpenseVendorMappers_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusFeesArchives",
                columns: table => new
                {
                    BusFeesArchiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    BusFees = table.Column<int>(type: "int", nullable: false),
                    SpecialClassFees = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    BusStopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusFeesArchives", x => x.BusFeesArchiveId);
                    table.ForeignKey(
                        name: "FK_BusFeesArchives_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusFeesArchives_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "BusStopId");
                    table.ForeignKey(
                        name: "FK_BusFeesArchives_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                });

            migrationBuilder.CreateTable(
                name: "RouteBusStops",
                columns: table => new
                {
                    RouteBusStopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusFees = table.Column<int>(type: "int", nullable: false),
                    SpecialClassFees = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    BusStopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteBusStops", x => x.RouteBusStopId);
                    table.ForeignKey(
                        name: "FK_RouteBusStops_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "BusStopId");
                    table.ForeignKey(
                        name: "FK_RouteBusStops_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseVendorMapperId = table.Column<int>(type: "int", nullable: false),
                    BillStatus = table.Column<int>(type: "int", nullable: false),
                    BillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PendingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_ExpenseVendorMappers_ExpenseVendorMapperId",
                        column: x => x.ExpenseVendorMapperId,
                        principalTable: "ExpenseVendorMappers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Community = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherTongue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalityId = table.Column<int>(type: "int", nullable: false),
                    RouteBusStopId = table.Column<int>(type: "int", nullable: false),
                    PreviousYearFees = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRte = table.Column<bool>(type: "bit", nullable: false),
                    DateOfRelieving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasGraduated = table.Column<bool>(type: "bit", nullable: false),
                    GraduatedYearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_AcademicYear_GraduatedYearId",
                        column: x => x.GraduatedYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId");
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "LocalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_RouteBusStops_RouteBusStopId",
                        column: x => x.RouteBusStopId,
                        principalTable: "RouteBusStops",
                        principalColumn: "RouteBusStopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditorExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditorExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditorExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditorExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuxiloExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuxiloExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuxiloExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuxiloExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillPaymentHistory",
                columns: table => new
                {
                    BillPaymentHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    BillNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPaymentHistory", x => x.BillPaymentHistoryId);
                    table.ForeignKey(
                        name: "FK_BillPaymentHistory_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksAndNotesExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAndNotesExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAndNotesExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksAndNotesExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingMaterialExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingMaterialExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingMaterialExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingMaterialExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CableExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ConnectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CableExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CableExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CableExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CerimonyExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CerimonyExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CerimonyExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CerimonyExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionLabourExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ConstructionLabourType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionLabourExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstructionLabourExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructionLabourExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityBoardExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ServiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBoardExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityBoardExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityBoardExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Litres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdometerValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuelExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuelExpenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ExpenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternetExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ConnectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternetExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternetExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonEmiLoanPrincipalExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonEmiLoanPrincipalExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonEmiLoanPrincipalExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NonEmiLoanPrincipalExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutsideLoanExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    InterestMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutsideLoanExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutsideLoanExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutsideLoanExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RenewalAndLicenseExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    LicenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewalAndLicenseExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RenewalAndLicenseExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RenewalAndLicenseExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    SalaryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NonTeaching = table.Column<int>(type: "int", nullable: false),
                    Teaching = table.Column<int>(type: "int", nullable: false),
                    Others = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationaryExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    StationaryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationaryExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationaryExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationaryExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelephoneExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelAllowanceExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAllowanceExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelAllowanceExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelAllowanceExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniformExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ShirtMetres = table.Column<float>(type: "real", nullable: false),
                    PantMetres = table.Column<float>(type: "real", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniformExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniformExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniformExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeesExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeesType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeesExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleFeesExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeesExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeesExpenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMaintenanceExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMaintenanceExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleMaintenanceExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleMaintenanceExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleMaintenanceExpenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePurchaseExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePurchaseExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePurchaseExpenses_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePurchaseExpenses_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePurchaseExpenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeesHistories",
                columns: table => new
                {
                    BillNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TuitionFees = table.Column<int>(type: "int", nullable: false),
                    SchoolManagementFees = table.Column<int>(type: "int", nullable: false),
                    BookFees = table.Column<int>(type: "int", nullable: false),
                    ExamFees = table.Column<int>(type: "int", nullable: false),
                    BusFees = table.Column<int>(type: "int", nullable: false),
                    SpecialClassFees = table.Column<int>(type: "int", nullable: false),
                    UniformFees = table.Column<int>(type: "int", nullable: false),
                    PreviousYearFees = table.Column<int>(type: "int", nullable: false),
                    MiscellaneousFees = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    TotalFeesPaid = table.Column<int>(type: "int", nullable: false),
                    PaidOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesHistories", x => x.BillNumber);
                    table.ForeignKey(
                        name: "FK_FeesHistories_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeesHistories_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeesHistoryArchives",
                columns: table => new
                {
                    FeesHistoryArchiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    BillNumber = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TuitionFees = table.Column<int>(type: "int", nullable: false),
                    SchoolManagementFees = table.Column<int>(type: "int", nullable: false),
                    BookFees = table.Column<int>(type: "int", nullable: false),
                    ExamFees = table.Column<int>(type: "int", nullable: false),
                    BusFees = table.Column<int>(type: "int", nullable: false),
                    SpecialClassFees = table.Column<int>(type: "int", nullable: false),
                    UniformFees = table.Column<int>(type: "int", nullable: false),
                    PreviousYearFees = table.Column<int>(type: "int", nullable: false),
                    MiscellaneousFees = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    TotalFeesPaid = table.Column<int>(type: "int", nullable: false),
                    PaidOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesHistoryArchives", x => x.FeesHistoryArchiveId);
                    table.ForeignKey(
                        name: "FK_FeesHistoryArchives_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeesHistoryArchives_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentArchives",
                columns: table => new
                {
                    StudentArchiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    RouteBusStopId = table.Column<int>(type: "int", nullable: false),
                    PreviousYearFees = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentArchives", x => x.StudentArchiveId);
                    table.ForeignKey(
                        name: "FK_StudentArchives_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentArchives_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentArchives_RouteBusStops_RouteBusStopId",
                        column: x => x.RouteBusStopId,
                        principalTable: "RouteBusStops",
                        principalColumn: "RouteBusStopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentArchives_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRegistrationHistories",
                columns: table => new
                {
                    StudentRegistrationHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AdmissionNumber = table.Column<int>(type: "int", nullable: false),
                    JoiningClassId = table.Column<int>(type: "int", nullable: false),
                    RelievingClassId = table.Column<int>(type: "int", nullable: false),
                    JoiningAcademicYearId = table.Column<int>(type: "int", nullable: false),
                    RelievingAcademicYearId = table.Column<int>(type: "int", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRelieving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLastActiveRow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegistrationHistories", x => x.StudentRegistrationHistoryId);
                    table.ForeignKey(
                        name: "FK_StudentRegistrationHistories_AcademicYear_JoiningAcademicYearId",
                        column: x => x.JoiningAcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrationHistories_AcademicYear_RelievingAcademicYearId",
                        column: x => x.RelievingAcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrationHistories_Classes_JoiningClassId",
                        column: x => x.JoiningClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrationHistories_Classes_RelievingClassId",
                        column: x => x.RelievingClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrationHistories_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditorExpenses_BillId",
                table: "AuditorExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditorExpenses_ExpenseId",
                table: "AuditorExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AuxiloExpenses_BillId",
                table: "AuxiloExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_AuxiloExpenses_ExpenseId",
                table: "AuxiloExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPaymentHistory_BillId",
                table: "BillPaymentHistory",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ExpenseVendorMapperId",
                table: "Bills",
                column: "ExpenseVendorMapperId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAndNotesExpenses_BillId",
                table: "BooksAndNotesExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAndNotesExpenses_ExpenseId",
                table: "BooksAndNotesExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMaterialExpenses_BillId",
                table: "BuildingMaterialExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMaterialExpenses_ExpenseId",
                table: "BuildingMaterialExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_BusFeesArchives_AcademicYearId",
                table: "BusFeesArchives",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_BusFeesArchives_BusStopId",
                table: "BusFeesArchives",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_BusFeesArchives_RouteId",
                table: "BusFeesArchives",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_BusStops_LocalityId",
                table: "BusStops",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CableExpenses_BillId",
                table: "CableExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_CableExpenses_ExpenseId",
                table: "CableExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CerimonyExpenses_BillId",
                table: "CerimonyExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_CerimonyExpenses_ExpenseId",
                table: "CerimonyExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeesArchives_AcademicYearId",
                table: "ClassFeesArchives",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeesArchives_ClassId",
                table: "ClassFeesArchives",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionLabourExpenses_BillId",
                table: "ConstructionLabourExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionLabourExpenses_ExpenseId",
                table: "ConstructionLabourExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationExpenses_BillId",
                table: "DonationExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationExpenses_ExpenseId",
                table: "DonationExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityBoardExpenses_BillId",
                table: "ElectricityBoardExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityBoardExpenses_ExpenseId",
                table: "ElectricityBoardExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Name",
                table: "Expenses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseVendorMappers_ExpenseId",
                table: "ExpenseVendorMappers",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseVendorMappers_VendorId",
                table: "ExpenseVendorMappers",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistories_AcademicYearId",
                table: "FeesHistories",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistories_StudentId",
                table: "FeesHistories",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistoryArchives_AcademicYearId",
                table: "FeesHistoryArchives",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistoryArchives_StudentId",
                table: "FeesHistoryArchives",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelExpenses_BillId",
                table: "FuelExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelExpenses_ExpenseId",
                table: "FuelExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelExpenses_VehicleId",
                table: "FuelExpenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_BillId",
                table: "GeneralExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralExpenses_ExpenseId",
                table: "GeneralExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeExpenses_BillId",
                table: "HomeExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeExpenses_ExpenseId",
                table: "HomeExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetExpenses_BillId",
                table: "InternetExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetExpenses_ExpenseId",
                table: "InternetExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_NonEmiLoanPrincipalExpenses_BillId",
                table: "NonEmiLoanPrincipalExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_NonEmiLoanPrincipalExpenses_ExpenseId",
                table: "NonEmiLoanPrincipalExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomes_AcademicYearId",
                table: "OtherIncomes",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_OutsideLoanExpenses_BillId",
                table: "OutsideLoanExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_OutsideLoanExpenses_ExpenseId",
                table: "OutsideLoanExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_RenewalAndLicenseExpenses_BillId",
                table: "RenewalAndLicenseExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_RenewalAndLicenseExpenses_ExpenseId",
                table: "RenewalAndLicenseExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteBusStops_BusStopId",
                table: "RouteBusStops",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteBusStops_RouteId",
                table: "RouteBusStops",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RteIncomes_AcademicYearId",
                table: "RteIncomes",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryExpenses_BillId",
                table: "SalaryExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryExpenses_ExpenseId",
                table: "SalaryExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_StationaryExpenses_BillId",
                table: "StationaryExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_StationaryExpenses_ExpenseId",
                table: "StationaryExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArchives_AcademicYearId",
                table: "StudentArchives",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArchives_ClassId",
                table: "StudentArchives",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArchives_RouteBusStopId",
                table: "StudentArchives",
                column: "RouteBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArchives_StudentId",
                table: "StudentArchives",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationHistories_JoiningAcademicYearId",
                table: "StudentRegistrationHistories",
                column: "JoiningAcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationHistories_JoiningClassId",
                table: "StudentRegistrationHistories",
                column: "JoiningClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationHistories_RelievingAcademicYearId",
                table: "StudentRegistrationHistories",
                column: "RelievingAcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationHistories_RelievingClassId",
                table: "StudentRegistrationHistories",
                column: "RelievingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationHistories_StudentId",
                table: "StudentRegistrationHistories",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GraduatedYearId",
                table: "Students",
                column: "GraduatedYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LocalityId",
                table: "Students",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RouteBusStopId",
                table: "Students",
                column: "RouteBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SectionId",
                table: "Students",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneExpenses_BillId",
                table: "TelephoneExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneExpenses_ExpenseId",
                table: "TelephoneExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAllowanceExpenses_BillId",
                table: "TravelAllowanceExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAllowanceExpenses_ExpenseId",
                table: "TravelAllowanceExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_UniformExpenses_BillId",
                table: "UniformExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_UniformExpenses_ExpenseId",
                table: "UniformExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesMappings_RoleId",
                table: "UserRolesMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesMappings_UserName1",
                table: "UserRolesMappings",
                column: "UserName1");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeesExpenses_BillId",
                table: "VehicleFeesExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeesExpenses_ExpenseId",
                table: "VehicleFeesExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeesExpenses_VehicleId",
                table: "VehicleFeesExpenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenanceExpenses_BillId",
                table: "VehicleMaintenanceExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenanceExpenses_ExpenseId",
                table: "VehicleMaintenanceExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenanceExpenses_VehicleId",
                table: "VehicleMaintenanceExpenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePurchaseExpenses_BillId",
                table: "VehiclePurchaseExpenses",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePurchaseExpenses_ExpenseId",
                table: "VehiclePurchaseExpenses",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePurchaseExpenses_VehicleId",
                table: "VehiclePurchaseExpenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RegistrationNumber",
                table: "Vehicles",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Name_ComparisonName",
                table: "Vendors",
                columns: new[] { "Name", "ComparisonName" },
                unique: true);
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
