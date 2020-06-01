using Microsoft.EntityFrameworkCore.Migrations;

namespace TorgObject.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PechatProducts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    District = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    FacilityArea = table.Column<string>(nullable: true),
                    NameOfBusinessEntity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PechatProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PechatProducts",
                columns: new[] { "Id", "District", "Name", "Area", "Address", "Period", "Number", "FacilityArea", "NameOfBusinessEntity" },
                values: new object[] { 1L, "СЗАО", "НТО ул. Авиационная, вл.68", "Щукино", "город Москва, Авиационная улица, дом 68", "с 1 января по 31 декабря", "НТО-09-02-002652", "9", "Компания ФРЕГАТ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PechatProducts");
        }
    }
}
