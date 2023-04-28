using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hairSalonScheduler.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfileImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Availability = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    StylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StylistAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    StylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StylistAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StylistAvailabilities_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SelectedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StylistId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Gender", "LoyaltyPoints", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown USA", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@gmail.com", 1, 100, "Alice Smith", "password123" },
                    { 2, "456 High St, Anytown USA", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@gmail.com", 0, 50, "Bob Johnson", "password123" },
                    { 3, "789 Maple Ave, Anytown USA", new DateTime(1995, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie@gmail.com", 2, 200, "Charlie Brown", "password123" }
                });

            migrationBuilder.InsertData(
                table: "Stylists",
                columns: new[] { "Id", "Bio", "Gender", "Name", "ProfileImage" },
                values: new object[,]
                {
                    { 1, "Experienced stylist with over 10 years in the industry", "Male", "John Doe", "https://via.placeholder.com/150" },
                    { 2, "Expert in cutting-edge styles and techniques", "Female", "Jane Doe", "https://via.placeholder.com/150" },
                    { 3, "Specializes in coloring and highlights", "Male", "Mark Smith", "https://via.placeholder.com/150" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Availability", "Category", "Price", "StylistId" },
                values: new object[,]
                {
                    { 1, "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16", "Haircut", 50.00m, 1 },
                    { 2, "Mon:9-17,Tue:9-17,Wed:9-17,Thu:9-17,Fri:9-17,Sat:9-15", "Haircut", 45.00m, 2 },
                    { 3, "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16", "Haircut", 55.00m, 3 },
                    { 5, "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16", "Coloring", 120.00m, 1 },
                    { 6, "Mon:9-17,Tue:9-17,Wed:9-17,Thu:9-17,Fri:9-17,Sat:9-15", "Coloring", 130.00m, 2 },
                    { 7, "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16", "Coloring", 110.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CustomerId", "PaymentStatus", "SelectedDateTime", "ServiceId", "Status", "StylistId" },
                values: new object[,]
                {
                    { 1, 1, "Unpaid", new DateTime(2023, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Scheduled", 1 },
                    { 2, 2, "Unpaid", new DateTime(2023, 5, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, "Scheduled", 2 },
                    { 3, 3, "Unpaid", new DateTime(2023, 5, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, "Scheduled", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StylistId",
                table: "Appointments",
                column: "StylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_StylistId",
                table: "Services",
                column: "StylistId");

            migrationBuilder.CreateIndex(
                name: "IX_StylistAvailabilities_StylistId",
                table: "StylistAvailabilities",
                column: "StylistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "StylistAvailabilities");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Stylists");
        }
    }
}
