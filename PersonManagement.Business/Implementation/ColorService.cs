using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.Business.Implementation
{
    public class ColorService : IColorService
    {
        private IMapper _mapper;
        private IColorRepository _colorRepository;
        private bool _isDisposed;

        public ColorService(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
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
                    _mapper = null;

                    if (_colorRepository != null)
                    {
                        _colorRepository.Dispose();
                        _colorRepository = null;
                    }
                }

                _isDisposed = true;
            }
        }

        public List<ColorDto> GetColors()
        {
            var colors = _colorRepository.Find();
            return _mapper.Map<List<ColorDto>>(colors);
        }

        public void Init()
        {
            if (!_colorRepository.Find().Any())
            {
                _colorRepository.Init();
            }
        }
    }
}