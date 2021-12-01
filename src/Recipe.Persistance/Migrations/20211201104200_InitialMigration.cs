using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OakRecipes",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastmodifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OakRecipes", x => x.RecipeId);
                });

            migrationBuilder.InsertData(
                table: "OakRecipes",
                columns: new[] { "RecipeId", "CreatedBy", "CreatedDate", "LastModifiedDate", "LastmodifiedBy", "Name" },
                values: new object[] { new Guid("0cbdc785-fa2c-46b7-ae04-2b2315491230"), "Oakman Admin", new DateTime(2021, 12, 1, 10, 41, 59, 768, DateTimeKind.Utc).AddTicks(4551), null, null, "Oakmans favorite" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OakRecipes");
        }
    }
}
