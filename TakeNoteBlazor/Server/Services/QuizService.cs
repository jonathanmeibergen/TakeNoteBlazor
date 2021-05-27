using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Services
{
	public class QuizService
	{
		public ICollection<Quiz> Quizes { get; set; }

		public QuizService()
		{
			Quizes = new List<Quiz>();
		}

		//public bool AddQuiz(QuizParticipant quizMaster)
		//{
		//	var result = QuizMasters.Contains()
		//}

	}
}
