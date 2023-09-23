using Newtonsoft.Json;

namespace CustomerManagement.Application.Responses.Base
{
    public class Response<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
