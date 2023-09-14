using System;
using AutoMapper;
using ClientesApi.Data.Models;
using ClientesApi.Domain.Repositories;
using ClientesApi.Services.Mappers.Dtos;

namespace ClientesApi.Services.Impl
{
	public class ClienteServiceImpl : IClienteService
    {

        private IRepositoryAsync<Cliente> _repository;
        private IMapper _mapper;

		public ClienteServiceImpl(IRepositoryAsync<Cliente> repository, IMapper mapper)
		{
            _mapper = mapper;
            _repository = repository;
		}

        public async Task<IEnumerable<ClienteDTO>> ConsultarAll()
        {
            var lista = await _repository.ConsultarAll();
            return _mapper.Map<IEnumerable<ClienteDTO>>(lista);
        }

        public async Task<ClienteDTO> FindById(int id)
        {
            var cliente = await _repository.ConsultarById(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> Guardar(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente = await _repository.Guardar(cliente);
            return _mapper.Map<ClienteDTO>(cliente);

        }
    }
}

