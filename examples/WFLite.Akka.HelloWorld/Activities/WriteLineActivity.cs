using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.Akka.Activities;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Akka.HelloWorld.Activities
{
    public class WriteLineActivity : DelegateActivity
    {
        public WriteLineActivity(IActorContext context, IActorRef self, IActorRef sender, string message)
        {
            Activity = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new ConsoleWriteLineActivity(new AnyVariable(message)),
                    new TellActivity()
                    {
                        ActorRef = new AnyVariable<IActorRef>(sender),
                        Message = new AnyVariable(message)
                    }
                }
            };
         }
    }
}
