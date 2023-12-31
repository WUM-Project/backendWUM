﻿using System;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure;

namespace Catalog.Infrasructure.Persistance.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {    private readonly AppDbContext _dbContext;
        // private readonly Lazy<IRefreshTokenRepository> _lazyRefreshTokenRepository;
        // private readonly Lazy<IAccessCodeRepository> _lazyAccessCodeRepository;
        // private readonly Lazy<IUserExamsRepository> _lazyUserExamsRepository;
        // private readonly Lazy<IRoleRepository> _lazyRoleRepository;
        // private readonly Lazy<IUserRepository> _lazyUserRepository;
     
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
       private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;
       private readonly Lazy<IProductRepository> _lazyProductRepository;
       private readonly Lazy<IUploadRepository> _lazyUploadedFilesRepository;
        public RepositoryManager(AppDbContext dbContext)
        {     
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            // _lazyRefreshTokenRepository = new Lazy<IRefreshTokenRepository>(() => new RefreshTokenRepository(dbContext));
            // _lazyAccessCodeRepository = new Lazy<IAccessCodeRepository>(() => new AccessCodeRepository(dbContext));
            // _lazyUserExamsRepository = new Lazy<IUserExamsRepository>(() => new UserExamsRepository(dbContext));
            // _lazyRoleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(dbContext));
            // _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
            _lazyUploadedFilesRepository = new Lazy<IUploadRepository>(() => new UploadRepository(dbContext));
        }

        // public IRefreshTokenRepository RefreshTokenRepository => _lazyRefreshTokenRepository.Value;
        // public IAccessCodeRepository AccessCodeRepository => _lazyAccessCodeRepository.Value;
        // // public IUserExamsRepository UserExamsRepository => _lazyUserExamsRepository.Value;
        // public IRoleRepository RoleRepository => _lazyRoleRepository.Value;
        // public IUserRepository UserRepository => _lazyUserRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;
        public IProductRepository ProductRepository => _lazyProductRepository.Value;
        public IUploadRepository UploadRepository => _lazyUploadedFilesRepository.Value;
    }

}
