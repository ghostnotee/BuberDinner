﻿using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;
public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value, value => MenuId.Create(value));
        builder.Property(x => x.Name)
               .HasMaxLength(100);
        builder.Property(m => m.Description)
               .HasMaxLength(100);
        builder.OwnsOne(m => m.AverageRating);
        builder.Property(m => m.HostId)
               .HasConversion(id => id.Value, value => HostId.Create(value));
    }
    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
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
                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");
                ib.Property(i => i.Id)
                .HasColumnName("MenuItemId")
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value, value => MenuItemId.Create(value));
                ib.Property(i => i.Name)
                  .HasMaxLength(100);
                ib.Property(i => i.Description)
                  .HasMaxLength(100);
            });
            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        builder.Metadata.FindNavigation(nameof(Menu.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");
            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");
            dib.Property(di => di.Value)
               .HasColumnName("DinnerId")
               .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, rib =>
        {
            rib.ToTable("MenuReviewIds");
            rib.WithOwner().HasForeignKey("MenuId");
            rib.HasKey("Id");
            rib.Property(d => d.Value)
               .HasColumnName("MenuReviewId")
               .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}