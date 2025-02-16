using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
