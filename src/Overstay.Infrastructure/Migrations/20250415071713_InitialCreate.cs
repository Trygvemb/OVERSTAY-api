using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Overstay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisaTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    IsMultipleEntry = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DomainUsers_Users_Id",
                        column: x => x.Id,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailNotification = table.Column<bool>(type: "bit", nullable: false),
                    SmsNotification = table.Column<bool>(type: "bit", nullable: false),
                    PushNotification = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_DomainUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DomainUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisaTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visas_DomainUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DomainUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visas_VisaTypes_VisaTypeId",
                        column: x => x.VisaTypeId,
                        principalTable: "VisaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoCode", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "AFG", "Afghanistan" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "ALB", "Albania" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "DZA", "Algeria" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "AND", "Andorra" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "AGO", "Angola" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "ATG", "Antigua and Barbuda" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "ARG", "Argentina" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "ARM", "Armenia" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "AUS", "Australia" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "AUT", "Austria" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "AZE", "Azerbaijan" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "BHS", "Bahamas" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "BHR", "Bahrain" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "BGD", "Bangladesh" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "BRB", "Barbados" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "BLR", "Belarus" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "BEL", "Belgium" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "BLZ", "Belize" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "BEN", "Benin" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "BTN", "Bhutan" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "BOL", "Bolivia" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "BIH", "Bosnia and Herzegovina" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "BWA", "Botswana" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "BRA", "Brazil" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "BRN", "Brunei" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "BGR", "Bulgaria" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "BFA", "Burkina Faso" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "BDI", "Burundi" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "KHM", "Cambodia" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "CMR", "Cameroon" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "CAN", "Canada" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "CPV", "Cape Verde" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "CAF", "Central African Republic" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "TCD", "Chad" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "CHL", "Chile" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "CHN", "China" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "COL", "Colombia" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "COM", "Comoros" },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "COG", "Congo" },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "CRI", "Costa Rica" },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "HRV", "Croatia" },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "CUB", "Cuba" },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "CYP", "Cyprus" },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "CZE", "Czech Republic" },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "DNK", "Denmark" },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "DJI", "Djibouti" },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "DMA", "Dominica" },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "DOM", "Dominican Republic" },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "TLS", "East Timor" },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "ECU", "Ecuador" },
                    { new Guid("00000000-0000-0000-0000-000000000051"), "EGY", "Egypt" },
                    { new Guid("00000000-0000-0000-0000-000000000052"), "SLV", "El Salvador" },
                    { new Guid("00000000-0000-0000-0000-000000000053"), "GNQ", "Equatorial Guinea" },
                    { new Guid("00000000-0000-0000-0000-000000000054"), "ERI", "Eritrea" },
                    { new Guid("00000000-0000-0000-0000-000000000055"), "EST", "Estonia" },
                    { new Guid("00000000-0000-0000-0000-000000000056"), "ETH", "Ethiopia" },
                    { new Guid("00000000-0000-0000-0000-000000000057"), "FJI", "Fiji" },
                    { new Guid("00000000-0000-0000-0000-000000000058"), "FIN", "Finland" },
                    { new Guid("00000000-0000-0000-0000-000000000059"), "FRA", "France" },
                    { new Guid("00000000-0000-0000-0000-000000000060"), "GAB", "Gabon" },
                    { new Guid("00000000-0000-0000-0000-000000000061"), "GMB", "Gambia" },
                    { new Guid("00000000-0000-0000-0000-000000000062"), "GEO", "Georgia" },
                    { new Guid("00000000-0000-0000-0000-000000000063"), "DEU", "Germany" },
                    { new Guid("00000000-0000-0000-0000-000000000064"), "GHA", "Ghana" },
                    { new Guid("00000000-0000-0000-0000-000000000065"), "GRC", "Greece" },
                    { new Guid("00000000-0000-0000-0000-000000000066"), "GRD", "Grenada" },
                    { new Guid("00000000-0000-0000-0000-000000000067"), "GTM", "Guatemala" },
                    { new Guid("00000000-0000-0000-0000-000000000068"), "GIN", "Guinea" },
                    { new Guid("00000000-0000-0000-0000-000000000069"), "GNB", "Guinea-Bissau" },
                    { new Guid("00000000-0000-0000-0000-000000000070"), "GUY", "Guyana" },
                    { new Guid("00000000-0000-0000-0000-000000000071"), "HTI", "Haiti" },
                    { new Guid("00000000-0000-0000-0000-000000000072"), "HND", "Honduras" },
                    { new Guid("00000000-0000-0000-0000-000000000073"), "HUN", "Hungary" },
                    { new Guid("00000000-0000-0000-0000-000000000074"), "ISL", "Iceland" },
                    { new Guid("00000000-0000-0000-0000-000000000075"), "IND", "India" },
                    { new Guid("00000000-0000-0000-0000-000000000076"), "IDN", "Indonesia" },
                    { new Guid("00000000-0000-0000-0000-000000000077"), "IRN", "Iran" },
                    { new Guid("00000000-0000-0000-0000-000000000078"), "IRQ", "Iraq" },
                    { new Guid("00000000-0000-0000-0000-000000000079"), "IRL", "Ireland" },
                    { new Guid("00000000-0000-0000-0000-000000000080"), "ISR", "Israel" },
                    { new Guid("00000000-0000-0000-0000-000000000081"), "ITA", "Italy" },
                    { new Guid("00000000-0000-0000-0000-000000000082"), "JAM", "Jamaica" },
                    { new Guid("00000000-0000-0000-0000-000000000083"), "JPN", "Japan" },
                    { new Guid("00000000-0000-0000-0000-000000000084"), "JOR", "Jordan" },
                    { new Guid("00000000-0000-0000-0000-000000000085"), "KAZ", "Kazakhstan" },
                    { new Guid("00000000-0000-0000-0000-000000000086"), "KEN", "Kenya" },
                    { new Guid("00000000-0000-0000-0000-000000000087"), "KIR", "Kiribati" },
                    { new Guid("00000000-0000-0000-0000-000000000088"), "PRK", "North Korea" },
                    { new Guid("00000000-0000-0000-0000-000000000089"), "KOR", "South Korea" },
                    { new Guid("00000000-0000-0000-0000-000000000090"), "KWT", "Kuwait" },
                    { new Guid("00000000-0000-0000-0000-000000000091"), "KGZ", "Kyrgyzstan" },
                    { new Guid("00000000-0000-0000-0000-000000000092"), "LAO", "Laos" },
                    { new Guid("00000000-0000-0000-0000-000000000093"), "LVA", "Latvia" },
                    { new Guid("00000000-0000-0000-0000-000000000094"), "LBN", "Lebanon" },
                    { new Guid("00000000-0000-0000-0000-000000000095"), "LSO", "Lesotho" },
                    { new Guid("00000000-0000-0000-0000-000000000096"), "LBR", "Liberia" },
                    { new Guid("00000000-0000-0000-0000-000000000097"), "LBY", "Libya" },
                    { new Guid("00000000-0000-0000-0000-000000000098"), "LIE", "Liechtenstein" },
                    { new Guid("00000000-0000-0000-0000-000000000099"), "LTU", "Lithuania" },
                    { new Guid("00000000-0000-0000-0000-000000000100"), "LUX", "Luxembourg" },
                    { new Guid("00000000-0000-0000-0000-000000000101"), "MDG", "Madagascar" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "MWI", "Malawi" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "MYS", "Malaysia" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "MDV", "Maldives" },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "MLI", "Mali" },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "MLT", "Malta" },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "MHL", "Marshall Islands" },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "MRT", "Mauritania" },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "MUS", "Mauritius" },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "MEX", "Mexico" },
                    { new Guid("00000000-0000-0000-0000-000000000111"), "FSM", "Micronesia" },
                    { new Guid("00000000-0000-0000-0000-000000000112"), "MDA", "Moldova" },
                    { new Guid("00000000-0000-0000-0000-000000000113"), "MCO", "Monaco" },
                    { new Guid("00000000-0000-0000-0000-000000000114"), "MNG", "Mongolia" },
                    { new Guid("00000000-0000-0000-0000-000000000115"), "MNE", "Montenegro" },
                    { new Guid("00000000-0000-0000-0000-000000000116"), "MAR", "Morocco" },
                    { new Guid("00000000-0000-0000-0000-000000000117"), "MOZ", "Mozambique" },
                    { new Guid("00000000-0000-0000-0000-000000000118"), "MMR", "Myanmar" },
                    { new Guid("00000000-0000-0000-0000-000000000119"), "NAM", "Namibia" },
                    { new Guid("00000000-0000-0000-0000-000000000120"), "NRU", "Nauru" },
                    { new Guid("00000000-0000-0000-0000-000000000121"), "NPL", "Nepal" },
                    { new Guid("00000000-0000-0000-0000-000000000122"), "NLD", "Netherlands" },
                    { new Guid("00000000-0000-0000-0000-000000000123"), "NZL", "New Zealand" },
                    { new Guid("00000000-0000-0000-0000-000000000124"), "NIC", "Nicaragua" },
                    { new Guid("00000000-0000-0000-0000-000000000125"), "NER", "Niger" },
                    { new Guid("00000000-0000-0000-0000-000000000126"), "NGA", "Nigeria" },
                    { new Guid("00000000-0000-0000-0000-000000000127"), "MKD", "North Macedonia" },
                    { new Guid("00000000-0000-0000-0000-000000000128"), "NOR", "Norway" },
                    { new Guid("00000000-0000-0000-0000-000000000129"), "OMN", "Oman" },
                    { new Guid("00000000-0000-0000-0000-000000000130"), "PAK", "Pakistan" },
                    { new Guid("00000000-0000-0000-0000-000000000131"), "PLW", "Palau" },
                    { new Guid("00000000-0000-0000-0000-000000000132"), "PSE", "Palestine" },
                    { new Guid("00000000-0000-0000-0000-000000000133"), "PAN", "Panama" },
                    { new Guid("00000000-0000-0000-0000-000000000134"), "PNG", "Papua New Guinea" },
                    { new Guid("00000000-0000-0000-0000-000000000135"), "PRY", "Paraguay" },
                    { new Guid("00000000-0000-0000-0000-000000000136"), "PER", "Peru" },
                    { new Guid("00000000-0000-0000-0000-000000000137"), "PHL", "Philippines" },
                    { new Guid("00000000-0000-0000-0000-000000000138"), "POL", "Poland" },
                    { new Guid("00000000-0000-0000-0000-000000000139"), "PRT", "Portugal" },
                    { new Guid("00000000-0000-0000-0000-000000000140"), "QAT", "Qatar" },
                    { new Guid("00000000-0000-0000-0000-000000000141"), "ROU", "Romania" },
                    { new Guid("00000000-0000-0000-0000-000000000142"), "RUS", "Russia" },
                    { new Guid("00000000-0000-0000-0000-000000000143"), "RWA", "Rwanda" },
                    { new Guid("00000000-0000-0000-0000-000000000144"), "KNA", "Saint Kitts and Nevis" },
                    { new Guid("00000000-0000-0000-0000-000000000145"), "LCA", "Saint Lucia" },
                    { new Guid("00000000-0000-0000-0000-000000000146"), "VCT", "Saint Vincent and the Grenadines" },
                    { new Guid("00000000-0000-0000-0000-000000000147"), "WSM", "Samoa" },
                    { new Guid("00000000-0000-0000-0000-000000000148"), "SMR", "San Marino" },
                    { new Guid("00000000-0000-0000-0000-000000000149"), "STP", "Sao Tome and Principe" },
                    { new Guid("00000000-0000-0000-0000-000000000150"), "SAU", "Saudi Arabia" },
                    { new Guid("00000000-0000-0000-0000-000000000151"), "SEN", "Senegal" },
                    { new Guid("00000000-0000-0000-0000-000000000152"), "SRB", "Serbia" },
                    { new Guid("00000000-0000-0000-0000-000000000153"), "SYC", "Seychelles" },
                    { new Guid("00000000-0000-0000-0000-000000000154"), "SLE", "Sierra Leone" },
                    { new Guid("00000000-0000-0000-0000-000000000155"), "SGP", "Singapore" },
                    { new Guid("00000000-0000-0000-0000-000000000156"), "SVK", "Slovakia" },
                    { new Guid("00000000-0000-0000-0000-000000000157"), "SVN", "Slovenia" },
                    { new Guid("00000000-0000-0000-0000-000000000158"), "SLB", "Solomon Islands" },
                    { new Guid("00000000-0000-0000-0000-000000000159"), "SOM", "Somalia" },
                    { new Guid("00000000-0000-0000-0000-000000000160"), "ZAF", "South Africa" },
                    { new Guid("00000000-0000-0000-0000-000000000161"), "SSD", "South Sudan" },
                    { new Guid("00000000-0000-0000-0000-000000000162"), "ESP", "Spain" },
                    { new Guid("00000000-0000-0000-0000-000000000163"), "LKA", "Sri Lanka" },
                    { new Guid("00000000-0000-0000-0000-000000000164"), "SDN", "Sudan" },
                    { new Guid("00000000-0000-0000-0000-000000000165"), "SUR", "Suriname" },
                    { new Guid("00000000-0000-0000-0000-000000000166"), "SWE", "Sweden" },
                    { new Guid("00000000-0000-0000-0000-000000000167"), "CHE", "Switzerland" },
                    { new Guid("00000000-0000-0000-0000-000000000168"), "SYR", "Syria" },
                    { new Guid("00000000-0000-0000-0000-000000000169"), "TWN", "Taiwan" },
                    { new Guid("00000000-0000-0000-0000-000000000170"), "TJK", "Tajikistan" },
                    { new Guid("00000000-0000-0000-0000-000000000171"), "TZA", "Tanzania" },
                    { new Guid("00000000-0000-0000-0000-000000000172"), "THA", "Thailand" },
                    { new Guid("00000000-0000-0000-0000-000000000173"), "TGO", "Togo" },
                    { new Guid("00000000-0000-0000-0000-000000000174"), "TON", "Tonga" },
                    { new Guid("00000000-0000-0000-0000-000000000175"), "TTO", "Trinidad and Tobago" },
                    { new Guid("00000000-0000-0000-0000-000000000176"), "TUN", "Tunisia" },
                    { new Guid("00000000-0000-0000-0000-000000000177"), "TUR", "Turkey" },
                    { new Guid("00000000-0000-0000-0000-000000000178"), "TKM", "Turkmenistan" },
                    { new Guid("00000000-0000-0000-0000-000000000179"), "TUV", "Tuvalu" },
                    { new Guid("00000000-0000-0000-0000-000000000180"), "UGA", "Uganda" },
                    { new Guid("00000000-0000-0000-0000-000000000181"), "UKR", "Ukraine" },
                    { new Guid("00000000-0000-0000-0000-000000000182"), "ARE", "United Arab Emirates" },
                    { new Guid("00000000-0000-0000-0000-000000000183"), "GBR", "United Kingdom" },
                    { new Guid("00000000-0000-0000-0000-000000000184"), "USA", "United States" },
                    { new Guid("00000000-0000-0000-0000-000000000185"), "URY", "Uruguay" },
                    { new Guid("00000000-0000-0000-0000-000000000186"), "UZB", "Uzbekistan" },
                    { new Guid("00000000-0000-0000-0000-000000000187"), "VUT", "Vanuatu" },
                    { new Guid("00000000-0000-0000-0000-000000000188"), "VAT", "Vatican City" },
                    { new Guid("00000000-0000-0000-0000-000000000189"), "VEN", "Venezuela" },
                    { new Guid("00000000-0000-0000-0000-000000000190"), "VNM", "Vietnam" },
                    { new Guid("00000000-0000-0000-0000-000000000191"), "YEM", "Yemen" },
                    { new Guid("00000000-0000-0000-0000-000000000192"), "ZMB", "Zambia" },
                    { new Guid("00000000-0000-0000-0000-000000000193"), "ZWE", "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000000-1000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000001", "Admin", "ADMIN" },
                    { new Guid("00000000-1000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000002", "User", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-1000-0000-0000-000000000001"), 0, "ADMIN-CONCURRENCY-STAMP", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENfB6BxN/Z1wQz9vgEiJAL6xxWWlHfgK8JQkZ3XvjLlrqzYb6ASzjOYNkI/6OYvVeA==", null, false, "ADMIN-SECURITY-STAMP", false, "admin@example.com" },
                    { new Guid("00000000-1000-0000-0000-000000000002"), 0, "USER-CONCURRENCY-STAMP", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKK+8C5hcOKF5+HGekX1xHVdO/X8Wm1jlTeCMJLOhst9B4t1xUQZlniUiMCrzG5IXg==", null, false, "USER-SECURITY-STAMP", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "VisaTypes",
                columns: new[] { "Id", "Description", "DurationInDays", "IsMultipleEntry", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "For leisure travel and tourism purposes", 90, false, "Test Tourist Visa" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "For business meetings and commercial activities", 180, true, "Test Business Visa" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "For full-time students enrolled in educational institutions", 365, true, "Test Student Visa" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "For employment purposes", 365, true, "Test Work Visa" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "For passing through a country to reach another destination", 7, false, "Test Transit Visa" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "For diplomatic and official government visits", 180, true, "Test Diplomatic Visa" }
                });

            migrationBuilder.InsertData(
                table: "DomainUsers",
                columns: new[] { "Id", "CountryId", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-1000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000183"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-1000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000184"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-1000-0000-0000-000000000003"), new Guid("00000000-1000-0000-0000-000000000001") },
                    { new Guid("00000000-1000-0000-0000-000000000004"), new Guid("00000000-1000-0000-0000-000000000001") },
                    { new Guid("00000000-1000-0000-0000-000000000004"), new Guid("00000000-1000-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainUsers_CountryId",
                table: "DomainUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_UserId",
                table: "Visas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_VisaTypeId",
                table: "Visas",
                column: "VisaTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Visas");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "DomainUsers");

            migrationBuilder.DropTable(
                name: "VisaTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");
        }
    }
}
