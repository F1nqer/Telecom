﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProviderService
    {
        public string AddBalance(string number, decimal balance);
    }
}