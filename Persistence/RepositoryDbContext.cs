using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class RepositoryDbContext : DbContext
	{
		public RepositoryDbContext(DbContextOptions options)
		: base(options)
		{
		}

		public DbSet<Product> Products { get; init; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>().ToCollection("Products");
		}
	}
}
