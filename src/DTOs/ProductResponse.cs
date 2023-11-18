using Demo.Entities;

namespace Demo.DTOs;

public sealed record ProductResponse(Guid Id, string Name, uint Quantity, double Price)
{
    public static implicit operator ProductResponse(Product product)
        => new(
            product.Id,
            product.Name,
            product.Quantity,
            product.Price);
}
