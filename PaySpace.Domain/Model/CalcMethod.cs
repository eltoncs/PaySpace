using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySpace.Domain.Model
{
    public class CalcMethod : IEntity
    {
        public CalcMethod(Guid id, string postalCode, string method)
        {
            this.Id = id;
            this.PostalCode = postalCode;
            this.Method = method;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(4)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(12)]
        public string Method { get; set; }

        public virtual ICollection<Calc> Calculations { get; set; }
    }
}
