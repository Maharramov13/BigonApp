using BigonApp.Data.EFConfigurations;
using BigonApp.Infrastructure.Commons;
using BigonApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace BigonApp.Data.Contexts
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions opt) : base(opt) { }


        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Subscriber> Subsciribers { get; set; }
        public DbSet<Color> Colors { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                switch (item.State)
                {
                    case EntityState.Deleted:
                        item.State = EntityState.Modified;
                        item.Entity.DeletedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorConfigurations).Assembly);
        }
    }
}
