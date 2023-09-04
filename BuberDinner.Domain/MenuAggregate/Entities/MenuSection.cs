using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;
public class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> menuItems) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }
    public static MenuSection Create(string name, string description, List<MenuItem> menuItems) => new(MenuSectionId.CreateUnique(), name, description, menuItems);
}