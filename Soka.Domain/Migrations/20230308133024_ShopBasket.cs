using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soka.Domain.Migrations
{
    public partial class ShopBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Trophies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Trophies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Subscribers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Subscribers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "ProductCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Leagues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Leagues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPostComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "BlogPostComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => new { x.ProductId, x.CreatedByUserId });
                    table.ForeignKey(
                        name: "FK_Basket_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basket_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Types_CreatedByUserId",
                table: "Types",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_DeletedByUserId",
                table: "Types",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophies_CreatedByUserId",
                table: "Trophies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophies_DeletedByUserId",
                table: "Trophies",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedByUserId",
                table: "Tags",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DeletedByUserId",
                table: "Tags",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_CreatedByUserId",
                table: "Subscribers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DeletedByUserId",
                table: "Subscribers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_CreatedByUserId",
                table: "Sizes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_DeletedByUserId",
                table: "Sizes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CreatedByUserId",
                table: "Results",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_DeletedByUserId",
                table: "Results",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_CreatedByUserId",
                table: "ProductCatalog",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_DeletedByUserId",
                table: "ProductCatalog",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CreatedByUserId",
                table: "Matches",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_DeletedByUserId",
                table: "Matches",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CreatedByUserId",
                table: "Leagues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_DeletedByUserId",
                table: "Leagues",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CreatedByUserId",
                table: "Faqs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_DeletedByUserId",
                table: "Faqs",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPosts_CreatedByUserId",
                table: "ContactPosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPosts_DeletedByUserId",
                table: "ContactPosts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_CreatedByUserId",
                table: "Colors",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_DeletedByUserId",
                table: "Colors",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_DeletedByUserId",
                table: "Brands",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CreatedByUserId",
                table: "BlogPosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_DeletedByUserId",
                table: "BlogPosts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_CreatedByUserId",
                table: "BlogPostComments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_DeletedByUserId",
                table: "BlogPostComments",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_CreatedByUserId",
                table: "Basket",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_DeletedByUserId",
                table: "Basket",
                column: "DeletedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_CreatedByUserId",
                table: "BlogPostComments",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_DeletedByUserId",
                table: "BlogPostComments",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_CreatedByUserId",
                table: "BlogPosts",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_DeletedByUserId",
                table: "BlogPosts",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_DeletedByUserId",
                table: "Brands",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Users_CreatedByUserId",
                table: "Colors",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Users_DeletedByUserId",
                table: "Colors",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPosts_Users_CreatedByUserId",
                table: "ContactPosts",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPosts_Users_DeletedByUserId",
                table: "ContactPosts",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Users_CreatedByUserId",
                table: "Faqs",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Users_DeletedByUserId",
                table: "Faqs",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Users_CreatedByUserId",
                table: "Leagues",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Users_DeletedByUserId",
                table: "Leagues",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_CreatedByUserId",
                table: "Matches",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_DeletedByUserId",
                table: "Matches",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Users_CreatedByUserId",
                table: "ProductCatalog",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Users_DeletedByUserId",
                table: "ProductCatalog",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_CreatedByUserId",
                table: "Results",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_DeletedByUserId",
                table: "Results",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Users_CreatedByUserId",
                table: "Sizes",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Users_DeletedByUserId",
                table: "Sizes",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Users_CreatedByUserId",
                table: "Subscribers",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Users_DeletedByUserId",
                table: "Subscribers",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_CreatedByUserId",
                table: "Tags",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_DeletedByUserId",
                table: "Tags",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_Users_CreatedByUserId",
                table: "Trophies",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_Users_DeletedByUserId",
                table: "Trophies",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_CreatedByUserId",
                table: "Types",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_DeletedByUserId",
                table: "Types",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_DeletedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_DeletedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Users_CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Users_DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPosts_Users_CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPosts_Users_DeletedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Users_CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Users_DeletedByUserId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Users_CreatedByUserId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Users_DeletedByUserId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_CreatedByUserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_DeletedByUserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Users_CreatedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Users_DeletedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_CreatedByUserId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_DeletedByUserId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Users_CreatedByUserId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Users_DeletedByUserId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Users_CreatedByUserId",
                table: "Subscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Users_DeletedByUserId",
                table: "Subscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_DeletedByUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_Users_CreatedByUserId",
                table: "Trophies");

            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_Users_DeletedByUserId",
                table: "Trophies");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_CreatedByUserId",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_DeletedByUserId",
                table: "Types");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Types_CreatedByUserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_DeletedByUserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Trophies_CreatedByUserId",
                table: "Trophies");

            migrationBuilder.DropIndex(
                name: "IX_Trophies_DeletedByUserId",
                table: "Trophies");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_DeletedByUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_CreatedByUserId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DeletedByUserId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_CreatedByUserId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_DeletedByUserId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Results_CreatedByUserId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_DeletedByUserId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_CreatedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_DeletedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CreatedByUserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_DeletedByUserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_CreatedByUserId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_DeletedByUserId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_DeletedByUserId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_ContactPosts_CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropIndex(
                name: "IX_ContactPosts_DeletedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropIndex(
                name: "IX_Colors_CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_DeletedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_DeletedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Trophies");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Trophies");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "BlogPostComments");
        }
    }
}
