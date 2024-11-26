using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Table_Track.Models;
 
namespace Table_Track.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
        {
        }
        
 
        public DbSet<Customer> customers {  get; set; }
        public DbSet<SubmitReview> submits {  get; set; }
        public DbSet<OrderTable> orderTables {  get; set; }
        public DbSet<Cart> carts {  get; set; }
        public DbSet<OrderMenuItem> orderMenuItems {  get; set; }
        public DbSet<Supplier> suppliers {  get; set; }
        public DbSet<Inventory> Inventory {  get; set; }
        public DbSet<AssignedOrders> assignedOrders {  get; set; }
        public DbSet<Employee> employees {  get; set; }
        public DbSet<Category> categories {  get; set; }
        public DbSet<MenuItem> menuItems {  get; set; }
        public DbSet<Order> orders {  get; set; }
        public DbSet<RestaurantTable> tables {  get; set; }
        public DbSet<Reservation> reservations {  get; set; }
      }
}
