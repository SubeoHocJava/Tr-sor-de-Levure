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
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IMG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COLLAB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    PARENT_ID = table.Column<int>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRIBE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORY_CATEGORY_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    ID_KNOWLEDGE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATEGORY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPLOAD_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FILE_PATH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.ID_KNOWLEDGE);
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
                name: "PAYMENTMETHOD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTMETHOD", x => x.ID);
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
                name: "SendToFriends",
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
                    table.PrimaryKey("PK_SendToFriends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<int>(type: "int", nullable: false),
                    percentage = table.Column<double>(type: "float", nullable: false),
                    maxDiscount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.id);
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
                    BANK_ACC_DEFAULT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_BANK_ACCOUNT_BANK_ACC_DEFAULT",
                        column: x => x.BANK_ACC_DEFAULT,
                        principalTable: "BANK_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_BANK_ACCOUNT_OWNER_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_AMOUNT = table.Column<double>(type: "float", nullable: false),
                    IS_DELIVERED = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICES_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID");
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
                name: "ORDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VOUCHER_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICE_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDERS_INVOICES_INVOICE_ID",
                        column: x => x.INVOICE_ID,
                        principalTable: "INVOICES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_PAYMENTMETHOD_PAYMENT_METHOD_ID",
                        column: x => x.PAYMENT_METHOD_ID,
                        principalTable: "PAYMENTMETHOD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_Vouchers_VOUCHER_ID",
                        column: x => x.VOUCHER_ID,
                        principalTable: "Vouchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DATES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    STATE_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DATES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_DATES_ORDERS_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
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
                name: "CART_ITEM",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART_ITEM", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_CART_ITEM_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DETAIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SIZE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ABV = table.Column<double>(type: "float", nullable: false),
                    AGE = table.Column<int>(type: "int", nullable: false),
                    VARIETAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAIL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BRAND_ID = table.Column<int>(type: "int", nullable: false),
                    DETAILS_ID = table.Column<int>(type: "int", nullable: true),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false),
                    APPRECIATION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_BRAND_BRAND_ID",
                        column: x => x.BRAND_ID,
                        principalTable: "BRAND",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_DETAIL_DETAILS_ID",
                        column: x => x.DETAILS_ID,
                        principalTable: "DETAIL",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    RATING = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => new { x.ORDER_ID, x.PRODUCT_ID });
                    table.ForeignKey(
                        name: "FK_ORDER_ITEMS_ORDERS_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEMS_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WishItems_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishItems_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_USER_ID",
                table: "ACCOUNT",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BANK_ACCOUNT_BANK_ID",
                table: "BANK_ACCOUNT",
                column: "BANK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_ITEM_PRODUCT_ID",
                table: "CART_ITEM",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_PARENT_ID",
                table: "CATEGORY",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DETAIL_PRODUCT_ID",
                table: "DETAIL",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_UserId",
                table: "INVOICES",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DATES_ORDER_ID",
                table: "ORDER_DATES",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DATES_STATE_ID",
                table: "ORDER_DATES",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEMS_PRODUCT_ID",
                table: "ORDER_ITEMS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_INVOICE_ID",
                table: "ORDERS",
                column: "INVOICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_PAYMENT_METHOD_ID",
                table: "ORDERS",
                column: "PAYMENT_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_VOUCHER_ID",
                table: "ORDERS",
                column: "VOUCHER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_BRAND_ID",
                table: "PRODUCT",
                column: "BRAND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CATEGORY_ID",
                table: "PRODUCT",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DETAILS_ID",
                table: "PRODUCT",
                column: "DETAILS_ID",
                unique: true,
                filter: "[DETAILS_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USER_BANK_ACC_DEFAULT",
                table: "USER",
                column: "BANK_ACC_DEFAULT");

            migrationBuilder.CreateIndex(
                name: "IX_VIOLATE_ACCOUNT_ID",
                table: "VIOLATE",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WishItems_PRODUCT_ID",
                table: "WishItems",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WishItems_USER_ID",
                table: "WishItems",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CART_ITEM_PRODUCT_PRODUCT_ID",
                table: "CART_ITEM",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DETAIL_PRODUCT_PRODUCT_ID",
                table: "DETAIL",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DETAIL_PRODUCT_PRODUCT_ID",
                table: "DETAIL");

            migrationBuilder.DropTable(
                name: "BANK_ACCOUNT_OWNER");

            migrationBuilder.DropTable(
                name: "CART_ITEM");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "ORDER_DATES");

            migrationBuilder.DropTable(
                name: "ORDER_ITEMS");

            migrationBuilder.DropTable(
                name: "REWARD_POINTS");

            migrationBuilder.DropTable(
                name: "SendToFriends");

            migrationBuilder.DropTable(
                name: "VIOLATE");

            migrationBuilder.DropTable(
                name: "WishItems");

            migrationBuilder.DropTable(
                name: "ORDER_STATE");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "PAYMENTMETHOD");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "BANK_ACCOUNT");

            migrationBuilder.DropTable(
                name: "BANK");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "BRAND");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "DETAIL");
        }
    }
}
