using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Contracts;

namespace RepositoryLayer.Models
{
    public class Role: IEntity<int>
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
