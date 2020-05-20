using System;

namespace PersonManagement.Business.Contracts.Interfaces
{
    public interface IPersonImporter : IDisposable
    {
        void ImportPersons();
    }
}