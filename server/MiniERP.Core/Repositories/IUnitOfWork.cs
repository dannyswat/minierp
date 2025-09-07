using System;
using System.Threading.Tasks;

namespace MiniERP.Core.Repositories;

public interface IUnitOfWork
{
    Task UseTransaction(TransactionAction action);

    Task<int> SaveChanges();
 
    void DispatchEventAfterCommit(string eventName, object data);
}

public delegate Task TransactionAction(IUnitOfWork uow);