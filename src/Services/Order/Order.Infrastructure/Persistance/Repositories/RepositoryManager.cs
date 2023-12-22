using System;
using Order.Domain.Repositories;


namespace Order.Infrastructure.Persistance.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IOrderItemRepository> _lazyOrderItemRepository;      
 
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(OrderDbContext dbContext)
        {
            _lazyOrderItemRepository = new Lazy<IOrderItemRepository>(() => new OrderItemRepository(dbContext));
         
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IOrderItemRepository OrderItemRepository => _lazyOrderItemRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
