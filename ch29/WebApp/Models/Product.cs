using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp.Models
{
	public class Product
	{
		public long ProductId { get; set; }

		[Required(ErrorMessage = "Please enter a value")]
		public string Name { get; set; }

		[Range(1,999999, ErrorMessage = "Please enter a positive price")]
		[Column(TypeName = "decimal(8, 2)")]
		public decimal Price { get; set; }
		public long CategoryId { get; set; }
		public Category? Category { get; set; }
		public long SupplierId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public Supplier? Supplier { get; set; }
	}
}
