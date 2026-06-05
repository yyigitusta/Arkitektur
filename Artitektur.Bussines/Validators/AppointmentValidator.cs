using Arkitektur.Entity.Entities;
using Artitektur.Business.DTOs.AppointmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz.").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş bırakılamaz.").Matches(@"^\d{10}$").WithMessage("Geçerli bir telefon numarası giriniz (10 haneli).");
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Hizmet adı alanı boş bırakılamaz.");
            RuleFor(x => x.AppointmentDate).GreaterThan(DateTime.Now).WithMessage("Randevu tarihi bugünden sonraki bir tarih olmalıdır.");
        }
    }
}
