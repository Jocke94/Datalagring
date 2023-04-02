using Microsoft.EntityFrameworkCore;
using Sql_Console.Contexts;
using Sql_Console.Models;
using Sql_Console.Models.Entities;

namespace Sql_Console.Services;

internal class UserService
{
    private static readonly DataContext _context = new DataContext();
    public static async Task AddUser(User newUser)
    {
        var _newUserEntity = new UserEntity
        {
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            PhoneNumber = newUser.PhoneNumber
        };

        var _newAddressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.City == newUser.City && x.Address == newUser.Address);
        if (_newAddressEntity != null)
        {
            _newUserEntity.AddressId = _newAddressEntity.Id;
        }
        else
        {
            _newUserEntity.Address = new AddressEntity
            {
                City = newUser.City,
                Address = newUser.Address
            };
        }
        _context.Add(_newUserEntity);
        await _context.SaveChangesAsync();
    }

    public static async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var _users = new List<User>();
        foreach(var _user in await _context.Users.Include(x => x.Address).ToListAsync())
        {
            _users.Add(new User
            {
                Id = _user.Id,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Email = _user.Email,
                PhoneNumber = _user.PhoneNumber,
                City = _user.Address.City,
                Address = _user.Address.Address
            });
        }
        return _users;
    }

    public static async Task<User> GetUserByEmailAsync(string email)
    {
        var _user = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (_user != null)
        {
            return new User
            {
                Id = _user.Id,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Email = _user.Email,
                PhoneNumber = _user.PhoneNumber,
                City = _user.Address.City,
                Address = _user.Address.Address
            };
        }
        else
        {
            return null!;
        }
    }

    public static async Task DeleteUserAsync(string email)
    {
        var _user = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (_user != null)
        {
            _context.Remove(_user);
            await _context.SaveChangesAsync();
        }
    }
}
