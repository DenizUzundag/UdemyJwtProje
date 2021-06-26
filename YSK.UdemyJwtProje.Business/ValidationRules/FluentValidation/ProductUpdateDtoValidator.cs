using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.UdemyJwtProje.Entities.Concrete;
using YSKProje.UdemyJwtProje.Entities.Dtos.ProductDtos;

namespace YSK.UdemyJwtProje.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator:AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
        }
    }
}
