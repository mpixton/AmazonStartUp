using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonStartUp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthFirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AuthMidName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AuthLastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Classification = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
