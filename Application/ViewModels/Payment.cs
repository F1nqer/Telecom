using Application.Localization;
using Microsoft.Extensions.Localization;
using System;

namespace Application.ViewModels
{
    public class Payment
    {
        public string Number { get; set; }
        public decimal Sum { get; set; }
        //это можно написать при помощи встроенных валидаторов, но так быстрее
        public string GetNumber(IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            Number = Number
                    .Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            Number = Number.Length == 12 ? Number : throw new Exception(sharedResourceLocalizer["IncorrectNumber"].Value);
            return Number;
        }
    }
}
