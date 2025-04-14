using Application.Abstractions.Messaging;

namespace Application.Users.Delete;

public sealed record DeleteUserByEmailCommand(string Email) : ICommand<UserResponse>;
