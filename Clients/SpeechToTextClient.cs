using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Linguo
{
    public partial class LinguoClient
    {
        public async ValueTask<string> GetTextFromAudioAsync(SpeechToTextModel model, CancellationToken cancellationToken = default)
        {
            using (var formData = new MultipartFormDataContent())
            {
                await using (var fileStream = File.OpenRead(model.FileName))
                {
                    using (var streamContent = new StreamContent(fileStream))
                    {
                        using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                        {
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                            formData.Add(fileContent, "audioFile", Path.GetFileName(model.FileName));
                            formData.Add(fileContent, "source", model.Source);
                            formData.Add(fileContent, "target", model.Target);

                            return await _httpClient.PostAsMultipartAsync<string>("/api/v1/Speech/GetTextFromAudio", formData, cancellationToken);
                        }
                    }
                }
            }
        }
    }
}