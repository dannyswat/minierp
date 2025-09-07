namespace MiniERP.Core.Repositories;

using System.Threading.Tasks;
using MiniERP.Core.Entities;

public interface IRepository<T> where T : IEntity
{
    Task<T?> GetById(int id, IUnitOfWork? unitOfWork = null);

    Task Add(T entity, IUnitOfWork? unitOfWork = null);
    Task Update(T entity, IUnitOfWork? unitOfWork = null);
    Task Delete(T entity, IUnitOfWork? unitOfWork = null);
}