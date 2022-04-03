using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class Payment
    {
        public string Number 
        {
            get
            {
                return Number;
            }
            set 
            {
                Number = value
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Length == 12 ? Number : throw new Exception("Некорректный номер");
            } 
        }
        public decimal Sum { get; set; }
    }
}
