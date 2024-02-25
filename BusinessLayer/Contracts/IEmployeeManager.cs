using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.DTOs;

namespace BusinessLayer.Contracts
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// Fetches paginated records of employees.
        /// </summary>
        /// <param name="pageNumber">Current page number</param>
        /// <param name="pageSize">Number of records per page</param>
        /// <returns></returns>
        Task<EmployeeDTO> EmployeeDetails(int pageNumber = 1, int pageSize = 10);

        /// <summary>
        /// Removes an employee.
        /// </summary>
        /// <param name="employeeId">Employee Id to remove.</param>
        /// <returns></returns>
        Task<bool> DeleteEmployee(long employeeId);
    }
}
