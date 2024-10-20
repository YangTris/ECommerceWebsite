using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<Product> GetByIdAsync(string productId, CancellationToken cancellationToken = default);
		void Insert(Product product);
		void Remove(Product product);
	}
}
