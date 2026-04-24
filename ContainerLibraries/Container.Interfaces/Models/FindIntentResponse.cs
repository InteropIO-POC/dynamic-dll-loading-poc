using System.Collections.Generic;

namespace Container.Interfaces.Models
{
    public class FindIntentResponse
    {
        public string Intent { get; set; }
        public List<AppMetadata> Apps { get; set; }
    }

    public class AppMetadata
    {
        public string AppId { get; set; }
        public string Name { get; set; }
    }
}
