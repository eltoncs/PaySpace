using System;

namespace PaySpace.Domain.Model
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
