using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATPDL.DataLoader.Interfaces
{
    public interface IPlayerUrlListGetter
    {
        Task<List<string>> Get(System.Net.Http.HttpClient httpClient, int from, int to);
    }
}