using Catalog.API.Models.DTOs.Products.CreateProduct;
using MediatR;

namespace Catalog.API.Features.Products.CreateProduct;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
