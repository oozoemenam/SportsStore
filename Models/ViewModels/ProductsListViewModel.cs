namespace SportsStore.Models.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<Product> Products { get; set; } = new List<Product>();

		public PagingInfo PagingInfo { get; set; } = new();

		public string? CurrentCategory { get; set; }
	}
}
