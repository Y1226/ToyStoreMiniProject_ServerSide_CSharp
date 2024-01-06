using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Repository
{
    public class CartDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int AmountToBuy { get; set; }

        public double ProductPrice { get; set; }

        public double FinalPrice { get; set; }
    }
}
