using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaySpace.Domain.Model
{
    public class Calc : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey(nameof(CalcMethod))]
        public string PostalCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxValue { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Income { get; set; }
    }
}
