using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IProductService> _lazyProductService;
		private readonly Lazy<ICartService> _lazyCartService;

		public ServiceManager(IRepositoryManager repositoryManager)
		{
			_lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
			_lazyCartService = new Lazy<ICartService>(() => new CartService(repositoryManager));
		}
		public IProductService ProductService => _lazyProductService.Value;
		public ICartService CartService => _lazyCartService.Value;

	}
}
