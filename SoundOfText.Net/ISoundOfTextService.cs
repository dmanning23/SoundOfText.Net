using System.Threading.Tasks;

namespace SoundOfText.Net
{
	public interface ISoundOfTextService
	{
		/// <summary>
		/// Generate the sound file on the server and get the location
		/// </summary>
		/// <param name="text">The text to speak</param>
		/// <param name="voice">The voice to use. See https://soundoftext.com/docs#index for a list of available voices.</param>
		/// <returns></returns>
		Task<string> Get(string text, string voice);

		/// <summary>
		/// Download a generated file.
		/// </summary>
		/// <param name="sourceFileLocation">The server location as returned from the Get method.</param>
		/// <param name="localFolderPath">The local folder to download to</param>
		/// <param name="localFileName">A filename to save to. Null to use the filename from the server.</param>
		/// <returns></returns>
		Task Download(string sourceFileLocation, string localFolderPath, string localFileName);
		
	}
}