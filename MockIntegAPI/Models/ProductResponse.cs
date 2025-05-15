using Newtonsoft.Json;

namespace MockIntegAPI.Models
{
    public record ProductResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public Dictionary<string, object>? Data { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
