﻿using System;
using Applicant.Domain.Repositories;
using Applicant.Infrastructure;

namespace Applicant.Infrasructure.Persistance.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {    private readonly AppDbContext _dbContext;
        private readonly Lazy<IRefreshTokenRepository> _lazyRefreshTokenRepository;
        private readonly Lazy<IAccessCodeRepository> _lazyAccessCodeRepository;
        // private readonly Lazy<IUserExamsRepository> _lazyUserExamsRepository;
        private readonly Lazy<IRoleRepository> _lazyRoleRepository;
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(AppDbContext dbContext)
        {     
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _lazyRefreshTokenRepository = new Lazy<IRefreshTokenRepository>(() => new RefreshTokenRepository(dbContext));
            _lazyAccessCodeRepository = new Lazy<IAccessCodeRepository>(() => new AccessCodeRepository(dbContext));
            // _lazyUserExamsRepository = new Lazy<IUserExamsRepository>(() => new UserExamsRepository(dbContext));
            _lazyRoleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(dbContext));
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IRefreshTokenRepository RefreshTokenRepository => _lazyRefreshTokenRepository.Value;
        public IAccessCodeRepository AccessCodeRepository => _lazyAccessCodeRepository.Value;
        // public IUserExamsRepository UserExamsRepository => _lazyUserExamsRepository.Value;
        public IRoleRepository RoleRepository => _lazyRoleRepository.Value;
        public IUserRepository UserRepository => _lazyUserRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }

}
