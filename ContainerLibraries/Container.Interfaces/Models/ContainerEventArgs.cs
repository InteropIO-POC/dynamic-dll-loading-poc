using Newtonsoft.Json.Linq;
using System;

namespace Container.Interfaces.Models
{
    public class ContainerEventArgs : EventArgs
    {
        public JToken Error { get; }
        public JToken Response { get; }

        public ContainerEventArgs(JToken error, JToken response)
        {
            Error = error;
            Response = response;
        }
    }
}
