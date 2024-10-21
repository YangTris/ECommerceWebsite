using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using Shared;

namespace Services
{
	internal sealed class ProductService : IProductService
	{
		public readonly IRepositoryManager _repositoryManager;
		public ProductService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}
		public async Task<IEnumerable<ProductDTO>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			var products = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
			return products.Adapt<IEnumerable<ProductDTO>>();
		}
		public async Task<ProductDTO> GetByIdAsync(string productId, CancellationToken cancellationToken = default)
		{
			var productEntity = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
			if (productEntity == null)
			{
				throw new ProductNotFoundException($"Product with id {productId} not found");
			}
			return productEntity.Adapt<ProductDTO>();
		}
		public async Task<ProductDTO> CreateAsync(ProductDTO product, CancellationToken cancellationToken = default)
		{
			var productEntity = product.Adapt<Product>();
			_repositoryManager.ProductRepository.Insert(productEntity);
			await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
			return productEntity.Adapt<ProductDTO>();
		}
		public async Task UpdateAsync(string productId, ProductDTO product, CancellationToken cancellationToken = default)
		{
			var productEntity = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
			if (productEntity == null)
			{
				throw new ProductNotFoundException($"Product with id {productId} not found");
			}
			productEntity.name = product.name;
			productEntity.price = product.price;
			productEntity.description = product.description;
			productEntity.timestamp = product.timestamp;
			productEntity.category = product.category;
			productEntity.imageUrl = product.imageUrl;

			await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		}
		public async Task DeleteAsync(string productId, CancellationToken cancellationToken = default)
		{
			var productEntity = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
			if (productEntity == null)
			{
				throw new ProductNotFoundException($"Product with id {productId} not found");
			}
			_repositoryManager.ProductRepository.Remove(productEntity);
			await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		}
	}
}
