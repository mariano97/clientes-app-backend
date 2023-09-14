using System;
using AutoMapper;
using ClientesApi.Data.Models;
using ClientesApi.Services.Mappers.Dtos;

namespace ClientesApi.Services.Mappers.Profiles
{
	public class ClienteProfile : Profile
	{
		public ClienteProfile()
		{

			CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

        }
	}
}

