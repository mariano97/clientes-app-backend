using System;
using ClientesApi.Data.DbConfiguration;
using ClientesApi.Data.Models;
using ClientesApi.Domain.Repositories;
using ClientesApi.Domain.Repositories.Impl;
using ClientesApi.Services;
using ClientesApi.Services.Impl;
using ClientesApi.Services.Mappers.Profiles;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Configurations
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MySqlConnection");
			services.AddDbContext<DataBaseContext>(opt =>
			{
				opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));	
			});

			services.AddScoped<IRepositoryAsync<Asesor>, RepositoryAsyncImpl<Asesor>>();
            services.AddScoped<IRepositoryAsync<Cliente>, RepositoryAsyncImpl<Cliente>>();

			services.AddScoped<IAsesorService, AsesorServiceImpl>();
            services.AddScoped<IClienteService, ClienteServiceImpl>();

            services.AddAutoMapper(typeof(AsesorProfile));
            services.AddAutoMapper(typeof(ClienteProfile));

            return services;
		}
	}
}

