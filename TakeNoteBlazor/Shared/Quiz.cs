using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Shared
{
	public class Quiz
	{
		public int Id { get; set; }
		public QuizParticipant QuizMaster { get; set; }
		public List<QuizParticipant> QuizParticipants { get; set; }
		public List<Question> Questions { get; set; }

		//public Quiz(QuizParticipant quizMaster)
		//{
		//	QuizMaster = quizMaster;
		//	_quizParticipants = new List<QuizParticipant>();
		//	_questions = new List<Question>();
		//}

		//public bool AddParticipant(QuizParticipant quizParticipant)
		//{
		//	if (_quizParticipants.Contains(quizParticipant) is false && 
		//		QuizMaster.Equals(quizParticipant) is false)
		//	{
		//		_quizParticipants.Add(quizParticipant);
		//		return true;
		//	}
		//	return false;
		//}

		//public bool RemoveParticipant(QuizParticipant quizParticipant)
		//{
		//	return _quizParticipants.Remove(quizParticipant);
		//}

		//public bool AddQuestion(Question question)
		//{
		//	if (_questions.Contains(question) is false)
		//	{
		//		_questions.Add(question);
		//		return true;
		//	}
		//	return false;
		//}

		//public bool RemoveQuestion(Question question)
		//{
		//	return _questions.Remove(question);
		//}
	}
}
