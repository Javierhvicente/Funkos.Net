using Funkos.Net.Database;
using Funkos.Net.mapper;
using Funkos.Net.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Funkos.Net.Services;

public class FunkoService : IFunkoService
{
    private const String CacheKetPrefix = "Funko_";
    private readonly ILogger _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly FunkoDbContext _context;

    public FunkoService(FunkoDbContext context, ILogger<FunkoService> logger, IMemoryCache memoryCache)
    {
        _context = context;
        _logger = logger;
        _memoryCache = memoryCache;
    }
    
    public async Task<List<Funko>> GetAllFunkosAsync()
    {
        _logger.LogDebug("Obtaining all Funkos");
        return await _context.Funkos.Select(funko => funko.toFunko()).ToListAsync();
    }

    public async Task<Funko?> GetFunkoByIdAsync(long id)
    {
        _logger.LogDebug($"Obtaining Funko with id: {id}");
        var cacheKey = CacheKetPrefix + id;
        if (_memoryCache.TryGetValue(cacheKey, out Funko? funkoCached))
        {
            _logger.LogInformation("Getting the Funko from cache");
            return funkoCached;
        }
        _logger.LogDebug("Getting the book from database");
        var funkoEntity = await _context.Funkos.FindAsync(id);
        if (funkoEntity != null)
        {
            _logger.LogInformation("Funko not found in cache, caching it");
            _memoryCache.Set(cacheKey, funkoEntity.toFunko(),
                TimeSpan.FromMinutes(30)); 
            _logger.LogInformation("Caching the Funko");
        }

        return funkoEntity.toFunko();
    }

    public Task<Funko> CreateFunkoAsync(Funko funko)
    {
        _logger.LogDebug("Creating new Funko");
        funko
    }

    public Task<Funko?> UpdateFunkoAsync(Funko funko)
    {
        throw new NotImplementedException();
    }

    public Task<Funko?> DeleteFunkoAsync(long id)
    {
        throw new NotImplementedException();
    }
}