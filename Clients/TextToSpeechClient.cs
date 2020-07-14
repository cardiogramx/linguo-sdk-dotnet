using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Linguo
{
    public partial class LinguoClient
    {
        public async ValueTask<byte[]> GetAudioFromTextAsync(TextToSpeechModel model, CancellationToken cancellationToken = default) =>
            await _httpClient.PostAsync("/api/v1/Speech/GetAudioFromText", model, cancellationToken);

        public async ValueTask DownloadAudioAsync(TextToSpeechModel model, string filePath, CancellationToken cancellationToken = default) =>
            await File.WriteAllBytesAsync(filePath, await GetAudioFromTextAsync(model, cancellationToken), cancellationToken);
    }
}