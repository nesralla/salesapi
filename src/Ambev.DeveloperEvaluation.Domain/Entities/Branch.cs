using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public Branch()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Location = string.Empty;
        }
        public string Name { get; set; }
        public string Location { get; set; }
    }

}