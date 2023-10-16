using System;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.API.Application.Exceptions;
using Catalog.API.Application.Configurations;
using Catalog.API.Application.Services.Interfaces;
using Catalog.API.Application.Contracts.Dtos.CategoryDtos;

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Catalog.API.Grpc;
using System.Linq.Expressions;
using Grpc.Net.Client;
//using GrpcExam;
using Microsoft.Extensions.Configuration;
// using Catalog.API.Grpc.Interfaces;
using Catalog.API.Application.Contracts.Infrastructure;
using Catalog.API.Application.Models;

namespace Catalog.API.Application.Services
{
    internal sealed class CategoryService : ICategoryService
    {


        private readonly IMapper _mapper;
  
        private readonly IRepositoryManager _repositoryManager;

 public CategoryService(IRepositoryManager repositoryManager, IMapper mapper
      )
        {
            _mapper = mapper;
         ;
            _repositoryManager = repositoryManager;
            // _reportGrpcService = reportGrpcService;
            // _examGrpcService = examGrpcService;
        }
        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
       
            var categoryDto = _mapper.Map<IEnumerable<CategoryReadDto>>(categories);

           

            return categoryDto;
        }
        public async Task<IEnumerable<CategoryReadDto>> GetAllChild(int ParentId,CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.CategoryRepository.FindAllAsync(x=>x.ParentId == ParentId );
       
            var categoryDto = _mapper.Map<IEnumerable<CategoryReadDto>>(categories);

           

            return categoryDto;
        }
//         private IEnumerable<Category> BuildCategoryTree(int? parentId, IEnumerable<Category> categories)
// {
//     var childCategories = categories.Where(c => c.ParentId == parentId).ToList();

//     foreach (var category in childCategories)
//     {
//         category.Children = BuildCategoryTree(category.Id, categories);
//     }

//     return childCategories;
// }

    //    static IList<Category> BuildTree(this IEnumerable<Category> source)
    // {
    //     var groups = source.GroupBy(i => i.ParentId);

    //     var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();

    //     if (roots.Count > 0)
    //     {
    //         var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
    //         for (int i = 0; i < roots.Count; i++)
    //             AddChildren(roots[i], dict);
    //     }

    //     return roots;
    // }

    //  static void AddChildren(Category node, IDictionary<int, List<Category>> source)
    // {
    //     if (source.ContainsKey(node.Id))
    //     {
    //         node.Children = source[node.Id];
    //         for (int i = 0; i < node.Children.Count; i++)
    //             AddChildren(node.Children[i], source);
    //     }
    //     else
    //     {
    //         node.Children = new List<Category>();
    //     }
    // }
    
    }

}
