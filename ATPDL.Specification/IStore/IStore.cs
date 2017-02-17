using System;
using System.Collections.Generic;
using System.Text;

namespace ATPDL.Specification.IStore
{
    public interface IStore
    {
        IPlayerRepository PlayerInfoRepository();
    }
}
