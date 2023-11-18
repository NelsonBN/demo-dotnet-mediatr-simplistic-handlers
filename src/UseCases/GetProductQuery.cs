using Demo.DTOs;
using Demo.Infrastructure;
using MediatR;

namespace Demo.UseCases;

public sealed record GetProductQuery(Guid Id) : IRequest<ProductResponse?>
{
    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<GetProductQuery, ProductResponse?>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<ProductResponse?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _repository.Get(request.Id);

            if(product is null)
            {
                return Task.FromResult<ProductResponse?>(null);
            }

            return Task.FromResult((ProductResponse?)product);
        }
    }
}
