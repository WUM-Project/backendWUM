using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Applicant.API.Application.Contracts.Dtos.UserDtos;
using System.Linq.Expressions;
using Applicant.API.Application.Configurations;
using Applicant.API.Application.Contracts.Dtos.OrderDtos;

namespace Applicant.API.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserReadDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<Google.Protobuf.Collections.RepeatedField<GrpcOrder.OrderDataResponse>> GetByOrdersIdAsync(string id, CancellationToken cancellationToken = default);
        Task<UserReadDto> CreateAsync(UserCreateDto userCreateDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(string id, UserUpdateDto userUpdateDto, CancellationToken cancellationToken = default);
        Task UpdateEmailAsync(UserChangeEmailDto userChangeEmailDto, CancellationToken cancellationToken = default);
        Task<bool> AccessCodeAsync(UserEmailDto userEmailDto, CancellationToken cancellationToken = default);
        Task ChangePassword(UserChangePasswordDto userChangePasswordDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
        Task AddRoleAsync(UserRoleDto userRoleDto, CancellationToken cancellationToken = default);
        Task RemoveRoleAsync(UserRoleDto userRoleDto, CancellationToken cancellationToken = default);
      
    }
}
