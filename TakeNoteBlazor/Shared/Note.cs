using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakeNoteBlazor.Shared
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string AuthorId { get; set; }
		public string Author { get; set; }

	}
}
