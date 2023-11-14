using System;
using System.ComponentModel.DataAnnotations;

namespace Bookshelf
{
	public class Book
	{
		[Required]
		[MinLength(10)]
		[MaxLength(100)]
		[Display(Name = "Book name:")]
		public string BookName { get; set; }

		[Required]
		[Range(1,9999)]
		[Display(Name = "Number of pages:")]
		public int BookNumPages { get; set; }
		
		[Display(Name = "ISBN:")]
		public string ISBN { get; set; }
	}
}
