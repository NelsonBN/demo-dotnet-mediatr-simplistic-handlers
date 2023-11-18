namespace Demo.DTOs;

public sealed record ProductRequest
{
    public string? Name { get; init; }
    public uint Quantity { get; init; }
    public double Price { get; init; }
}
