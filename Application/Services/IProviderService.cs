using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProviderService
    {
        public string GetProviderName(string number);
        public bool AddBalance(string number, decimal balance);
        public bool RemoveBalance(string number, decimal balance);
    }
},