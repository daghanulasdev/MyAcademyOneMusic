using FluentValidation;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Validators
{
    public class SingerValidator : AbstractValidator<Singer>
    {
        public SingerValidator()
        {
            RuleFor(x=>x.SingerName).NotEmpty().WithMessage("Bu alan boş geçilemez.").MaximumLength(50).WithMessage("En fazla 50 karakter giriniz.").MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Bu alan boş geçilemez.");
        }

    }
}
