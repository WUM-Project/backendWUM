using System;
using System.Threading;
using Order.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Order.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<Orders>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Orders> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Orders> GetByIdIncludeExamQustionsAsync(int id, CancellationToken cancellationToken = default);
        //Task<IEnumerable<Orders>> GetAllByStatusAsync(ExamStatus status, CancellationToken cancellationToken = default);
        Task<IEnumerable<Orders>> FindAll(Expression<Func<Orders, bool>> predicate, CancellationToken cancellationToken = default);


        void InsertAddress(Address item);
        void Insert(Orders item);
        void Remove(Orders item);
        bool IsExamItemExists(int id);
    }
}
