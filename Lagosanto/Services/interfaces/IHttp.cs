using System.Threading.Tasks;

namespace Lagosanto.Services.interfaces;

public interface IHttp
{
    public Task<string> GetOneAsync(string route, int? id);

}