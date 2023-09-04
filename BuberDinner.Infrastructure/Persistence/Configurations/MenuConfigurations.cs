using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;
public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value, value => MenuId.Create(value));
        builder.Property(x => x.Name)
               .HasMaxLength(100);
        builder.Property(x => x.Description)
               .HasMaxLength(100);
        builder.OwnsOne(x => x.AverageRating);
        builder.Property(x => x.HostId)
               .HasConversion(id => id.Value, value => HostId.Create(value));
    }
    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.Sections, sb =>
        {
            sb.ToTable("MenuSections");
            sb.WithOwner().HasForeignKey("MenuId");
            sb.HasKey("Id", "MenuId");
            sb.Property(s => s.Id)
              .HasColumnName("MenuSectionId")
              .ValueGeneratedNever()
              .HasConversion(id => id.Value, value => MenuSectionId.Create(value));
            sb.Property(s => s.Name)
              .HasMaxLength(100);
            sb.Property(s => s.Description)
              .HasMaxLength(100);
            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");
                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                ib.Property(i => i.Id)
                .HasColumnName("MenuItemId")
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value, value => MenuItemId.Create(value));
                ib.Property(i => i.Name)
                  .HasMaxLength(100);
                ib.Property(i => i.Description)
                  .HasMaxLength(100);
            });
        });
    }
}