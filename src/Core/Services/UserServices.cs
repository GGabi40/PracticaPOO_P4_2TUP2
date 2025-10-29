
using Core.Dtos;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;


namespace Core.Services;

public class UserServices
{

    private readonly IUserRepository _userRepository;
    public UserServices(IUserRepository userRepository)
    {
       _userRepository = userRepository;
    }

    public List<UserDto> GetAllUsersInfo()
    {
        var list = _userRepository.List();
        if (list == null || !list.Any())
        {
            throw new Exception("No users found");
        }
        return UserDto.Create(list);


    }

    public UserDto GetUserInfo(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return UserDto.Create(user);
    }

public UserDto CreateUser( string UserName, string FirstName, string LastName, string Email, string Phone, string Password)
{
    var user = _userRepository.Add(new User
    {
        UserName = UserName,
        FirstName = FirstName,
        LastName = LastName,
        Email = Email,
        Phone = Phone,
        Password = Password
    });
    _userRepository.SaveChanges();
    return UserDto.Create(user);
}
 


    public UserDto UpdateUser( int id, int idDto, string UserName, string FirstName, string LastName, string Email, string Phone)
    {
        if (id != idDto)
        {
            throw new AppValidationException("User ID mismatch");
        }
        
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        user.UserName = UserName;
        user.FirstName = FirstName;
        user.LastName = LastName;
        user.Email = Email;
        user.Phone = Phone;

        _userRepository.Update(user);
        _userRepository.SaveChanges();
        return UserDto.Create(user);
    }


    public void DeleteUser(int id)
    {
        _userRepository.Delete(id);
         _userRepository.SaveChanges();
    }
}