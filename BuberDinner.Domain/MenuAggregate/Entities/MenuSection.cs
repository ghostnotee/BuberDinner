using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;
public class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> menuItems) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }
    public static MenuSection Create(string name, string description, List<MenuItem> menuItems) => new(MenuSectionId.CreateUnique(), name, description, menuItems);

#pragma warning disable CS8618
    private MenuSection() { }
#pragma warning restore CS8618
}