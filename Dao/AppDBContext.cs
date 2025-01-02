using Microsoft.EntityFrameworkCore;
using Web_WineShop.Models;

namespace Web_WineShop.Dao
{
	public class AppDBContext : DbContext
	{

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

		public DbSet<Account> Accounts { get; set; }
		public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }  // Thêm dòng này
		public DbSet<BankAccountOwner> BankAccountOwners { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Detail> Details { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Knowledge> Knowledges { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
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
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<BankAccountOwner>().HasKey(bao => new { bao.UserId, bao.BankAccountId });
			modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.OrderDetailId, oi.ProductId });
		}


	}


}