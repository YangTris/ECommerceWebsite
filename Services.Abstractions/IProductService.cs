using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDTO>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<ProductDTO> GetByIdAsync(string productId, CancellationToken cancellationToken = default);
		Task<ProductDTO> CreateAsync(ProductDTO product, CancellationToken cancellationToken = default);
		Task UpdateAsync(string productId, ProductDTO product, CancellationToken cancellationToken = default);
		Task DeleteAsync(string productId, CancellationToken cancellationToken = default);
	}
}
