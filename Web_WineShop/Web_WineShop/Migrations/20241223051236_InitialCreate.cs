using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_WineShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRAND",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Collab = table.Column<bool>(type: "bit", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRAND", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORY_CATEGORY_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CATEGORY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DETAIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ABV = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Varietal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAIL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KNOWLEDGE",
                columns: table => new
                {
                    ID_KNOWLEDGE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CATEGORY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UPLOAD_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FILE_PATH = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNOWLEDGE", x => x.ID_KNOWLEDGE);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_STATE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATE_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_STATE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT_METHOD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_METHOD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REWARD_POINTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALUE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REWARD_POINTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SEND_TO_FRIEND",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FRIEND_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FRIEND_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YOUR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YOUR_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MESSAGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RECAPTCHA_RESPONSE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEND_TO_FRIEND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULLNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POINTS = table.Column<int>(type: "int", nullable: false),
                    RECEIVE_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BANK_ACC_DEFAULT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VOUCHER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERCENTAGE = table.Column<double>(type: "float", nullable: false),
                    MAX_DISCOUNT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOUCHER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BANK_ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BANK_ID = table.Column<int>(type: "int", nullable: false),
                    ACCOUNT_NO = table.Column<long>(type: "bigint", nullable: false),
                    BALANCE = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BANK_ACCOUNT_BANK_BANK_ID",
                        column: x => x.BANK_ID,
                        principalTable: "BANK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    DetailsId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductAppreciation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_BRAND_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BRAND",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_DETAIL_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "DETAIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false),
                    BAN = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_AMOUNT = table.Column<double>(type: "float", nullable: false),
                    IS_DELIVERED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDERS_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BANK_ACCOUNT_OWNER",
                columns: table => new
                {
                    BANK_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_ACCOUNT_OWNER", x => new { x.USER_ID, x.BANK_ACCOUNT_ID });
                    table.ForeignKey(
                        name: "FK_BANK_ACCOUNT_OWNER_BANK_ACCOUNT_BANK_ACCOUNT_ID",
                        column: x => x.BANK_ACCOUNT_ID,
                        principalTable: "BANK_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BANK_ACCOUNT_OWNER_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CART_ITEMS",
                columns: table => new
                {
                    ID_CART_ITEMS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART_ITEMS", x => x.ID_CART_ITEMS);
                    table.ForeignKey(
                        name: "FK_CART_ITEMS_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CART_ITEMS_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WISH_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WISH_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WISH_ITEM_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WISH_ITEM_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VIOLATE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIOLATE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VIOLATE_ACCOUNT_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VOUCHER_ID = table.Column<int>(type: "int", nullable: true),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAIL_ORDERS_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAIL_PAYMENT_METHOD_PAYMENT_METHOD_ID",
                        column: x => x.PAYMENT_METHOD_ID,
                        principalTable: "PAYMENT_METHOD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAIL_VOUCHER_VOUCHER_ID",
                        column: x => x.VOUCHER_ID,
                        principalTable: "VOUCHER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT_TRANSACTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_REF = table.Column<int>(type: "int", nullable: false),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANSACTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    METHOD_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_TRANSACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAYMENT_TRANSACTION_ORDERS_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAYMENT_TRANSACTION_PAYMENT_METHOD_METHOD_ID",
                        column: x => x.METHOD_ID,
                        principalTable: "PAYMENT_METHOD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DATES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DETAIL_ID = table.Column<int>(type: "int", nullable: false),
                    STATE_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DATES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_DATES_ORDER_DETAIL_DETAIL_ID",
                        column: x => x.DETAIL_ID,
                        principalTable: "ORDER_DETAIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DATES_ORDER_STATE_STATE_ID",
                        column: x => x.STATE_ID,
                        principalTable: "ORDER_STATE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEM",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    DETAIL_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    RATING = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEM", x => new { x.DETAIL_ID, x.PRODUCT_ID });
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_ORDER_DETAIL_DETAIL_ID",
                        column: x => x.DETAIL_ID,
                        principalTable: "ORDER_DETAIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_USER_ID",
                table: "ACCOUNT",
                column: "USER_ID",
                unique: true,
                filter: "[USER_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_ACCOUNT_BANK_ID",
                table: "BANK_ACCOUNT",
                column: "BANK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_ACCOUNT_OWNER_BANK_ACCOUNT_ID",
                table: "BANK_ACCOUNT_OWNER",
                column: "BANK_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_ITEMS_PRODUCT_ID",
                table: "CART_ITEMS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_ITEMS_USER_ID",
                table: "CART_ITEMS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_ParentId",
                table: "CATEGORY",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DATES_DETAIL_ID",
                table: "ORDER_DATES",
                column: "DETAIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DATES_STATE_ID",
                table: "ORDER_DATES",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAIL_ORDER_ID",
                table: "ORDER_DETAIL",
                column: "ORDER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAIL_PAYMENT_METHOD_ID",
                table: "ORDER_DETAIL",
                column: "PAYMENT_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAIL_VOUCHER_ID",
                table: "ORDER_DETAIL",
                column: "VOUCHER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_PRODUCT_ID",
                table: "ORDER_ITEM",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_USER_ID",
                table: "ORDERS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_TRANSACTION_METHOD_ID",
                table: "PAYMENT_TRANSACTION",
                column: "METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_TRANSACTION_ORDER_ID",
                table: "PAYMENT_TRANSACTION",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_BrandId",
                table: "PRODUCT",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CategoryId",
                table: "PRODUCT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DetailsId",
                table: "PRODUCT",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_VIOLATE_ACCOUNT_ID",
                table: "VIOLATE",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WISH_ITEM_PRODUCT_ID",
                table: "WISH_ITEM",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WISH_ITEM_USER_ID",
                table: "WISH_ITEM",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANK_ACCOUNT_OWNER");

            migrationBuilder.DropTable(
                name: "CART_ITEMS");

            migrationBuilder.DropTable(
                name: "KNOWLEDGE");

            migrationBuilder.DropTable(
                name: "ORDER_DATES");

            migrationBuilder.DropTable(
                name: "ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "PAYMENT_TRANSACTION");

            migrationBuilder.DropTable(
                name: "REWARD_POINTS");

            migrationBuilder.DropTable(
                name: "SEND_TO_FRIEND");

            migrationBuilder.DropTable(
                name: "VIOLATE");

            migrationBuilder.DropTable(
                name: "WISH_ITEM");

            migrationBuilder.DropTable(
                name: "BANK_ACCOUNT");

            migrationBuilder.DropTable(
                name: "ORDER_STATE");

            migrationBuilder.DropTable(
                name: "ORDER_DETAIL");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "BANK");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PAYMENT_METHOD");

            migrationBuilder.DropTable(
                name: "VOUCHER");

            migrationBuilder.DropTable(
                name: "BRAND");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "DETAIL");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
