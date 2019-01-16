using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.Akka.Activities;
using WFLite.Akka.Actors;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Akka.HelloWorld.Actors
{
    public class ConsoleWriteLineActor : ActivityActor
    {
        public ConsoleWriteLineActor()
        {
            Receive<string>((context, self, sender, message) => new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new ConsoleWriteLineActivity() { Value = new AnyVariable() { Value = message } },
                    new TellActivity(sender) { Message = new AnyVariable() { Value = message } }
                }
            });
        }
    }
}
