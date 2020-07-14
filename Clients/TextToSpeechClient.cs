using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Linguo
{
    public partial class LinguoClient
    {
        public async Task<byte[]> GetAudioFromTextAsync(TextToSpeechModel tts, CancellationToken cancellationToken = default) =>
            await _httpClient.PostAsync<byte[]>("/api/v1/Speech/GetAudioFromText", tts, cancellationToken);

        public async Task DownloadAudioAsync(TextToSpeechModel tts, string filePath, CancellationToken cancellationToken = default) =>
            await File.WriteAllBytesAsync(filePath, await GetAudioFromTextAsync(tts, cancellationToken), cancellationToken);
    }
}