﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Client.Repositories
{
	public class NotesHttpRepository
	{
		private readonly HttpClient httpClient;

		public NotesHttpRepository(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<IEnumerable<T>> GetAllAsync<T>(string path) => 
			await httpClient.GetFromJsonAsync<IEnumerable<T>>(path);

		public async Task<T> GetAsync<T>(string id) =>
			await httpClient.GetFromJsonAsync<T>($"api/{typeof(T).Name.ToLower()}/{id}");

		public async Task<int> GetTotalAsync<T>()
		{
			return await httpClient.GetFromJsonAsync<int>($"api/{typeof(T).Name.ToLower()}/total");
		}

		public async Task<int> PostAsync<T> (T item)
		{
			var response = await httpClient.PostAsJsonAsync($"api/{typeof(T).Name.ToLower()}", item);
			response.EnsureSuccessStatusCode();
			var Id = await response.Content.ReadFromJsonAsync<int>();
			return Id;
		}

		public async Task PutAsync<T>(T note)
		{
			var response = await httpClient.PutAsJsonAsync($"api/{typeof(T).Name.ToLower()}", note);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteAsync<T>(int id) =>
			await httpClient.DeleteAsync($"api/{typeof(T).Name.ToLower()}/{id}");
	}
}