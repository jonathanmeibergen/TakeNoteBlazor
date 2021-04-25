using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Hubs
{
	public interface IQuestionClient
	{
		public Task PresentQuestion(Question question);
		public Task HideQuestion(int questionId);
		public Task ShowAnswer(int questionId);
		public Task ReceiveMessage(QuestionParticipant questionParticipant);
	}
}