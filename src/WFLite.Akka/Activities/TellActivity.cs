using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Activities;
using WFLite.Interfaces;

namespace WFLite.Akka.Activities
{
    public class TellActivity : SyncActivity
    {
        public IActorRef _actor;

        public IVariable Message
        {
            private get;
            set;
        }

        public TellActivity(IActorRef actor)
        {
            _actor = actor;
        }

        public TellActivity(IActorRef actor, IVariable message)
        {
            _actor = actor;
            Message = message;
        }

        protected sealed override bool run()
        {
            _actor.Tell(Message.GetValue());

            return true;
        }
    }
}
