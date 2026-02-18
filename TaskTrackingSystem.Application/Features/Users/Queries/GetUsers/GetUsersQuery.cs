using MediatR;
using TaskTrackingSystem.Application.Features.Users.DTOs;

namespace TaskTrackingSystem.Application.Features.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<IReadOnlyList<UserDto>>;
