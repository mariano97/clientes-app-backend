using System;
using AutoMapper;
using ClientesApi.Data.Models;
using ClientesApi.Services.Mappers.Dtos;

namespace ClientesApi.Services.Mappers.Profiles
{
	public class AsesorProfile : Profile
	{
		public AsesorProfile()
		{
			CreateMap<Asesor, AsesorDTO>();
            CreateMap<AsesorDTO, Asesor>();
        }
	}
}

