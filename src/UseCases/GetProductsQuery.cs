using Demo.DTOs;
using Demo.Infrastructure;
using MediatR;

namespace Demo.UseCases;

public sealed record GetProductsQuery : IRequest<IEnumerable<ProductResponse>>
{
    public static GetProductsQuery Instance => new();

    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _repository
                .List()
                .Select(s => (ProductResponse)s);

            return Task.FromResult(products);
        }
    }
}
