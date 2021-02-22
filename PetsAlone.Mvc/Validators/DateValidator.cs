using System;
using System.ComponentModel.DataAnnotations;

namespace PetsAlone.Mvc.Validators
{
    public sealed class DateValidator : ValidationAttribute
    {
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool IsValid(object value)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            if (value == null)
                return false;
            DateTime dateStart = (DateTime)value;
            return (dateStart <= DateTime.Now.Date);
        }
    }
}
