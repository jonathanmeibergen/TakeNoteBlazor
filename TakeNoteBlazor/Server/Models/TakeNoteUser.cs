using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Models
{
	public partial class TakeNoteUser : IdentityUser
	{
		public List<Note> Notes { get; set; }
	}
}
