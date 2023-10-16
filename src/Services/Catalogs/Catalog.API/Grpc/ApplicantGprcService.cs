using System;
using System.Threading.Tasks;

using Grpc.Core;
using GrpcCatalog;
using AutoMapper;

using Microsoft.Extensions.Logging;
using Catalog.API.Application.Services.Interfaces;

using System.Linq;

namespace Catalog.API.Grpc
{
    public class CatalogGrpcService : CatalogGrpc.CatalogGrpcBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILogger<CatalogGrpcService> _logger;
        private readonly IMapper _mapper;

        public CatalogGrpcService(IServiceManager serviceManager, ILogger<CatalogGrpcService> logger, IMapper mapper)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

 
    }
}