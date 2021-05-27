using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Shared {
	public class QuizParticipant : IEntity
	{
		public int Id { get; set; }
		public string UserName { get; set; }

		//needed so more references are possible to the same entity from one entity
		[InverseProperty("QuizMaster")]
		public List<Quiz> Quizzes { get; set; }

	}
}
