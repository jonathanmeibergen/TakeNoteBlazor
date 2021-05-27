using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Server.Models
{
	public class QuizService
	{
		public QuizService()
		{
			QuizMasters = new List<QuizMaster>();
		}
		List<QuizMaster> QuizMasters { get; set; }
	}
}
