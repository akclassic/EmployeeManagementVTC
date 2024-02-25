using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Contracts
{
    public interface IEntity<Tkey> where Tkey : IEquatable<Tkey>
    {
        Tkey Id { get; }
    }
}
