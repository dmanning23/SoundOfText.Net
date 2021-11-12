using SoundOfText.Net;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Get().Wait();
		}

		static async Task Get()
		{
			//create an instance of the SoundOfText service
			var service = new SoundOfTextService();

			try
			{
				//Ask the API to create an mp3 that says "Hello world" in an english (US) voice
				var fileLocation = await service.Get("Hello world", "en-US");
				
				//Write out the URL of the mp3 that was created
				Console.WriteLine(fileLocation);

				//Download the mp3 to bin/debug/net5.0/HelloWorld.mp3
				await service.Download(fileLocation, Directory.GetCurrentDirectory(), "HelloWorld.mp3");
			}
			catch (Exception ex)
			{
				//wtf happened?
				Console.WriteLine(ex.Message);
			}
		}
	}
}
