using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApp.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Completion;

namespace WebApp.Models
{
	[PhraseAndPrice(Phrase = "Small", Price = "100")]
	public class Product
	{
		public long ProductId { get; set; }

		[Required(ErrorMessage = "Please enter a value")]
		public string Name { get; set; }

		[Range(1,999999, ErrorMessage = "Please enter a positive price")]
		[Column(TypeName = "decimal(8, 2)")]
		public decimal Price { get; set; }

        [PrimaryKey(ContextTypes = typeof(DataContext), DataType = typeof(Category))]
		[Remote("CategoryKey", "Validation", ErrorMessage = "Enter an existing key")]
        public long CategoryId { get; set; }
		public Category? Category { get; set; }

        [PrimaryKey(ContextTypes = typeof(DataContext), DataType = typeof(Supplier))]
        [Remote("SupplierKey", "Validation", ErrorMessage = "Enter an existing key")]
        public long SupplierId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public Supplier? Supplier { get; set; }
	}
}
