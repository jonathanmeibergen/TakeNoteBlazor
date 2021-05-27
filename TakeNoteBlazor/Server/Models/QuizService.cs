using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Models
{
	public class QuizService
	{
		List<Quiz> Quizzes { get; set; }
		public QuizService()
		{
			Quizzes = new List<Quiz>();
		}
	}
}
