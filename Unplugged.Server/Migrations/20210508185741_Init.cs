using Microsoft.EntityFrameworkCore.Migrations;

namespace Unplugged.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<long>(type: "bigint", nullable: false),
                    StreamUrl = table.Column<string>(type: "text", nullable: true),
                    CoverData = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fio = table.Column<string>(type: "text", nullable: true),
                    RegistrationToken = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fio = table.Column<string>(type: "text", nullable: true),
                    ConnectInfo = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AdditionalFileUrls = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    EventId1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presentations_Events_EventId1",
                        column: x => x.EventId1,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presentations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PresentationId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    TotalRateValue = table.Column<double>(type: "double precision", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RateSpecies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RateId = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RateValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateSpecies_Rates_RateId",
                        column: x => x.RateId,
                        principalTable: "Rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConnectInfo", "Fio", "Login", "Password", "Role" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000000", "contact info", "Admin", "Admin", "QWEqwe123", 0 },
                    { "00000000-0000-0000-0000-000000000001", "contact info", "Moderator", "Moderator", "QWEqwe123", 1 },
                    { "00000000-0000-0000-0000-000000000002", "https://vk.com/mypag", "Трембрвецкий Николай", "koperniki", "org100h", 2 },
                    { "00000000-0000-0000-0000-000000000003", "contact info", "Куркутов Павел", "kpavel", "QWEqwe123", 2 },
                    { "00000000-0000-0000-0000-000000000004", "contact info", "Адаричев Вадим", "avadik", "QWEqwe123", 2 },
                    { "00000000-0000-0000-0000-000000000005", "contact info", "Библенко Артем", "bartem", "QWEqwe123", 2 }
                });

            migrationBuilder.InsertData(
                table: "Presentations",
                columns: new[] { "Id", "AdditionalFileUrls", "Description", "Duration", "EventId1", "Name", "UserId", "EventId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000102", "tap-fileserver/d1", "Плюсы и минусы программирования на flutter", 25, null, "Как я на флатере писал", "00000000-0000-0000-0000-000000000002", null },
                    { "00000000-0000-0000-0000-000000000202", "tap-fileserver/d2", "Минусов оказалось больше", 35, null, "Как я покончил с флатером", "00000000-0000-0000-0000-000000000002", null },
                    { "00000000-0000-0000-0000-000000000103", "tap-fileserver/d3", "Пишем свою rougelike рпг. Как не попасть в петлю.", 30, null, "Рогалики и сурки", "00000000-0000-0000-0000-000000000003", null },
                    { "00000000-0000-0000-0000-000000000203", "tap-fileserver/d4", "Или про то как я писал свою аркаду.", 20, null, "Каждый может быть манагером", "00000000-0000-0000-0000-000000000003", null },
                    { "00000000-0000-0000-0000-000000000104", "tap-fileserver/d5", "Что лучше python или .net core", 25, null, "Давим змею", "00000000-0000-0000-0000-000000000004", null },
                    { "00000000-0000-0000-0000-000000000204", "tap-fileserver/d6", "Реестр карьеров и возникшие там проблемы", 40, null, "Щель в земле", "00000000-0000-0000-0000-000000000004", null },
                    { "00000000-0000-0000-0000-000000000105", "tap-fileserver/d7", "Или почему в Маяке все не очень", 25, null, "Темно как в жо...", "00000000-0000-0000-0000-000000000005", null },
                    { "00000000-0000-0000-0000-000000000205", "tap-fileserver/d8", "лень было думать", 35, null, "Рандомный доклад", "00000000-0000-0000-0000-000000000005", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_EventId1",
                table: "Presentations",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_UserId",
                table: "Presentations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_PresentationId",
                table: "Rates",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_RateSpecies_RateId",
                table: "RateSpecies",
                column: "RateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateSpecies");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
