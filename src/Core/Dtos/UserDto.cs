using System;
using Core.Entities;

namespace Core.Dtos;

public record UserDto(int Id,Guid ExternalId, string UserName, string FirstName, string LastName, string Email, string Phone, string Password)
{
    public static UserDto Create(User user)
    {
        return new UserDto(
            user.Id,
            user.ExternalId ?? Guid.Empty,
            user.UserName,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            user.Password
           );

    }

    public static List<UserDto> Create(IEnumerable<User> users)
    {
        return users.Select(user => Create(user)).ToList();
    }
}


