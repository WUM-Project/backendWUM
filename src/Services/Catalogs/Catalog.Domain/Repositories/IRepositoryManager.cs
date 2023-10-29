﻿using System;


namespace Catalog.Domain.Repositories
{
    public interface IRepositoryManager
    {
        
        ICategoryRepository CategoryRepository { get; }
        IUploadRepository UploadRepository { get; }
         IUnitOfWork UnitOfWork { get; }
    }

}
