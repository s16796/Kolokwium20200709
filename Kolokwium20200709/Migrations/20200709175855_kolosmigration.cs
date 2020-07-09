using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium20200709.Migrations
{
    public partial class kolosmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Art_Movements",
                columns: table => new
                {
                    IdArtMovement = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNextMovement = table.Column<int>(nullable: true),
                    IdMovementFounder = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    DateFounded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art_Movements", x => x.IdArtMovement);
                    table.ForeignKey(
                        name: "FK_Art_Movements_Art_Movements_IdNextMovement",
                        column: x => x.IdNextMovement,
                        principalTable: "Art_Movements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    IdCity = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Population = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    IdArtist = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArtMovement = table.Column<int>(nullable: false),
                    IdCityOfBirth = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Nickname = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Art_MovementIdArtMovement = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.IdArtist);
                    table.ForeignKey(
                        name: "FK_Artists_Art_Movements_Art_MovementIdArtMovement",
                        column: x => x.Art_MovementIdArtMovement,
                        principalTable: "Art_Movements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artists_Art_Movements_IdArtMovement",
                        column: x => x.IdArtMovement,
                        principalTable: "Art_Movements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artists_Cities_IdCityOfBirth",
                        column: x => x.IdCityOfBirth,
                        principalTable: "Cities",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    IdPainting = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceType = table.Column<string>(maxLength: 100, nullable: true),
                    PaintingMedia = table.Column<string>(maxLength: 100, nullable: true),
                    IdArtist = table.Column<int>(nullable: false),
                    IdCoArtist = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.IdPainting);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_IdCoArtist",
                        column: x => x.IdCoArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Art_Movements_IdNextMovement",
                table: "Art_Movements",
                column: "IdNextMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Art_MovementIdArtMovement",
                table: "Artists",
                column: "Art_MovementIdArtMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_IdArtMovement",
                table: "Artists",
                column: "IdArtMovement",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_IdCityOfBirth",
                table: "Artists",
                column: "IdCityOfBirth");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_IdArtist",
                table: "Paintings",
                column: "IdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_IdCoArtist",
                table: "Paintings",
                column: "IdCoArtist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Art_Movements");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
