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
				var fileLocation = await service.Get("Hello world", "en-US");
				Console.WriteLine(fileLocation);

				await service.Download(fileLocation, Directory.GetCurrentDirectory());
			}
			catch (Exception ex)
			{
				//wtf happened?
			}
		}
	}
}
