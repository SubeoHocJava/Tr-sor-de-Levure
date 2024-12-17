using Microsoft.EntityFrameworkCore;
using Web_WineShop.Models;

namespace Web_WineShop.Dao
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public AppDBContext() { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccountOwner> BankAccountOwners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDate> OrderDates { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<RewardPoints> RewardPoints { get; set; }
        public DbSet<SendToFriend> SendToFriends { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Violate> Violates { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<WishItem> WishItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bank
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();
                entity.Property(b => b.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
            });
            //BankAccount
            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("Bank_Account");
                entity.HasKey(ba => ba.Id);
                entity.Property(ba => ba.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();
                entity.Property(ba => ba.BankId)
                    .HasColumnName("Bank_Id")
                    .IsRequired();
                entity.Property(ba => ba.AccountNo)
                    .HasColumnName("Account_No")
                    .IsRequired();
                entity.Property(ba => ba.Balance)
                    .HasColumnName("Balance")
                    .HasColumnType("real")
                    .IsRequired();

                entity.HasOne(ba => ba.Bank)
                    .WithMany()
                    .HasForeignKey(ba => ba.BankId)
                    .IsRequired();
            });
            //BankAccountOwner
            modelBuilder.Entity<BankAccountOwner>(entity =>
            {
                entity.ToTable("Bank_Account_Owner");
                entity.HasKey(bao => new { bao.BankAccountId, bao.UserId });
                entity.Property(bao => bao.BankAccountId)
                .HasColumnName("Bank_Account_Id")
                .IsRequired();
                entity.Property(bao => bao.UserId)
                .HasColumnName("User_Id")
                .IsRequired();

                entity.HasOne(bao => bao.BankAccount)
                .WithMany()
                .HasForeignKey(bao => bao.BankAccountId);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
                entity.Property(u => u.Country)
                .HasColumnName("Country")
                .HasColumnType("varchar(20)");
                entity.Property(u => u.DoB)
                .HasColumnName("DoB");
                entity.Property(u => u.Points)
                .HasColumnName("Points");
                entity.Property(u => u.Gender)
                .HasColumnName("Gender")
                .HasColumnType("varchar(10)");
                entity.Property(u => u.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar(50)");
                entity.Property(u => u.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar(12)");

                entity.HasMany(u => u.Invoices)
                .WithOne()
                .HasForeignKey(i => i.CustomerId);
                entity.HasMany(u => u.BankAccounts)
                .WithOne()
                .HasForeignKey(bao => bao.UserId);
            });

            //Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");
                entity.Property(i => i.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

                entity.Property(i => i.IsDelivered)
                .HasColumnName("Is_Delivered");

                entity.Property(i => i.TotalAmount)
                .HasColumnName("Total_Amount");

                entity.HasMany(i => i.Orders)
                .WithOne()
                .HasForeignKey(o => o.InvoiceId);

            });
            //Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.Property(o => o.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
                entity.Property(o => o.VoucherId)
                .HasColumnName("Voucher_Id");
                entity.Property(o => o.InvoiceId)
                .HasColumnName("Invoice_Id");
                entity.Property(o => o.PaymentMethodId)
                .HasColumnName("Payment_Method_Id");

                entity.HasOne(o => o.PaymentMethod)
                .WithMany()
                .HasForeignKey(o => o.PaymentMethodId)
                .IsRequired();
                entity.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired();
                entity.HasMany(o => o.Dates)
                .WithOne()
                .HasForeignKey(od => od.OrderId)
                .IsRequired();
            });
            //OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");
                entity.HasKey(oi => new { oi.ProductId, oi.OrderId });
                entity.Property(oi => oi.ProductId)
                .HasColumnName("Product_Id");
                entity.Property(oi => oi.OrderId)
                .HasColumnName("Order_Id");
                entity.Property(oi => oi.Quantity)
                .HasColumnName("Quantity");
                entity.Property(oi => oi.Rating)
                .HasColumnName("Rating");

                entity.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired();
            });
            //PaymentMethod
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("Payment_Method");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id)
                .HasColumnName("Id");
                entity.Property(p => p.Name)
                .HasColumnName("Name");
            });
            //OrderDate
            modelBuilder.Entity<OrderDate>(entity =>
            {
                entity.ToTable("Order_Date");
                entity.HasKey(od => od.Id);
                entity.Property(od => od.Id)
                .HasColumnName("Id");
                entity.Property(od => od.StateId)
                .HasColumnName("State_Id");
                entity.Property(od => od.OrderId)
                .HasColumnName("Order_Id");
                entity.Property(od => od.Date)
                .HasColumnName("Date");

                entity.HasOne(od => od.State)
                .WithMany()
                .HasForeignKey(od => od.StateId)
                .IsRequired();
            });
            //OrderState
            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.ToTable("Order_State");
                entity.HasKey(os => os.Id);
                entity.Property(os => os.Id)
                .HasColumnName("Id");
                entity.Property(p => p.StateName)
                .HasColumnName("StateName");
            });
            //RewardPoints
            modelBuilder.Entity<RewardPoints>(entity =>
            {
                entity.ToTable("Reward_Points");
                entity.HasKey(rp => rp.Id);
                entity.Property(rp => rp.Id)
                .HasColumnName("Id");
                entity.Property(rp => rp.Name)
                .HasColumnName("Name");
                entity.Property(rp => rp.Value)
                .HasColumnName("Value");
            });
            //Voucher
            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(v => v.id);
                entity.ToTable("Voucher");
                entity.Property(v => v.id)
                .HasColumnName("Id");
                entity.Property(v => v.name).HasColumnName("Name").HasMaxLength(255).IsRequired();
                entity.Property(v => v.description).HasColumnName("Description").HasColumnType("varchar(200)");
                entity.Property(v => v.percentage).HasColumnName("Percentage").HasColumnType("decimal(5,2)");
                entity.Property(v => v.maxDiscount).HasColumnName("Max_Discount").HasColumnType("decimal(18,2)");
            });
            // Cấu hình SendToFriend
            modelBuilder.Entity<SendToFriend>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.ToTable("SendToFriend");
                entity.Property(s => s.Id)
                  .HasColumnName("Id")
                  .ValueGeneratedOnAdd();
                entity.Property(s => s.YourEmail)
                      .HasColumnName("YourEmail")
                      .HasMaxLength(255)
                      .IsRequired();
                entity.Property(s => s.FriendEmail)
                      .HasColumnName("FriendEmail")
                      .HasMaxLength(255)
                      .IsRequired();
                entity.Property(s => s.FriendName)
                      .HasColumnName("FriendName")
                      .HasMaxLength(255)
                      .IsRequired();
                entity.Property(s => s.Message)
                      .HasColumnName("Message")
                      .HasColumnType("varchar(1000)");
                entity.Property(s => s.RecaptchaResponse)
                      .HasColumnName("RecaptchaResponse")
                      .HasColumnType("varchar(255)");
            });
            // Cấu hình Knowledge
            modelBuilder.Entity<Knowledge>(entity =>
            {
                entity.HasKey(k => k.ID);
                entity.ToTable("Knowledge");
                entity.Property(k => k.ID)
                      .HasColumnName("Id");
                entity.Property(k => k.TITLE)
                      .HasColumnName("Title")
                      .HasMaxLength(255)
                      .IsRequired();
                entity.Property(k => k.CONTENT)
                      .HasColumnName("Content")
                      .HasColumnType("varchar(1000)")
                      .IsRequired();
                entity.Property(k => k.CREATE_DATE)
                      .HasColumnName("CreateDate")
                      .HasColumnType("datetime")
                      .IsRequired();
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("ID").IsRequired();
                entity.Property(c => c.ParentId).HasColumnName("PARENT_ID");
                entity.Property(c => c.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
                entity.Property(c => c.Describe).HasColumnName("DESCRIBE").HasMaxLength(500);
                entity.Property(c => c.CreationDate).HasColumnName("CREATION_DATE").HasColumnType("datetime").IsRequired();
                entity.Property(c => c.Status).HasColumnName("STATUS").HasMaxLength(50);

                entity.HasOne(c => c.ParentCategory)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(c => c.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).HasColumnName("ID").IsRequired();
                entity.Property(b => b.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
                entity.Property(b => b.Country).HasColumnName("COUNTRY").HasMaxLength(100);
                entity.Property(b => b.Img).HasColumnName("IMG");
                entity.Property(b => b.Collab).HasColumnName("COLLAB").HasMaxLength(50);
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.id);

                entity.Property(a => a.id)
                    .HasColumnName("ID")
                    .IsRequired();

                entity.Property(a => a.email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(a => a.password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(a => a.createDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(a => a.role)
                    .HasColumnName("ROLE")
                    .IsRequired();

                entity.Property(a => a.Ban)
                    .HasColumnName("BAN")
                    .IsRequired();


                entity.HasOne(a => a.violate)
                    .WithMany() // If Violate has a collection of Accounts, use .WithMany()
                    .HasForeignKey("ViolateId");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("ID").IsRequired();
                entity.Property(p => p.BrandId).HasColumnName("BRAND_ID").IsRequired();
                entity.Property(p => p.DetailsId).HasColumnName("DETAILS_ID");
                entity.Property(p => p.CategoryId).HasColumnName("CATEGORY_ID").IsRequired();
                entity.Property(p => p.Name).HasColumnName("NAME").HasMaxLength(200).IsRequired();
                entity.Property(p => p.Appreciation).HasColumnName("APPRECIATION");
                entity.Property(p => p.Status).HasColumnName("STATUS").HasMaxLength(50);

                // fk Brand
                entity.HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                // fk Category
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);


                // fk Details
                entity.HasOne(p => p.Detail)
                    .WithOne(d => d.Product)
                    .HasForeignKey<Product>(p => p.DetailsId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(p => p.DetailsId).IsUnique();
            });
            modelBuilder.Entity<Violate>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Id)
                    .HasColumnName("ID")
                    .IsRequired();

                entity.Property(v => v.description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(500)  // Adjust the max length as per your requirement
                    .IsRequired();
            });
            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Id).HasColumnName("ID").IsRequired();
                entity.Property(d => d.ProductId).HasColumnName("PRODUCT_ID").IsRequired();
                entity.Property(d => d.Description).HasColumnName("DESCRIPTION").HasMaxLength(500);
                entity.Property(d => d.Size).HasColumnName("SIZE").HasMaxLength(50);
                entity.Property(d => d.ABV).HasColumnName("ABV");
                entity.Property(d => d.Age).HasColumnName("AGE");
                entity.Property(d => d.Varietal).HasColumnName("VARIETAL").HasMaxLength(100);
                entity.Property(d => d.Status).HasColumnName("STATUS").HasMaxLength(50);


                // fk Product
                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Detail)
                    .HasForeignKey<Detail>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            // Cấu hình WishItemModel
            modelBuilder.Entity<WishItem>(entity =>
            {
                entity.HasKey(w => new { w.ProductId, w.UserId });
                entity.ToTable("WishItem");
                entity.HasOne(w => w.Product)
                      .WithMany()
                      .HasForeignKey(w => w.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(w => w.User)
               .WithMany()
               .HasForeignKey(w => w.UserId)
               .OnDelete(DeleteBehavior.Cascade);
            });
            //CartItem
            modelBuilder.Entity<CartItem>(entity =>
            {
                // Composite key
                entity.HasKey(c => new { c.UserId, c.ProductId });

                // Cấu hình thuộc tính
                entity.Property(c => c.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnType("int")
                .IsRequired();

                entity.Property(c => c.UserId)
                .HasColumnName("user_id")
                 .HasColumnType("int")
                .IsRequired();

                entity.Property(c => c.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnType("int")
                .IsRequired();
                // Quan hệ với Product
                entity.HasOne(c => c.Product)
                      .WithMany()
                      .HasForeignKey(c => c.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
                // Quan hệ với User
                entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            });

        }

    }
}


