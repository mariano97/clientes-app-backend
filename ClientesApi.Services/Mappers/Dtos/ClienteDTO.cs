using System;
namespace ClientesApi.Services.Mappers.Dtos
{
	public class ClienteDTO
	{
        public int Idcliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public int Edad { get; set; }

        public string CorreoElectronico { get; set; } = null!;
    }
}

