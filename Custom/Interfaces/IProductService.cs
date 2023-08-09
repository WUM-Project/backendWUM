using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Models;

namespace Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductsDTO>> GetAsync();
       


    }
}
