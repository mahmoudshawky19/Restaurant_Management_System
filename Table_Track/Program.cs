using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository;
using Table_Track.Repository.IRepository;
using Table_Track.Utility;

namespace Table_Track
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(
   option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
   ); 
            builder.Services.AddScoped<ISubmitReviewRepository, SubmitReviewRepository>();
  

            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IOrderMenuItemRepository, OrderMenuItemRepository>();
            builder.Services.AddScoped<IAssignedOrdersRepository, AssignedOrdersRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IOrderTableRepository, OrderTableRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();

            builder.Services.AddIdentity<
   ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];


            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
