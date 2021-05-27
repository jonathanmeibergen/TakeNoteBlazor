using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Shared
{
	public class Question
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Answer { get; set; }
		public string AnswerA { get; set; }
		public string AnswerB { get; set; }
		public string AnswerC { get; set; }
		public string AnswerD { get; set; }
		public char AnswerChar { get; set; }
		public List<Quiz> Quizzes { get; set; }

		public string GetAnswer(char answer)
		{
			switch (answer)
			{
				case 'a':
					return AnswerA;
				case 'b':
					return AnswerB;
				case 'c':
					return AnswerC;
				case 'd':
					return AnswerD;
				default:
					return Answer;
			}
		}
	}
}
