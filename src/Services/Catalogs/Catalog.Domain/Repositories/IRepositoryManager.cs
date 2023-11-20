using System;


namespace Catalog.Domain.Repositories
{
    public interface IRepositoryManager
    {
        
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IUploadRepository UploadRepository { get; }
         IUnitOfWork UnitOfWork { get; }
    }

}
