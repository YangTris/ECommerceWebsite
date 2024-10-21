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
		public ServiceManager(IRepositoryManager repositoryManager)
		{
			_lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
		}
		public IProductService ProductService => _lazyProductService.Value;
	}
}
