using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Host_Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hosts",
                columns: new[] { "HostId", "Description", "Details", "Name" },
                values: new object[,]
                {
                    { new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"), "Linux host is a host for deploy linux  sites", "CPanel control panel,Web application firewall(WAF),Use uptodate hardwares", "Linux" },
                    { new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"), "Win host is a host for deploy .net core sites", "CPanel control panel,Unlimited DB,High speed,Backup automaticlly", "Win" }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "PlanId", "HostId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2db809a9-0e14-4cb1-a641-5582d3a78d41"), new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"), "Web host", 235.0 },
                    { new Guid("6f588d66-c351-42a5-969b-3f6354269c2e"), new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"), "Reseller host", 3000.0 },
                    { new Guid("94c2e095-2a52-4102-9e39-c225c39afc9d"), new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"), "VPS host", 7500.0 },
                    { new Guid("f5ea2b27-ddc6-465a-86db-66c2673d6bd3"), new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"), "Business host", 400.0 }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "FeatureId", "DbCount", "MySql", "PlanId", "Storage", "Traffic" },
                values: new object[,]
                {
                    { new Guid("3d490a90-94ce-4d15-9494-5248280c2ab2"), 2, true, new Guid("6f588d66-c351-42a5-969b-3f6354269c2e"), 500, 400 },
                    { new Guid("3d490a90-94ce-4d15-9494-5248280c2ac1"), 2, true, new Guid("94c2e095-2a52-4102-9e39-c225c39afc9d"), 600, 500 },
                    { new Guid("3d490a90-94ce-4d15-9494-5248280c2cd4"), 1, false, new Guid("f5ea2b27-ddc6-465a-86db-66c2673d6bd3"), 300, 400 },
                    { new Guid("3d490a90-94ce-4d15-9494-5248280c2ce3"), 1, true, new Guid("2db809a9-0e14-4cb1-a641-5582d3a78d41"), 200, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("3d490a90-94ce-4d15-9494-5248280c2ab2"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("3d490a90-94ce-4d15-9494-5248280c2ac1"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("3d490a90-94ce-4d15-9494-5248280c2cd4"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("3d490a90-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("2db809a9-0e14-4cb1-a641-5582d3a78d41"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("6f588d66-c351-42a5-969b-3f6354269c2e"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("94c2e095-2a52-4102-9e39-c225c39afc9d"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: new Guid("f5ea2b27-ddc6-465a-86db-66c2673d6bd3"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "HostId",
                keyValue: new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "HostId",
                keyValue: new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"));
        }
    }
}
