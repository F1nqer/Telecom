using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class telecomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersPrefix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersPrefix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidersPrefix_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ProviderId",
                table: "Bills",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersPrefix_ProviderId",
                table: "ProvidersPrefix",
                column: "ProviderId");
            migrationBuilder.Sql(@"INSERT INTO [Telecom]..Providers
	                                VALUES (N'Altel'),
		                                    (N'Tele2'),
		                                    (N'Activ'),
                                            (N'Beeline')");
            migrationBuilder.Sql(@"INSERT INTO [Telecom]..ProvidersPrefix
	                                VALUES ('700', 1),
		                                    ('708', 1),
		                                    ('707', 2),
                                            ('747', 2),
                                            ('701', 3),
                                            ('777', 4),
                                            ('705', 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "ProvidersPrefix");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
