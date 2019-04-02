using System.ComponentModel.DataAnnotations;

namespace SieuNhanGao.Infrastructure.DomainEntity
{
    public abstract class DomainEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}