using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Infrastructure.Persistence.Repositories;

public class BrandRepository(CatalogDbContext dbContext) : GenericRepository<Brand>(dbContext), IBrandRepository;