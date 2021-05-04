using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Client.ViewModels
{
	public class FormViewModel
	{
		public bool IsNew { get; set; }
		public string Author { get; set; }

		[Required]
		public string Title { get; set; }
		public Note Note { get; set; }
		public Question Question { get; set; }
		public Card Card { get; set; }
	}
}
