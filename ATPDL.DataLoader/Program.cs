using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATPDL.DataLoader
{
    public static class Program
    {
        public static void Main()
        {
            var client = new DataLoader();
            client.LoadPlayers().GetAwaiter().GetResult();
        }
    }
}
