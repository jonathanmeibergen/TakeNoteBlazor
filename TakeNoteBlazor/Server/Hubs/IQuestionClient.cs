using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Hubs
{
	public interface IQuestionClient
	{
		Task PresentQuestion(int questionId);
		Task HideQuestion(int questionId);
		Task ShowAnswer(int questionId);
		Task ReceiveMessage(string message);
	}
}