using System;
using ClientesApi.Data.Models;

namespace ClientesApi.Services.Mappers.Dtos
{
	public class AsesorDTO
	{
        public int Idasesor { get; set; }

        public string Nombre { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public int ClienteId { get; set; }

        //public virtual Cliente Cliente { get; set; } = null!;
    }
}

