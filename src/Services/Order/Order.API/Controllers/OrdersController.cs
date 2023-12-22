using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Order.Api.Application.Services.Interfaces;
using Order.Api.Application.Contracts.OrderItemDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Question.API.Application.Paggination;
using Order.Api.Grpc;
using Order.Api.Grpc.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Order.Domain.Entities;
using Order.Api.Application.Contracts.AddressItemDtos;
using Newtonsoft.Json;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrdersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
         
        }


        // GET api/exam/items
        [HttpGet("orders")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher, Manager, Student")]
        public async Task<IActionResult> Orders(int page, string title, int limit, int middleVal = 10, int cntBetween = 5, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("--> Getting exams...");
            var orders = await _serviceManager.OrderService.GetAllAsync(cancellationToken);

            // if (title != null)
            // {
            //     exams = exams.Where(x => x.Title.ToLower().Contains(title.ToLower()));
            // }

            if (middleVal <= cntBetween) return BadRequest(new { Error = "MiddleVal must be more than cntBetween" });
            return Ok(Pagination<OrderReadDto>.GetData(currentPage: page, limit: limit, itemsData: orders, middleVal: middleVal, cntBetween: cntBetween));
        }

        // GET api/exam/items/1
        [HttpGet("orders/{orderId:int}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher, Manager, Student")]
        public async Task<IActionResult> OrderById(int orderId, CancellationToken cancellationToken)
        {
            Console.WriteLine($"--> Getting exam by Id = {orderId}");
            var examDto = await _serviceManager.OrderService.GetByIdAsync(orderId, cancellationToken);

            return Ok(examDto);
        }


        // POST api/exam/items
        [HttpPost]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var addressCreate = new AddressCreateDto
                {
                    Street = orderCreateDto.Street,
                    Apartment = orderCreateDto.Apartment,
                    House = orderCreateDto.House,
                    District = orderCreateDto.District,
                    City = orderCreateDto.City,
                    Department = orderCreateDto.Department,
                    FirstName = orderCreateDto.FirstName,
                    LastName = orderCreateDto.LastName,
                    FatherName = orderCreateDto.FatherName,
                    Email = orderCreateDto.Email,
                    Phone = orderCreateDto.Phone,
                    SelfPickupPoint = orderCreateDto.SelfPickupPoint
                };

                var addressDto = await _serviceManager.OrderService.CreateAddressAsync(addressCreate, cancellationToken);

                

                var OrderCreate = new OrderUpdateCreateDto
                {
                    TotalPrice = orderCreateDto.TotalPrice,
                    UserId = orderCreateDto.UserId,
                    Comment = orderCreateDto.Comment,
                    DeliveryType = orderCreateDto.DeliveryType,
                    PayType = orderCreateDto.PayType,
                    AddressId = addressDto.Id,
                    Status = 2,
                    ProductsJson = orderCreateDto.ProductsJson
                };
                // Створюємо JSON-рядок для продуктів
                var productsJson = JsonConvert.SerializeObject(OrderCreate.ProductsJson);


                OrderCreate.Products = productsJson;
                Console.WriteLine("--> Creating order...");
                var examDto = await _serviceManager.OrderService.CreateAsync(OrderCreate, cancellationToken);

                return CreatedAtAction(nameof(OrderById), new { orderId = examDto.Id }, examDto);
            }

            return BadRequest(GetModelStateErrors(ModelState.Values));
        }
        // POST api/exam/items
        [Route("{examId:int}")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher")]
        public async Task<IActionResult> UpdateExam(int examId, [FromBody] ExamItemUpdateDto examItemUpdateDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("--> Update exam...");
                await _serviceManager.OrderService.UpdateAsync(examId, examItemUpdateDto, cancellationToken);

                return NoContent();
            }

            return BadRequest(GetModelStateErrors(ModelState.Values));
        }

        // GET api/exam/items/1
        [HttpDelete]
        [Route("{examId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher")]
        public async Task<IActionResult> DeleteExam(int examId, CancellationToken cancellationToken)
        {
            Console.WriteLine($"--> Delete Exam...");
            await _serviceManager.OrderService.DeleteAsync(examId, cancellationToken);

            //var res =  await _reportGrpcService.CheckIfExistsExamInReports(examId);


            //Console.WriteLine("---> REsponse: " + res.Exists);

            return NoContent();
        }


        // GET api/[controller]/items/5/questions
        // [Route("{examId:int}/questions")]
        // [HttpGet("{examId:int}/questions", Name = "QuestionsByExamItemId")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // public async Task<IActionResult> QuestionsByExamItemId(int examId, int page, int limit, int middleVal = 10, int cntBetween = 5, CancellationToken cancellationToken = default)
        // {
        //     Console.WriteLine("--> Getting questions...");
        //     var questions = await _serviceManager.ExamQuestionService.GetAllByExamItemIdAsync(examId, cancellationToken);

        //     if (middleVal <= cntBetween) return BadRequest(new { Error = "MiddleVal must be more than cntBetween" });
        //     return Ok(Pagination<ExamQuestionReadDto>.GetData(currentPage: page, limit: limit, itemsData: questions, middleVal: middleVal, cntBetween: cntBetween));
        //     //return Ok(questions);
        // }


        // // GET api/[controller]/items/5/question/1
        // [Route("{examId:int}/questions/{questionId:int}")]
        // [HttpGet]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // public async Task<IActionResult> QuestionById(int examId, int questionId, CancellationToken cancellationToken)
        // {
        //     Console.WriteLine("--> Getting question by Id...");
        //     var question = await _serviceManager.ExamQuestionService.GetByIdAsync(examId, questionId, cancellationToken);

        //     return Ok(question);
        // }


        // // POST api/[controller]/items/5/questions
        // [HttpPost]
        // [Route("{examId:int}/questions")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher")]
        // public async Task<IActionResult> CreateQuestionAsync(int examId, [FromBody] ExamQuestionCreateDto questionCreateDto, CancellationToken cancellationToken)
        // {
        //     Console.WriteLine("--> Creating question...");

        //     var questionDto = await _serviceManager.ExamQuestionService.CreateAsync(examId, questionCreateDto, cancellationToken);

        //     return CreatedAtAction(nameof(QuestionById), new { examId = questionDto.ExamItemId, questionId = questionDto.Id }, questionDto);
        // }


        // GET api/[controller]/items/5/question/1
        // [HttpDelete]
        // [Route("{examId:int}/questions/{questionId:int}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher")]
        // public async Task<IActionResult> DeleteQuestion(int examId, int questionId, CancellationToken cancellationToken)
        // {
        //     Console.WriteLine($"--> Delete question by Id = {questionId}");

        //     await _serviceManager.ExamQuestionService.DeleteAsync(examId, questionId, cancellationToken);

        //     return NoContent();
        // }

        /// <summary>
        /// Gets all modelstate errors
        /// </summary>
        private List<string> GetModelStateErrors(IEnumerable<ModelStateEntry> modelState)
        {
            var modelErrors = new List<string>();
            foreach (var ms in modelState)
            {
                foreach (var modelError in ms.Errors)
                {
                    modelErrors.Add(modelError.ErrorMessage);
                }
            }

            return modelErrors;
        }
    }
}