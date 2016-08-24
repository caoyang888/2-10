using System.Data.Entity;

namespace _2_10.Model
{
    public class DbBase : DbContext
    {
        public DbBase() : base("2-10") { }
        public DbSet<TB_DataSource> TB_DataSource { get; set; }
        public DbSet<TB_ItemData> TB_ItemData { get; set; }
        public DbSet<TB_Product> TB_Product { get; set; }
        public DbSet<TB_ProductItem> TB_ProductItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
