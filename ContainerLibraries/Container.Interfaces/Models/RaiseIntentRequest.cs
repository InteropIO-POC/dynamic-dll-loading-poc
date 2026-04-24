namespace Container.Interfaces.Models
{
    public class RaiseIntentRequest
    {
        public string Intent { get; set; }
        public ContextMetadata Context { get; set; }
        public string Target { get; set; }
    }
}
