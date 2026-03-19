using System.Threading.Tasks;

namespace Container.Interfaces
{
    public interface IFDC3Client
    {
        Task Open(string appName);
    }
}
