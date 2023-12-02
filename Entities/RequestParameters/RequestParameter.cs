using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public abstract class RequestParameter
    {
        public string? SearchTerm { get; set; }
    }
}