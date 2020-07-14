using System;
using System.Threading;
using System.Threading.Tasks;

namespace Linguo
{
    public partial class LinguoClient
    {
        public async Task<byte[]> GetAudioFromAudioAsync(SpeechToTextModel model, CancellationToken cancellationToken = default)
        {
            if (model.Source.Equals(model.Target, StringComparison.OrdinalIgnoreCase))
            {
                return default;
            }

            return await _httpClient.PostAsync<byte[]>("/api/v1/Speech/GetAudioFromAudio", model, cancellationToken);
        }
    }
}