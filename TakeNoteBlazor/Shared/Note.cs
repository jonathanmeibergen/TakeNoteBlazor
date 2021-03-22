using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakeNoteBlazor.Shared
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Name is too long.")]
        public string  Author { get; set; }
    }
}
