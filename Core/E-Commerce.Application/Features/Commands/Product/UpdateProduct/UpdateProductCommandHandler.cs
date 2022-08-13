using E_Commerce.Application.Repositories;
using MediatR;
using P = E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Commands.Product.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;

            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
