using System;
using System.Collections.Generic;
using RepositoryLayer.Models;

namespace EmployeeManagement.DTOs
{
    public class EmployeeDTO
    {
        public int TotalPages { get; set; }
        public List<EmployeeDetail> Employees { get; set; }
    }

    public class EmployeeDetail
    {
        public long EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateJoined { get; set; }
        public short? Extension { get; set; }
        public string Role { get; set; }
    }
}
