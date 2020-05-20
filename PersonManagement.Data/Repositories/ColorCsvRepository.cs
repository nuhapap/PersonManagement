using System;
using System.Collections.Generic;
using System.Linq;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.Data.Repositories
{
    public class ColorCsvRepository : IColorRepository
    {
        private bool _isDisposed;
        private static readonly List<Color> Colors = new List<Color>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

        public void Init()
        {
            Colors.Add(new Color { Id = 1, Name = "blau" });
            Colors.Add(new Color { Id = 2, Name = "grün" });
            Colors.Add(new Color { Id = 3, Name = "violett" });
            Colors.Add(new Color { Id = 4, Name = "rot" });
            Colors.Add(new Color { Id = 5, Name = "gelb" });
            Colors.Add(new Color { Id = 6, Name = "türkis" });
            Colors.Add(new Color { Id = 7, Name = "weiß" });
        }

        public IQueryable<Color> Find()
        {
            return Colors.AsQueryable();
        }
    }
}