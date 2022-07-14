using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace repository.Migrations
{
    public partial class changesNew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectImages_MainImageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_UploadedFiles_UploadedFileId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_MainImageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UploadedFileId",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "UploadedFileId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainImageId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MainImageId",
                table: "Projects",
                column: "MainImageId",
                unique: true,
                filter: "[MainImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UploadedFileId",
                table: "Projects",
                column: "UploadedFileId",
                unique: true,
                filter: "[UploadedFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectImages_MainImageId",
                table: "Projects",
                column: "MainImageId",
                principalTable: "ProjectImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_UploadedFiles_UploadedFileId",
                table: "Projects",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectImages_MainImageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_UploadedFiles_UploadedFileId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_MainImageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UploadedFileId",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "UploadedFileId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MainImageId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MainImageId",
                table: "Projects",
                column: "MainImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UploadedFileId",
                table: "Projects",
                column: "UploadedFileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectImages_MainImageId",
                table: "Projects",
                column: "MainImageId",
                principalTable: "ProjectImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_UploadedFiles_UploadedFileId",
                table: "Projects",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
