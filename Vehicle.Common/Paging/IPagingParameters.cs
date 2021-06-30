using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Common.Paiging
{
    public interface IPagingParameters
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        string Sort { get; set; }
        string Filter { get; set; }

    }
}
