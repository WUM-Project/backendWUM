using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Order.Domain.Entities;
using Order.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Order.Infrastructure.Persistance.Repositories
{
    internal sealed class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderItemRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Orders>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders.Include(e => e.Address)
                .ToListAsync(cancellationToken);
        }

        public async Task<Orders> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders.Include(e => e.Address)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Orders> GetByIdIncludeExamQustionsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders
                .Include(e => e.Address)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Insert(Orders item)
        {
            
            _dbContext.Orders.Add(item);
        }
        public void InsertAddress(Address item)
        {
            
            _dbContext.Address.Add(item);
        }

        public void Remove(Orders item)
        {
            _dbContext.Orders.Remove(item);
        }

        public bool IsExamItemExists(int id)
        {
            return _dbContext.Orders.Any(i => i.Id == id);
        }

        public async Task<IEnumerable<Orders>> FindAll(Expression<Func<Orders, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders.Include(e => e.Address).Where(predicate).ToListAsync();
        }
    }
}
