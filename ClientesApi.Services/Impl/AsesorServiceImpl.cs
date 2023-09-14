using System;
using AutoMapper;
using ClientesApi.Data.Models;
using ClientesApi.Domain.Repositories;
using ClientesApi.Services.Mappers.Dtos;

namespace ClientesApi.Services.Impl
{
	public class AsesorServiceImpl : IAsesorService
    {

        private IRepositoryAsync<Asesor> _repository;
        private IMapper _mapper;

		public AsesorServiceImpl(IRepositoryAsync<Asesor> repository, IMapper mapper)
		{
            _mapper = mapper;
            _repository = repository;
		}

        public async Task<IEnumerable<AsesorDTO>> ConsultarAll()
        {
            var lista = await _repository.ConsultarAll();
            return _mapper.Map<IEnumerable<AsesorDTO>>(lista);
        }

        public async Task<AsesorDTO> FindById(int id)
        {
            var asesor = await _repository.ConsultarById(id);
            return _mapper.Map<AsesorDTO>(asesor);
        }

        public async Task<AsesorDTO> Guardar(AsesorDTO asesorDTO)
        {
            var asesor = _mapper.Map<Asesor>(asesorDTO);
            asesor = await _repository.Guardar(asesor);
            return _mapper.Map<AsesorDTO>(asesor);
        }
    }
}

