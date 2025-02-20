namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Resultado da busca de uma venda
    /// </summary>
    public class GetSaleResult
    {
        public Guid Id { get; set; }
        public string? SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItemResult> Items { get; set; } = new List<SaleItemResult>();
    }
    /// <summary>
    /// Detalhes de um item da venda
    /// </summary>
    public class SaleItemResult
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}