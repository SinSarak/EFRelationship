using Microsoft.EntityFrameworkCore.Migrations;

namespace EFRelationship.Migrations
{
    public partial class FirstMigra3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => new { x.GameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_GameCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategories_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    path = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameResources_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Status", "Username" },
                values: new object[] { 1, 1, "Account1" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Status", "Username" },
                values: new object[] { 2, 1, "Account2" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Status", "Username" },
                values: new object[] { 3, 1, "Account3" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Status", "Username" },
                values: new object[] { 4, 1, "Account4" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 1, "Category1", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 2, "Category2", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 3, "Category3", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 4, "Category4", 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AccountId", "Name", "Status" },
                values: new object[] { 1, 1, "Game1", 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AccountId", "Name", "Status" },
                values: new object[] { 2, 2, "Game2", 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AccountId", "Name", "Status" },
                values: new object[] { 3, 3, "Game3", 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AccountId", "Name", "Status" },
                values: new object[] { 4, 4, "Game4", 1 });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "GameId", "CategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "GameId", "CategoryId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "GameId", "CategoryId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "GameId", "CategoryId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "GameId", "CategoryId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "GameResources",
                columns: new[] { "Id", "GameId", "path", "type" },
                values: new object[] { 1, 1, "path1", "type1" });

            migrationBuilder.InsertData(
                table: "GameResources",
                columns: new[] { "Id", "GameId", "path", "type" },
                values: new object[] { 2, 1, "path2", "type1" });

            migrationBuilder.InsertData(
                table: "GameResources",
                columns: new[] { "Id", "GameId", "path", "type" },
                values: new object[] { 3, 1, "path3", "type1" });

            migrationBuilder.InsertData(
                table: "GameResources",
                columns: new[] { "Id", "GameId", "path", "type" },
                values: new object[] { 4, 2, "path4", "type1" });

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_CategoryId",
                table: "GameCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GameResources_GameId",
                table: "GameResources",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AccountId",
                table: "Games",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropTable(
                name: "GameResources");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
