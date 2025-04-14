using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Todos;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Users.Delete;

internal sealed class DeletetUserByEmailCommandHandler(IApplicationDbContext context, IUserContext userContext)
    : ICommandHandler<DeleteUserByEmailCommand, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(DeleteUserByEmailCommand command, CancellationToken cancellationToken)
    {
        User? userX = await context.Users.SingleOrDefaultAsync(t => t.Email == command.Email && t.Id == userContext.UserId, cancellationToken);
        if (userX is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFoundByEmail);
        }
        context.Users.Remove(userX);

        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success<UserResponse>(new UserResponse { Email= userX .Email});
    }
}
