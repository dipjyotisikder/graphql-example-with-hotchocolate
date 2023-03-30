using Microsoft.EntityFrameworkCore;
using ToDoQL.Models;

namespace ToDoQL.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }

        public virtual DbSet<ItemList> Lists { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemData>(x =>
            {
                x.HasOne(i => i.ItemList)
                .WithMany(i => i.ItemDatas)
                .HasForeignKey(i => i.ListId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ItemData_ItemList");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
