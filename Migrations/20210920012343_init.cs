using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSchool_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birth = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[] { 1, "Bruce T ", "Doe" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[] { 2, "Julia T ", "Doe" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[] { 3, "John T ", "Doe" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birth", "Name", "Surname", "TeacherId" },
                values: new object[] { 1, "22/12/2002", "John", "Doe", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birth", "Name", "Surname", "TeacherId" },
                values: new object[] { 2, "12/06/1992", "Jane", "Doe", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birth", "Name", "Surname", "TeacherId" },
                values: new object[] { 3, "01/03/2000", "Gabriel", "Doe", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
