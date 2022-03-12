using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class RemoveSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_SubCategories_SubCategoryUid",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFiles_Products_ProductUid",
                table: "ProductFiles");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_SubCategoryUid",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryUid",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductUid",
                table: "ProductFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFiles_Products_ProductUid",
                table: "ProductFiles",
                column: "ProductUid",
                principalTable: "Products",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFiles_Products_ProductUid",
                table: "ProductFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductUid",
                table: "ProductFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryUid",
                table: "ProductCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryUid",
                        column: x => x.CategoryUid,
                        principalTable: "Categories",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_SubCategoryUid",
                table: "ProductCategories",
                column: "SubCategoryUid");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryUid",
                table: "SubCategories",
                column: "CategoryUid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_SubCategories_SubCategoryUid",
                table: "ProductCategories",
                column: "SubCategoryUid",
                principalTable: "SubCategories",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFiles_Products_ProductUid",
                table: "ProductFiles",
                column: "ProductUid",
                principalTable: "Products",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
