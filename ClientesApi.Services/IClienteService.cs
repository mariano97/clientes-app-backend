using System;
using ClientesApi.Services.Mappers.Dtos;

namespace ClientesApi.Services
{
	public interface IClienteService
	{

		Task<ClienteDTO> Guardar(ClienteDTO clienteDTO);
		Task<IEnumerable<ClienteDTO>> ConsultarAll();
		Task<ClienteDTO> FindById(int id);

	}
}

