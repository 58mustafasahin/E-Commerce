using E_Commerce.Application.ViewModels.Products;
using FluentValidation;

namespace E_Commerce.Application.Validators.Products
{
    public class AddProductValidator : AbstractValidator<AddProductVM>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .Length(2, 150).WithMessage("Ürün adı belirtilen karakter dışındadır(2-150).");
            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen stok bilgisini boş geçmeyiniz.")
                .Must(p => p >= 0).WithMessage("Stok bilgisi negatif olamaz.");
            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
                .Must(p => p >= 0).WithMessage("Fiyat bilgisi negatif olamaz.");
        }
    }
}
