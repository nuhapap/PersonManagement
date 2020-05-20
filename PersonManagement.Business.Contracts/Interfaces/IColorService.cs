using System;
using System.Collections.Generic;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.Business.Contracts.Interfaces
{
    public interface IColorService : IDisposable
    {
        List<ColorDto> GetColors();

        void Init();
    }
}