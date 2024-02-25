using System;
using RepositoryLayer.Contracts;

namespace RepositoryLayer.Models
{
    public class Employee : IEntity<long>
    {
        public long Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; }
        public short? Extension { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
