using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands;
public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create Menu
        var menu = Menu.Create(
            hostId: HostId.Create(Guid.Parse(request.HostId)),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                name: sections.Name,
                description: sections.Description,
                menuItems: sections.Items.ConvertAll(items => MenuItem.Create(
                    name: items.Name,
                    description: items.Description)))));
        // Persist Menu
        _menuRepository.Add(menu);

        // Return Menu
        return menu;
    }
}