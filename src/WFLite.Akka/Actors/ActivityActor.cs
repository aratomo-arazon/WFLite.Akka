using Akka.Actor;
using System;
using WFLite.Interfaces;

namespace WFLite.Akka.Actors
{
    public class ActivityActor : ReceiveActor
    {
        protected void Receive<TMessage>(Func<IActorContext, IActorRef, IActorRef, TMessage, IActivity> createFunc)
        {
            Receive<TMessage>(async message =>
            {
                var activity = createFunc(Context, Self, Sender, message);

                await activity.Start();
            });
        }
    }
}
