namespace MockIntegAPI.Models
{
    public record ProductRequest
    {
        public string? Name { get; set; }
        public Dictionary<string, object>? Data { get; set; }
    }
}
