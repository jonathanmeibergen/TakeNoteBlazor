using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Server.Models;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Hubs
{
	[Authorize]
	public class QuestionHub : Hub<IQuestionClient>
	{
		private readonly UserManager<TakeNoteUser> _userManager;

		public QuestionHub(UserManager<TakeNoteUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task SendAnswer (string answer)
		{
			string userName = GetUser().Result.UserName;
			QuestionParticipant qp = new QuestionParticipant() { UserName = userName, Answer = answer };
			await Clients.All.ReceiveMessage(qp);
		}

		public async Task PresentQuestion (Question question)
		{
			string userName = GetUser().Result.UserName;
			string groupId = String.Concat(userName, question.Id);
			//Clients.
			//Groups.AddToGroupAsync(Context.ConnectionId,)
		}

		private async Task<TakeNoteUser> GetUser()
		{
			var userId = Context.UserIdentifier;
			return await _userManager.FindByIdAsync(userId);
		}
	}
}
