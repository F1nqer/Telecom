using System;

namespace Application.ViewModels
{
    public class Payment
    {
        private string num;
        public string Number
        {
            get
            {
                return num ;
            }
            set
            {
                num = value
                    .Replace(" ", "")
                    .Replace("-", "");
                num = num.Length == 12 ? value : throw new Exception("Некорректный номер");
            }
        }
        public decimal Sum { get; set; }
    }
}
