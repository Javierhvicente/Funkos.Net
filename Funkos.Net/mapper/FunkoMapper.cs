using Funkos.Net.Database;
using Funkos.Net.models;

namespace Funkos.Net.mapper;

public static class FunkoMapper
{
    public static Funko toFunko(this FunkoEntity entity)
    {
        return new Funko
        {
            Id = entity.Id,
            Name = entity.Name,
            Categoria = entity.Categoria,
            precio = entity.Precio,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }

    public static FunkoEntity toFunkoEntity(this Funko funko)
    {
        return new FunkoEntity
        {
            Id = funko.Id,
            Name = funko.Name,
            Categoria = funko.Categoria,
            Precio = funko.precio,
            IsDeleted = funko.IsDeleted,
            CreatedAt = funko.CreatedAt,
            UpdatedAt = funko.UpdatedAt
        };
    }

    public static FunkoRequest toFunkoRequest(this Funko funko)
    {
        return new FunkoRequest
        {
            Name = funko.Name,
            Categoria = funko.Categoria,
            Precio = funko.precio
        };
    }
    
}