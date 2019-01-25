using Akka.Actor;
using System;
using System.Threading.Tasks;
using WFLite.Akka.Activities;
using WFLite.Akka.HelloWorld.Actors;
using WFLite.Variables;

namespace WFLite.Akka.HelloWorld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("test");
            var consoleActor = actorSystem.ActorOf<ConsoleActor>();

            var activity = new AskActivity()
            {
                ActorRef = new AnyVariable(consoleActor),
                Message = new AnyVariable("Hello World!")
            };

            await activity.Start();

            Console.ReadKey();
        }
    }
}
