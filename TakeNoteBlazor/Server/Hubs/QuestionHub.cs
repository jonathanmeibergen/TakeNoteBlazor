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
			var userId = Context.UserIdentifier;
			var takeNoteUser = await _userManager.FindByIdAsync(userId);
			string userName = takeNoteUser.UserName;
			await Clients.All.ReceiveMessage($"{userName}: {answer}");
		}
	}
}
