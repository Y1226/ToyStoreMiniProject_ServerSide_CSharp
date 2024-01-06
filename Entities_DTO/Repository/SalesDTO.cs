using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Repository
{
    public class SalesDTO
    {
        public int SaleId { get; set; }

        public string? UserId { get; set; }

        public string? SaleDate { get; set; } 

        public double FinalPrice { get; set; }
    }
}
