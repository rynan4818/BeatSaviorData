﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaviorData
{
	class HTTPManager
	{
		public static readonly HttpClient client = new HttpClient();

		public async static void UploadPlayerStats(string json)
		{
			await Upload(json, PrivateKeys.BeatSaviorPlayerDataUploadURL);
			await Upload(json, PrivateKeys.GneuhPlayerDataUploadUrl);
		}

		public async static void UploadSongJson(string json)
		{
			await Upload(json, PrivateKeys.BeatSaviorSongUploadUrl);
			await Upload(json, PrivateKeys.GneuhSongUploadUrl);
		}

		private async static Task Upload(string json, string url)
		{
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage success = await client.PostAsync(url, content);

			if (success.IsSuccessStatusCode)
				Logger.log.Info("BSD : Upload successful to " + url.Substring(0, 15) + " !");
			else
				Logger.log.Info("BSD : Upload failed to " + url.Substring(0, 15) + "." + success.Content.ReadAsStringAsync().Result);
		}
	}
}
