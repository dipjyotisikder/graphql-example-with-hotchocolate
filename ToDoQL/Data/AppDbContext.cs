using Microsoft.EntityFrameworkCore;
using ToDoQL.Models;

namespace ToDoQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<ItemList> ItemLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(x =>
            {
                x.HasOne(i => i.ItemList)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.ListId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
