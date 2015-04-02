namespace Fitness.Console
{
    using System;
    using Fitness.Engine.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
