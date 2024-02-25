using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using EmployeeManagement.DTOs;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contracts;
using RepositoryLayer.Models;

namespace BusinessLayer.Contretes
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IGeneralRepository<Employee, long> _employeeRepository;
        private readonly IGeneralRepository<Role, int> _roleRepository;

        public EmployeeManager(IGeneralRepository<Employee, long> employeeRepository, IGeneralRepository<Role, int> roleRepository)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> DeleteEmployee(long employeeId)
        {
            var employee = _employeeRepository.FindById(employeeId);

            if (employee != null)
            {
                // delete employee
                await _employeeRepository.DeleteAsync(employee);
                return true;
            }

            return false;
        }

        public async Task<EmployeeDTO> EmployeeDetails(int pageNumber = 1, int pageSize = 10)
        {
            var employees = _employeeRepository.List();
            var roles = _roleRepository.List();

            int totalRecords = await employees.CountAsync();
            employees = employees.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            // transform entity model to DTO to send to client.
            List<EmployeeDetail> employeeList = new List<EmployeeDetail>();

            /* 
             * Note: I could have acheived this using AutoFAC 
             * but due to time limitation i am just manually mapping entities.
            */
            foreach (var employee in employees.ToList())
            {
                employeeList.Add(new EmployeeDetail()
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.FirstName + " " + employee.LastName,
                    EmployeeNumber = employee.EmployeeNumber,
                    Extension = employee.Extension,
                    DateJoined = employee.DateJoined.Date,
                    Role = GetEmployeeRoleName(roles.ToList(), employee.RoleId)
                });
            }

            return new EmployeeDTO
            {
                TotalPages = totalRecords,
                Employees = employeeList.ToList()
            };
        }

        private string GetEmployeeRoleName(List<Role> roles, int? roleId)
        {
            // using fail first approach
            if (!roles.Any() || !roleId.HasValue)
            {
                return string.Empty;

            }

            return roles.FirstOrDefault(role => role.Id == roleId.Value).RoleName;
        }
    }
}
