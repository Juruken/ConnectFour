using System;

namespace ConnectFour.Providers
{
    public class ConsoleOutputProvider : IOutputProvider
    {
        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
