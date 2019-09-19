using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeStore.Products.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ssp");

            migrationBuilder.CreateTable(
                name: "Catalogues",
                schema: "ssp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "ssp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogueProduct",
                schema: "ssp",
                columns: table => new
                {
                    CatalogueProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatalogueId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueProduct", x => x.CatalogueProductId);
                    table.ForeignKey(
                        name: "FK_CatalogueProduct_Catalogues_CatalogueId",
                        column: x => x.CatalogueId,
                        principalSchema: "ssp",
                        principalTable: "Catalogues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogueProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ssp",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueProduct_CatalogueId",
                schema: "ssp",
                table: "CatalogueProduct",
                column: "CatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueProduct_ProductId",
                schema: "ssp",
                table: "CatalogueProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogueProduct",
                schema: "ssp");

            migrationBuilder.DropTable(
                name: "Catalogues",
                schema: "ssp");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "ssp");
        }
    }
}
