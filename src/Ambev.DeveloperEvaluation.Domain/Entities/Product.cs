using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}