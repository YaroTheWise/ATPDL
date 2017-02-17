using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Interfaces
{
    public interface IPlayerBuilder
    {
        Player Build(string text);
    }
}