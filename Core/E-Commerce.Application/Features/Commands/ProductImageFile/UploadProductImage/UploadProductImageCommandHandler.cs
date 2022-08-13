using E_Commerce.Application.Abstractions.Storage;
using E_Commerce.Application.Repositories;
using MediatR;
using P = E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductReadRepository _productReadRepository;

        public UploadProductImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository, IStorageService storageService)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productReadRepository = productReadRepository;
            _storageService = storageService;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            P.Product product = await _productReadRepository.GetByIdAsync(request.Id);

            //foreach (var r in result)
            //{
            //    product.ProductImageFiles.Add(new()
            //    {
            //        FileName = r.fileName,
            //        Path = r.pathOrContainerName,
            //        Storage = _storageService.StorageName,
            //        Products = new List<Product>() { product }
            //    });
            //}

            await _productImageFileWriteRepository.AddRangeAsync(result.Select(p => new P.ProductImageFile()
            {
                FileName = p.fileName,
                Path = p.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<P.Product>() { product }
            }).ToList());
            await _productImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
