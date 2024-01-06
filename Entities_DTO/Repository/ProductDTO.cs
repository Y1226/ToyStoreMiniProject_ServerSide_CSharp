using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Repository
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductPicture { get; set; }

        public double ProductPrice { get; set; }

        public int AmountInStock { get; set; }

        public int CategoryId { get; set; }
    }
}
