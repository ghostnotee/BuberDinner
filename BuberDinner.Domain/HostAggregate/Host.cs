using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;
public class Host : AggregateRoot<HostId, Guid>
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string ProfileImage { get; private set; } = null!;
    public AverageRating AverageRating { get; private set; }

    private readonly List<MenuId> _menuIds = new();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

    private readonly List<MenuId> _dinnerIds = new();
    public IReadOnlyList<MenuId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
}