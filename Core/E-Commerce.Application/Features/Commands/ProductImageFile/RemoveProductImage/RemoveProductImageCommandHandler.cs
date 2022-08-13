using E_Commerce.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P = E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductReadRepository _productReadRepository;

        public RemoveProductImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            P.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            P.ProductImageFile? productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (productImageFile != null)
                product.ProductImageFiles.Remove(productImageFile);

            await _productImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
