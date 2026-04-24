using Container.Interfaces.Models;
using InteropIO.FDC3.Interfaces;
using InteropIO.FDC3.Types;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using ContextMetadata = Container.Interfaces.Models.ContextMetadata;

namespace Container.Impl
{
    internal static class FDC3Extensions
    {
        public static JToken ToContextValue(this Context ctx) => ctx?.Value ?? new JObject();

        public static Context ToContext(this ContextMetadata ctx)
        {
            if (ctx == null) return null;
            return new Context(JObject.FromObject(ctx));
        }

		public static Interfaces.Models.FindIntentResponse ToLegacyIntent(this IAppIntent intent)
        {
            return new Interfaces.Models.FindIntentResponse
            {
                Intent = intent.Intent.Name,
                Apps = intent.Apps?.Select(a => new Interfaces.Models.AppMetadata
                {
                    AppId = a.AppId,
                    Name = a.Name
                }).ToList()
            };
        }
		
		public static async Task<RaiseIntentResponse<T>> ToLegacyIntentResolution<T>(this IIntentResolution resolution) where T : ContextMetadata
        {
            var result = await resolution.GetResult();
            return new RaiseIntentResponse<T>
            {
                Intent = resolution.Intent,
                Source = resolution.Source?.AppId,
                Result = (T)(object)result
            };
        }
	}
}
