using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Repository
{
    public class SaleDetailsDTO
    {
        public int SaleDetailsId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int ProductCount { get; set; }
    }
}
