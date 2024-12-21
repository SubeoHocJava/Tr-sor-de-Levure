﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_WineShop.Dao;

#nullable disable

namespace Web_WineShop.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241220094750_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_WineShop.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("Ban")
                        .HasColumnType("bit")
                        .HasColumnName("BAN");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSWORD");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("ROLE");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE");

                    b.HasKey("id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ACCOUNT");
                });

            modelBuilder.Entity("Web_WineShop.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("BANK");
                });

            modelBuilder.Entity("Web_WineShop.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("AccountNo")
                        .HasColumnType("bigint")
                        .HasColumnName("ACCOUNT_NO");

                    b.Property<double>("Balance")
                        .HasColumnType("float")
                        .HasColumnName("BALANCE");

                    b.Property<int>("BankId")
                        .HasColumnType("int")
                        .HasColumnName("BANK_ID");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("BANK_ACCOUNT");
                });

            modelBuilder.Entity("Web_WineShop.Models.BankAccountOwner", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID")
                        .HasColumnOrder(1);

                    b.Property<int>("BankAccountId")
                        .HasColumnType("int")
                        .HasColumnName("BANK_ACCOUNT_ID")
                        .HasColumnOrder(0);

                    b.HasKey("UserId", "BankAccountId");

                    b.ToTable("BANK_ACCOUNT_OWNER");
                });

            modelBuilder.Entity("Web_WineShop.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Collab")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("COLLAB");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("COUNTRY");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IMG");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("BRAND");
                });

            modelBuilder.Entity("Web_WineShop.Models.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.HasKey("UserId");

                    b.HasIndex("ProductId");

                    b.ToTable("CART_ITEM");
                });

            modelBuilder.Entity("Web_WineShop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATION_DATE");

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("DESCRIBE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CATEGORY");
                });

            modelBuilder.Entity("Web_WineShop.Models.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ABV")
                        .HasColumnType("float")
                        .HasColumnName("ABV");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("AGE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SIZE");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("STATUS");

                    b.Property<string>("Varietal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("VARIETAL");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("DETAIL");
                });

            modelBuilder.Entity("Web_WineShop.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELIVERED");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float")
                        .HasColumnName("TOTAL_AMOUNT");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("INVOICES");
                });

            modelBuilder.Entity("Web_WineShop.Models.Knowledge", b =>
                {
                    b.Property<int>("IdKnowledge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_KNOWLEDGE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKnowledge"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CATEGORY");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FILE_PATH");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TITLE");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPLOAD_DATE");

                    b.HasKey("IdKnowledge");

                    b.ToTable("Knowledges");
                });

            modelBuilder.Entity("Web_WineShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int")
                        .HasColumnName("INVOICE_ID");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_METHOD_ID");

                    b.Property<int>("VoucherId")
                        .HasColumnType("int")
                        .HasColumnName("VOUCHER_ID");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("VoucherId");

                    b.ToTable("ORDERS");
                });

            modelBuilder.Entity("Web_WineShop.Models.OrderDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_ID");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("STATE_ID");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StateId");

                    b.ToTable("ORDER_DATES");
                });

            modelBuilder.Entity("Web_WineShop.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_ID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("RATING");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ORDER_ITEMS");
                });

            modelBuilder.Entity("Web_WineShop.Models.OrderState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("STATE_NAME");

                    b.HasKey("Id");

                    b.ToTable("ORDER_STATE");
                });

            modelBuilder.Entity("Web_WineShop.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("PAYMENTMETHOD");
                });

            modelBuilder.Entity("Web_WineShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appreciation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("APPRECIATION");

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BRAND_ID");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY_ID");

                    b.Property<int?>("DetailsId")
                        .HasColumnType("int")
                        .HasColumnName("DETAILS_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("NAME");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("PRICE");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DetailsId")
                        .IsUnique()
                        .HasFilter("[DETAILS_ID] IS NOT NULL");

                    b.ToTable("PRODUCT");
                });

            modelBuilder.Entity("Web_WineShop.Models.RewardPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.Property<int>("Value")
                        .HasColumnType("int")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.ToTable("REWARD_POINTS");
                });

            modelBuilder.Entity("Web_WineShop.Models.SendToFriend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FRIEND_EMAIL");

                    b.Property<string>("FriendName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FRIEND_NAME");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MESSAGE");

                    b.Property<string>("RecaptchaResponse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RECAPTCHA_RESPONSE");

                    b.Property<string>("YourEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("YOUR_EMAIL");

                    b.Property<string>("YourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("YOUR_NAME");

                    b.HasKey("Id");

                    b.ToTable("SendToFriends");
                });

            modelBuilder.Entity("Web_WineShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BankAccountDefaultId")
                        .HasColumnType("int")
                        .HasColumnName("BANK_ACC_DEFAULT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COUNTRY");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DOB");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FULLNAME");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GENDER");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHONE");

                    b.Property<int>("Points")
                        .HasColumnType("int")
                        .HasColumnName("POINTS");

                    b.Property<string>("ReceiveAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RECEIVE_ADDRESS");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountDefaultId");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("Web_WineShop.Models.Violate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("ACCOUNT_ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("VIOLATE");
                });

            modelBuilder.Entity("Web_WineShop.Models.Voucher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("description")
                        .HasColumnType("int");

                    b.Property<double>("maxDiscount")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("percentage")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Web_WineShop.Models.WishItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("WishItems");
                });

            modelBuilder.Entity("Web_WineShop.Models.Account", b =>
                {
                    b.HasOne("Web_WineShop.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Web_WineShop.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_WineShop.Models.BankAccount", b =>
                {
                    b.HasOne("Web_WineShop.Models.Bank", "Bank")
                        .WithMany("BankAccounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Web_WineShop.Models.BankAccountOwner", b =>
                {
                    b.HasOne("Web_WineShop.Models.User", null)
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web_WineShop.Models.CartItem", b =>
                {
                    b.HasOne("Web_WineShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_WineShop.Models.Category", b =>
                {
                    b.HasOne("Web_WineShop.Models.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Web_WineShop.Models.Detail", b =>
                {
                    b.HasOne("Web_WineShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Web_WineShop.Models.Invoice", b =>
                {
                    b.HasOne("Web_WineShop.Models.User", null)
                        .WithMany("Invoices")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Web_WineShop.Models.Order", b =>
                {
                    b.HasOne("Web_WineShop.Models.Invoice", null)
                        .WithMany("Orders")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.Voucher", "Voucher")
                        .WithMany()
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Web_WineShop.Models.OrderDate", b =>
                {
                    b.HasOne("Web_WineShop.Models.Order", null)
                        .WithMany("Dates")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.OrderState", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Web_WineShop.Models.OrderItem", b =>
                {
                    b.HasOne("Web_WineShop.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Web_WineShop.Models.Product", b =>
                {
                    b.HasOne("Web_WineShop.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.Detail", "Detail")
                        .WithOne()
                        .HasForeignKey("Web_WineShop.Models.Product", "DetailsId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Detail");
                });

            modelBuilder.Entity("Web_WineShop.Models.User", b =>
                {
                    b.HasOne("Web_WineShop.Models.BankAccount", "BankAccountDefault")
                        .WithMany()
                        .HasForeignKey("BankAccountDefaultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccountDefault");
                });

            modelBuilder.Entity("Web_WineShop.Models.Violate", b =>
                {
                    b.HasOne("Web_WineShop.Models.Account", "Account")
                        .WithMany("Violates")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Web_WineShop.Models.WishItem", b =>
                {
                    b.HasOne("Web_WineShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_WineShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_WineShop.Models.Account", b =>
                {
                    b.Navigation("Violates");
                });

            modelBuilder.Entity("Web_WineShop.Models.Bank", b =>
                {
                    b.Navigation("BankAccounts");
                });

            modelBuilder.Entity("Web_WineShop.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Web_WineShop.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Web_WineShop.Models.Invoice", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Web_WineShop.Models.Order", b =>
                {
                    b.Navigation("Dates");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Web_WineShop.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("BankAccounts");

                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
