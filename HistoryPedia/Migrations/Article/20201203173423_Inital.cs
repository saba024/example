using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HistoryPedia.Migrations.Article
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kinds",
                columns: table => new
                {
                    KindId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinds", x => x.KindId);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShirtInfo = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    ImagePictureId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Pictures_ImagePictureId",
                        column: x => x.ImagePictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlocksInfo",
                columns: table => new
                {
                    BlockInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockName = table.Column<string>(nullable: true),
                    PrevId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    BlockImageName = table.Column<string>(nullable: true),
                    ImagePictureId = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlocksInfo", x => x.BlockInfoId);
                    table.ForeignKey(
                        name: "FK_BlocksInfo_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlocksInfo_Pictures_ImagePictureId",
                        column: x => x.ImagePictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    ChangeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.ChangeId);
                    table.ForeignKey(
                        name: "FK_Changes_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImagePictureId",
                table: "Articles",
                column: "ImagePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_BlocksInfo_ArticleId",
                table: "BlocksInfo",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_BlocksInfo_ImagePictureId",
                table: "BlocksInfo",
                column: "ImagePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_ArticleId",
                table: "Changes",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ArticleId",
                table: "Links",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlocksInfo");

            migrationBuilder.DropTable(
                name: "Changes");

            migrationBuilder.DropTable(
                name: "Kinds");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
