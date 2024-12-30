using Funkos.Net.models;

namespace Funkos.Net.Services;

public interface IFunkoService
{
    public Task<List<Funko>> GetAllFunkosAsync();
    public Task<Funko?> GetFunkoByIdAsync(long id);
    public Task<Funko> CreateFunkoAsync(Funko funko);
    public Task<Funko?> UpdateFunkoAsync(Funko funko);
    public Task<Funko?> DeleteFunkoAsync(long id);
}