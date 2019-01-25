using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.Akka.Activities;
using WFLite.Akka.Actors;
using WFLite.Akka.HelloWorld.Activities;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Akka.HelloWorld.Actors
{
    public class ConsoleActor : ActivityActor
    {
        public ConsoleActor()
        {
            Receive<string, WriteLineActivity>();
        }
    }
}
