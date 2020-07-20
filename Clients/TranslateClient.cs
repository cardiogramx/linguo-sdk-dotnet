using System.Threading;
using System.Threading.Tasks;

namespace Linguo
{
    public partial class LinguoClient
    {
        public async ValueTask<string> TranslateAsync(TranslateV1 model, CancellationToken cancellationToken = default) =>
            await _httpClient.PostAsync<string>("/api/v1/translate", model, cancellationToken);

        public async ValueTask<string> TranslateAsync(TranslateV2 model, CancellationToken cancellationToken = default) =>
            await _httpClient.PostAsync<string>("/api/v2/translate", model, cancellationToken);
    }
}