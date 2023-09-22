using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.UserAggregate;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.ForType<User, User>().MapToConstructor(true);

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .MapWith(src => new AuthenticationResponse(src.User.Id.Value, src.User.FirstName, src.User.LastName, src.User.Email, src.Token));
    }
}