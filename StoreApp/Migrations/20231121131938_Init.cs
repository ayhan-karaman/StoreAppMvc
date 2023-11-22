using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(name: "category_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryname = table.Column<string>(name: "category_name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryid = table.Column<int>(name: "category_id", type: "integer", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: true),
                    imageurl = table.Column<string>(name: "image_url", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productid);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { 1, "Electronic" },
                    { 2, "Beyaz Eşya" },
                    { 3, "Hırdavat" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "product_id", "category_id", "image_url", "product_name", "price", "summary" },
                values: new object[,]
                {
                    { 1, 1, "/img/products/1.jpg", "Bilgisayar", 17500m, null },
                    { 2, 2, "/img/products/2.jpg", "Çamaşır makinası", 7100m, null },
                    { 3, 1, "/img/products/3.jpg", "Mouse", 500m, null },
                    { 4, 2, "/img/products/4.jpg", "Buz Dolabı", 8250m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
