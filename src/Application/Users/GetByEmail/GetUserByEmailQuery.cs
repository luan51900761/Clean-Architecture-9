using Application.Abstractions.Messaging;

namespace Application.Users.GetByEmail;

public sealed record DeleteUserByEmailCommand(string Email) : IQuery<UserResponse>;
