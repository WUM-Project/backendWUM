using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Order.Api.Application.Contracts.OrderItemDtos;
using Order.Api.Application.Contracts.AddressItemDtos;


namespace Order.Api.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
        //Task<IEnumerable<OrderReadDto>> GetAllByStatusAsync(ExamStatus status, CancellationToken cancellationToken = default);
        Task<IEnumerable<OrderReadDto>> GetAllUserOrderById(string userId, CancellationToken cancellationToken = default);
        Task<OrderReadDto> GetByIdAsync(int examId, CancellationToken cancellationToken = default);
        Task<OrderReadDto> GetByIdIncludeExamQuestionsAsync(int examId, CancellationToken cancellationToken = default);


        Task<OrderReadDto> CreateAsync(OrderUpdateCreateDto examCreateDto, CancellationToken cancellationToken = default);
        Task<AddressReadDto> CreateAddressAsync(AddressCreateDto addressCreateDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(int examId, ExamItemUpdateDto examUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int examId, CancellationToken cancellationToken = default);
    }
}
