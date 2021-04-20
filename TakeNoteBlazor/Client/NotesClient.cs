using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Client
{
	public class NotesClient
	{
		private readonly HttpClient httpClient;

		public NotesClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<IEnumerable<Note>> GetNotesAsync(string path) => 
			await httpClient.GetFromJsonAsync<IEnumerable<Note>>(path);

		public async Task<Note> GetNoteAsync(string id) =>
			await httpClient.GetFromJsonAsync<Note>("api/note/" + id);

		public async Task<int> GetTotalPagesAsync() =>
			await httpClient.GetFromJsonAsync<int>("api/note/totalpages");

		public async Task<int> PostNote (Note note)
		{
			var response = await httpClient.PostAsJsonAsync("api/note", note);
			response.EnsureSuccessStatusCode();
			var noteId = await response.Content.ReadFromJsonAsync<int>();
			return noteId;
		}

		public async Task PutNote(Note note)
		{
			var response = await httpClient.PutAsJsonAsync("api/note", note);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteAsync(int id)
		{
			var response = await httpClient.DeleteAsync($"api/note/{id}");
		}

	}
}
