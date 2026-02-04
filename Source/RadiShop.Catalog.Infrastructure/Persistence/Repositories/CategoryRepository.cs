using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Infrastructure.Persistence.Repositories;

public class CategoryRepository(CatalogDbContext dbContext) : GenericRepository<Category>(dbContext) ,ICategoryRepository;