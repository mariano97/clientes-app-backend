using System;
using ClientesApi.Services.Mappers.Dtos;

namespace ClientesApi.Services
{
	public interface IAsesorService
	{

		Task<AsesorDTO> Guardar(AsesorDTO asesor);
		Task<IEnumerable<AsesorDTO>> ConsultarAll();
		Task<AsesorDTO> FindById(int id);

	}
}

