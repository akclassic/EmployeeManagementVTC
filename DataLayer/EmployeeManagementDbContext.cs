using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EmployeeManagementDbContext: DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
        : base(options)
        {
        }
    }
}
