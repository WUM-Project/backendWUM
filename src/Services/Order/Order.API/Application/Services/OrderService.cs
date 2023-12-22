using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Order.Domain.Entities;
using Order.Domain.Repositories;
using Order.Api.Application.Exceptions;
using Order.Api.Application.Services.Interfaces;
using Order.Api.Application.Contracts.OrderItemDtos;
using Order.Api.Application.Contracts.AddressItemDtos;

using AutoMapper;
using Order.Api.Grpc;
using System.Linq;
using Order.Api.Grpc.Interfaces;
using Newtonsoft.Json;

namespace Order.Api.Application.Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
  
        private readonly IApplicantGrpcService _applicantGprcService;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper, IApplicantGrpcService applicantGprcService)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
      
            _applicantGprcService = applicantGprcService;
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var exams = await _repositoryManager.OrderItemRepository.GetAllAsync(cancellationToken);
            var examsDtos = exams.Select(p=> new OrderReadDto{
                Id =p.Id,
             UserId= p.UserId,
             AddressId = p.AddressId,
             Status = p.Status,
             TotalPrice = p.TotalPrice,
             DeliveryType = p.DeliveryType,
             PayType = p.PayType,
             CreatedAt = p.CreatedAt,
             UpdatedAt = p.UpdatedAt,
                //  Address = p.Address,
                  Addresses = new Address
        {
            Id = p.Address.Id,
            FirstName = p.Address.FirstName,
            LastName = p.Address.LastName,
            FatherName = p.Address.FatherName,
            Email = p.Address.Email,
            Phone = p.Address.Phone,
            Street = p.Address.Street,
            Apartment = p.Address.Apartment,
            House = p.Address.House,
            District = p.Address.District,
            City = p.Address.City,
            Department = p.Address.Department,
            SelfPickupPoint = p.Address.SelfPickupPoint,
            // Add other properties as needed
        },
             ProductsJson = JsonConvert.DeserializeObject<List<Products>>(p.Products).ToList()
            //  ProductsJson = JsonConvert.DeserializeObject<List<Products>>(p.Products).ToList()
            
             });
        
            var examsDto = _mapper.Map<IEnumerable<OrderReadDto>>(examsDtos);

            return examsDto;
        }


        //public async Task<IEnumerable<OrderReadDto>> GetAllByStatusAsync(ExamStatus status, CancellationToken cancellationToken = default)
        //{
        //    if (!Enum.IsDefined(typeof(ExamStatus), status))
        //    {
        //        throw new ArgumentNullException(nameof(status));
        //    }

        //    var exams = await _repositoryManager.OrderItemRepository.GetAllByStatusAsync(status, cancellationToken);

        //    if (!exams.Any())
        //    {
        //        throw new ExamNotFoundException(status.ToString());
        //    }

        //    var examsDto = _mapper.Map<IEnumerable<OrderReadDto>>(exams);

        //    return examsDto;
        //}

        public async Task<OrderReadDto> GetByIdAsync(int examId, CancellationToken cancellationToken = default)
        {
            var exam = await _repositoryManager.OrderItemRepository.GetByIdAsync(examId, cancellationToken);

               var examsDtos = new OrderReadDto{
                Id =exam.Id,
             UserId= exam.UserId,
             AddressId = exam.AddressId,
             Status = exam.Status,
             TotalPrice = exam.TotalPrice,
             DeliveryType = exam.DeliveryType,
             PayType = exam.PayType,
             CreatedAt = exam.CreatedAt,
             UpdatedAt = exam.UpdatedAt,
               Addresses = new Address
        {
            Id = exam.Address.Id,
            FirstName = exam.Address.FirstName,
            LastName = exam.Address.LastName,
            FatherName = exam.Address.FatherName,
            Email = exam.Address.Email,
            Phone = exam.Address.Phone,
            Street = exam.Address.Street,
            Apartment = exam.Address.Apartment,
            House = exam.Address.House,
            District = exam.Address.District,
            City = exam.Address.City,
            Department = exam.Address.Department,
            SelfPickupPoint = exam.Address.SelfPickupPoint,
            // Add other properties as needed
        },
             ProductsJson = JsonConvert.DeserializeObject<List<Products>>(exam.Products).ToList()
            
             };

            if (exam is null)
            {
                throw new ExamNotFoundException(examId);
            }

            var examDto = _mapper.Map<OrderReadDto>(examsDtos);

            return examDto;
        }

        public async Task<OrderReadDto> GetByIdIncludeExamQuestionsAsync(int examId, CancellationToken cancellationToken = default)
        {
            var exam = await _repositoryManager.OrderItemRepository.GetByIdIncludeExamQustionsAsync(examId, cancellationToken);

            if (exam is null)
            {
                // TODO check gRPC test if exam is exception !!!!!
                throw new ExamNotFoundException(examId);
            }

            var examDto = _mapper.Map<OrderReadDto>(exam);

            return examDto;
        }

        public async Task<OrderReadDto> CreateAsync(OrderUpdateCreateDto orderCreateDto, CancellationToken cancellationToken = default)
        {
            
            var exam = _mapper.Map<Orders>(orderCreateDto);

            // When creating exam, exam status equal not available
            //exam.Status = ExamStatus.NotAvailable;

            // Console.WriteLine("---> "+ exam.Description);

            _repositoryManager.OrderItemRepository.Insert(exam);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderReadDto>(exam);
        }
        public async Task<AddressReadDto> CreateAddressAsync(AddressCreateDto addressCreateDto, CancellationToken cancellationToken = default)
        {

            var exam = _mapper.Map<Address>(addressCreateDto);

            // When creating exam, exam status equal not available
            //exam.Status = ExamStatus.NotAvailable;

            // Console.WriteLine("---> "+ exam.Description);

            _repositoryManager.OrderItemRepository.InsertAddress(exam);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AddressReadDto>(exam);
        }

        public async Task UpdateAsync(int examId, ExamItemUpdateDto examUpdateDto, CancellationToken cancellationToken = default)
        {
            var exam = await _repositoryManager.OrderItemRepository.GetByIdAsync(examId, cancellationToken);

            if (exam is null)
            {
                throw new ExamNotFoundException(examId);
            }




            // if (CheckExam(examId))
            // {
            //     throw new BadRequestMessage($"Could not update exam! This exam with id: {examId} already used in Report!");
            // }


            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int examId, CancellationToken cancellationToken = default)
        {
            var exam = await _repositoryManager.OrderItemRepository.GetByIdAsync(examId, cancellationToken);

            if (exam is null)
            {
                throw new ExamNotFoundException(examId);
            }

            // if (CheckExam(examId))
            // {
            //     throw new BadRequestMessage($"Could not delete exam! This exam with id: {examId} already used in Report!");
            // }

            var existsExamInUsers = _applicantGprcService.CheckIfExamExistsInUsers(examId);

            if (existsExamInUsers.Exists)
            {
                throw new BadRequestMessage($"Could not delete exam! This exam with id: {examId} already used in Users");
            }


            _repositoryManager.OrderItemRepository.Remove(exam);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllUserOrderById(string UserId, CancellationToken cancellationToken = default)
        {
            var exams = await _repositoryManager.OrderItemRepository.FindAll(x => x.UserId ==UserId);
  var examsDtos = exams.Select(p=> new OrderReadDto{
                Id =p.Id,
             UserId= p.UserId,
             AddressId = p.AddressId,
             Status = p.Status,
             TotalPrice = p.TotalPrice,
             DeliveryType = p.DeliveryType,
             PayType = p.PayType,
             CreatedAt = p.CreatedAt,
             UpdatedAt = p.UpdatedAt,
                //  Address = p.Address,
                  Addresses = new Address
        {
            Id = p.Address.Id,
            FirstName = p.Address.FirstName,
            LastName = p.Address.LastName,
            FatherName = p.Address.FatherName,
            Email = p.Address.Email,
            Phone = p.Address.Phone,
            Street = p.Address.Street,
            Apartment = p.Address.Apartment,
            House = p.Address.House,
            District = p.Address.District,
            City = p.Address.City,
            Department = p.Address.Department,
            SelfPickupPoint = p.Address.SelfPickupPoint,
            // Add other properties as needed
        },
             ProductsJson = JsonConvert.DeserializeObject<List<Products>>(p.Products).ToList()
            
             });
        
            var examsDto = _mapper.Map<IEnumerable<OrderReadDto>>(examsDtos);


            return examsDto;
            // return _mapper.Map<IEnumerable<OrderReadDto>>(exams);
        }

    }
}