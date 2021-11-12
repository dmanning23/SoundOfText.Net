using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace SoundOfText.Net
{
	public class SoundOfTextService : ISoundOfTextService
	{
		public async Task<string> Get(string text, string voice)
		{
			var postResponse = await "https://api.soundoftext.com/sounds"
				.PostJsonAsync(new { engine = "google", data = new { text = text, voice = voice } })
				.ReceiveJson();

			//Check for 
			if (!postResponse.success)
			{
				throw new Exception("Call to api.soundoftext.com/sounds failed");
			}

			var getResponse = await $"https://api.soundoftext.com/sounds/{postResponse.id}".GetJsonAsync();

			if (getResponse.status != "Done")
			{
				throw new Exception("Call to api.soundoftext.com/sounds failed");
			}
			return getResponse.location;
		}

		public async Task Download(string sourceFileLocation, string localFolderPath, string localFileName = null)
		{
			await sourceFileLocation.DownloadFileAsync(localFolderPath, localFileName);
		}
	}
}
