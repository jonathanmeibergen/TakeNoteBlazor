using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Server.Data;
using TakeNoteBlazor.Server.Models;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Hubs
{
	[Authorize]
	public class QuestionHub : Hub<IQuestionClient>
	{
		private readonly UserManager<TakeNoteUser> _userManager;
		private readonly TakeNoteContext _context;

		public QuestionHub(UserManager<TakeNoteUser> userManager, TakeNoteContext context)
		{
			_userManager = userManager;
			_context = context;
		}
		public async Task SendAnswer (string answer)
		{
			string userName = GetUser().Result.UserName;
			QuizDTO qd = new QuizDTO() { UserName = userName, Answer = answer };
			await Clients.All.ReceiveMessage(qd);
		}

		public async Task Subscribe(string quizGroup)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, quizGroup);
		}

		public async Task PresentQuestion (Question question)
		{
			var notification = new Notification
			{
				Time = DateTime.Now,
				User = GetUser().Result.UserName,
				Message = "",
				Group = String.Concat(Context.User.Identity.Name, question.Id),
			};
			//Groups.AddToGroupAsync(Context.ConnectionId,)
		}

		private async Task<TakeNoteUser> GetUser()
		{
			var userId = Context.UserIdentifier;
			return await _userManager.FindByIdAsync(userId);
		}
	}
}
