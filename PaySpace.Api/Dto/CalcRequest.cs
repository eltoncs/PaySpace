using System.ComponentModel.DataAnnotations;

namespace PaySpace.Api.Dto
{
    public class CalcRequest
    {
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public decimal Income { get; set; }
    }
}
