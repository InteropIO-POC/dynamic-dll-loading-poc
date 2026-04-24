namespace Container.Interfaces.Models
{
    public class RaiseIntentResponse<T> where T : ContextMetadata
    {
        public T Result { get; set; }
        public string Source { get; set; }
        public string Intent { get; set; }
    }
}
