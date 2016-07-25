using System;

namespace ConnectFour.Providers
{
    public class ConsoleInputProvider : IInputProvider
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
