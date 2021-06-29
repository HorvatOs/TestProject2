using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Common.Paiging;

namespace Vehicle.Common.Paging
{
    public class PagingParameters : IPagingParameters
    {

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Sort { get; set; }
    }
}
