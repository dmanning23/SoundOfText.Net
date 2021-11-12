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
				throw new Exception($"POST Call to api.soundoftext.com/sounds failed: {postResponse.message}");
			}

			var getResponse = await $"https://api.soundoftext.com/sounds/{postResponse.id}".GetJsonAsync();

			if (getResponse.status == "Pending")
			{
				while (getResponse.status == "Pending")
				{
					//wait a second
					await Task.Delay(500);

					//try again
					getResponse = await $"https://api.soundoftext.com/sounds/{postResponse.id}".GetJsonAsync();

					if (getResponse.status != "Pending")
					{
						break;
					}
				}
			}
			
			if (getResponse.status != "Done")
			{
				throw new Exception($"GET Call to api.soundoftext.com/sounds failed: {getResponse.message}");
			}

			return getResponse.location;
		}



		public async Task Download(string sourceFileLocation, string localFolderPath, string localFileName = null)
		{
			await sourceFileLocation.DownloadFileAsync(localFolderPath, localFileName);
		}
	}
}
