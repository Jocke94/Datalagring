using Microsoft.EntityFrameworkCore;
using Sql_Console.Contexts;
using Sql_Console.Models;
using Sql_Console.Models.Entities;

namespace Sql_Console.Services;

internal class EmployeeService
{
    private static readonly DataContext _context = new DataContext();
    public static async Task AddEmployee(Employee newEmployee)
    {
        var _newEmployeeEntity = new EmployeeEntity
        {
            FirstName = newEmployee.FirstName,
            LastName = newEmployee.LastName,
            Email = newEmployee.Email,
            PhoneNumber = newEmployee.PhoneNumber
        };

        var _newAddressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.City == newEmployee.City && x.Address == newEmployee.Address);
        if (_newAddressEntity != null)
        {
            _newEmployeeEntity.AddressId = _newAddressEntity.Id;
        }
        else
        {
            _newEmployeeEntity.Address = new AddressEntity
            {
                City = newEmployee.City,
                Address = newEmployee.Address
            };
        }
        _context.Add(_newEmployeeEntity);
        await _context.SaveChangesAsync();
    }

    public static async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var _employees = new List<Employee>();
        foreach (var _employee in await _context.Employees.Include(x => x.Address).ToListAsync())
        {
            _employees.Add(new Employee
            {
                Id = _employee.Id,
                FirstName = _employee.FirstName,
                LastName = _employee.LastName,
                Email = _employee.Email,
                PhoneNumber = _employee.PhoneNumber,
                City = _employee.Address.City,
                Address = _employee.Address.Address
            });
        }
        return _employees;
    }

    public static async Task<Employee> GetEmployeeByEmailAsync(string email)
    {
        var _employee = await _context.Employees.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (_employee != null)
        {
            return new Employee
            {
                Id = _employee.Id,
                FirstName = _employee.FirstName,
                LastName = _employee.LastName,
                Email = _employee.Email,
                PhoneNumber = _employee.PhoneNumber,
                City = _employee.Address.City,
                Address = _employee.Address.Address
            };
        }
        else
        {
            return null!;
        }
    }

    public static async Task DeleteEmployeeAsync(string email)
    {
        var _employee = await _context.Employees.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (_employee != null)
        {
            _context.Remove(_employee);
            await _context.SaveChangesAsync();
        }
    }
}
