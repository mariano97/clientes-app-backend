using System;
using ClientesApi.Data.DbConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Domain.Repositories.Impl
{
	public class RepositoryAsyncImpl<T> : IRepositoryAsync<T> where T : class
	{

        protected DataBaseContext _dataBaseContext;
        protected bool disposed = false;

		public RepositoryAsyncImpl(DataBaseContext dataBaseContext)
		{
            _dataBaseContext = dataBaseContext;
		}

        protected DbSet<T> EntitySet
        {
            get {
                return _dataBaseContext.Set<T>();
            }
        }

        public async Task<IEnumerable<T>> ConsultarAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> ConsultarById(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        protected void Dispose(bool isDispose)
        {
            if (!disposed && isDispose)
            {
                _dataBaseContext.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Guardar(T entity)
        {
            await EntitySet.AddAsync(entity);
            await Save();
            return entity; 
        }

        protected async Task<int> Save()
        {
            return await _dataBaseContext.SaveChangesAsync();
        }
    }
}

