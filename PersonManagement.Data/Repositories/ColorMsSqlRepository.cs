using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Data.Contexts;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.Data.Repositories
{
    public class ColorMsSqlRepository : IColorRepository
    {
        private bool _isDisposed;
        private PersonManagementDbContext _context;

        public ColorMsSqlRepository(PersonManagementDbContext context)
        {
            _context = context;
        }

        ~ColorMsSqlRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }

                _isDisposed = true;
            }
        }
        
        public IQueryable<Color> Find()
        {
            return _context.Colors.AsNoTracking();
        }

        public void Init()
        {
            _context.Colors.Add(new Color { Name = "blau" });
            _context.Colors.Add(new Color { Name = "grün" });
            _context.Colors.Add(new Color { Name = "violett" });
            _context.Colors.Add(new Color { Name = "rot" });
            _context.Colors.Add(new Color { Name = "gelb" });
            _context.Colors.Add(new Color { Name = "türkis" });
            _context.Colors.Add(new Color { Name = "weiß" });

            _context.SaveChanges();
        }

    }
}