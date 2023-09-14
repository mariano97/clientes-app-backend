using System;
namespace ClientesApi.Domain.Repositories
{
	public interface IRepositoryAsync<T> : IDisposable where T : class
	{

		Task<T> Guardar(T entity);

		Task<IEnumerable<T>> ConsultarAll();

		Task<T> ConsultarById(int id);

	}
}

