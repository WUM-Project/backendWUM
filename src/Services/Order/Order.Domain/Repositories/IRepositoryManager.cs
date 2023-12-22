using System;


namespace Order.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IOrderItemRepository OrderItemRepository { get; }
    
        IUnitOfWork UnitOfWork { get; }
    }
}