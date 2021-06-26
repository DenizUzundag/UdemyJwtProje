using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.UdemyJwtProje.Entities.Dtos.AppUserDtos;

namespace YSK.UdemyJwtProje.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator:AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("İsim alanı boş geçilemez");

        }
    }
}
