using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Server.Models
{
	public class QuizMaster
	{
		public QuizMaster()
		{
			QuestionIds = new List<int>();
		}
		public List<int> QuestionIds { get; set; }
		public string Author { get; set; }

		public bool IsMaster(int id, string author)
		{
			if (QuestionIds.Exists(qm => qm.Equals(id)) && Author.Equals(author))
				return true;

			return false;
		}
	}
}
