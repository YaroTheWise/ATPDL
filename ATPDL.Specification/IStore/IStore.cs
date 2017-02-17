using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATPDL.Specification.IStore
{
    public interface IStore
    {
        IPlayerRepository PlayerRepository { get; }

        void SubmitChanges();
        Task SubmitChangesAsync();
        void Initialize();
    }
}
