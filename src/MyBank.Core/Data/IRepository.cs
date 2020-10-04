using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Core.Data
{
    public interface IRepository<T> : IDisposable 
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
