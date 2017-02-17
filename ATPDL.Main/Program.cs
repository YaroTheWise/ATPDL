namespace ATPDL.Main
{
    public static class Program
    {
        public static void Main()
        {
            var client = new DataLoader.DataLoader();
            client.LoadPlayers().GetAwaiter().GetResult();
        }
    }
}
