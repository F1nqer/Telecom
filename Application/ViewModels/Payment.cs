using System;

namespace Application.ViewModels
{
    public class Payment
    {
        public string Number { get; set; }
        public decimal Sum { get; set; }
        //это можно написать при помощи встроенных валидаторов, но так быстрее
        public string GetNumber()
        {
            Number = Number
                    .Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            Number = Number.Length == 12 ? Number : throw new Exception("Некорректный номер");
            return Number;
        }
    }
}
