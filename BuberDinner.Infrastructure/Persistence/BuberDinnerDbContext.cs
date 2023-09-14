using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;
public class BuberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _interceptor;

    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, PublishDomainEventsInterceptor interceptor) : base(options)
    {
        _interceptor = interceptor;
    }

    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Dinner> Dinners { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<Host> Hosts { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<MenuReview> MenuReviews { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly); 
        base.OnModelCreating(modelBuilder);
    }
}