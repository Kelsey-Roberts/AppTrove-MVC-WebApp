using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTroveV1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.AppId);
                });

            migrationBuilder.InsertData(
                table: "Apps",
                columns: new[] { "AppId", "Name", "Price", "Publisher" },
                values: new object[,]
                {
                    { 1, "Angry Birds", 0.0, "Rovio Entertainment" },
                    { 2, "Summoner's War", 0.0, "Com2Us" },
                    { 3, "Pokemon Go", 0.0, "Niantic" },
                    { 4, "Genshin Impact", 0.0, "Mihoyo" },
                    { 5, "Paprika Recipe Manager 3", 4.9900000000000002, "Hindsight Labs LLC" },
                    { 6, "RadarScope", 9.9900000000000002, "Base Velocity, LLC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
