using System;
using System.Linq;
using PersonManagement.Data.Contracts.Entities;

namespace PersonManagement.Data.Contracts.IRepositories
{
    public interface IColorRepository : IDisposable
    {
        IQueryable<Color> Find();

        void Init();
    }
}