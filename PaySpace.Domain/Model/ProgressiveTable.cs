using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaySpace.Domain.Model
{
    public class ProgressiveTable : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal From { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal To { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Rate { get; set; }
    }
}
