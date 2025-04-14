using Application.Users.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class DeleteByEmail : IEndpoint
{
    public sealed record Request(string Email, string FirstName, string LastName, string Password);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("users/delete", async ([FromBody] Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var DeleteByEmailCommand = new DeleteUserByEmailCommand(request.Email);

            Result<UserResponse> result = await sender.Send(DeleteByEmailCommand, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Users);
    }

}
